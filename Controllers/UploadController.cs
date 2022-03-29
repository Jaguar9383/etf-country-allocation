using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyEtf.Context;
using MyEtf.Models.Data;
using MyEtf.Models.Dto;

namespace MyEtf.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly MyEtfContext _myEtfContext = new MyEtfContext();
        
        [HttpPost("{id}")]
        public async Task<IActionResult> Upload(Guid id)
        {
            Etf etf = _myEtfContext.Etfs.FirstOrDefault(x => x.Id == id);
            if(etf == null) return NotFound();

            var client = new HttpClient();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(etf.DataUrl);
            request.Method = HttpMethod.Get;

            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("User-Agent", "Thunder Client (https://www.thunderclient.com)");

            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();

            var objectResult = JsonSerializer.Deserialize<CompanyEtfAllocationDto>(result);
            List<CompanyEtfDto> companies = new List<CompanyEtfDto>();
            foreach(var company in objectResult.Data)
            {
                CompanyEtfDto companyDto = new CompanyEtfDto();
                companyDto.Ticker = company[0].ToString();
                companyDto.Name = company[1].ToString();
                companyDto.ISIN = company[8].ToString();
                companyDto.Country = company[10].ToString();
                companyDto.StockExchange = company[11].ToString();
                companyDto.Currency = company[12].ToString();
                //
                var amount = JsonSerializer.Deserialize<DisplayRaw>(company[5].ToString());
                companyDto.Percent = amount.Raw;

                companies.Add(companyDto);
            }

            var countries = companies
                        .GroupBy(c => c.Country)
                        .Select(cl => new { Name = cl.First().Country, Percent = cl.Sum(c => c.Percent)})
                        .Where(x => x.Percent > 0)
                        .OrderByDescending(x => x.Percent);

            //empty
            var allocationsToRemove = _myEtfContext.EtfCountryAllocations.Where(a => a.EtfId == id);
            _myEtfContext.EtfCountryAllocations.RemoveRange(allocationsToRemove);

            foreach(var country in countries)
            {
                var countryDb = _myEtfContext.Countries.FirstOrDefault(x => x.Name == country.Name);
                if(countryDb == null) {
                    _myEtfContext.Countries.Add(new Country{ Name = country.Name });
                    _myEtfContext.SaveChanges();
                    countryDb = _myEtfContext.Countries.FirstOrDefault(x => x.Name == country.Name);
                }

                //add
                _myEtfContext.EtfCountryAllocations.Add(new EtfCountryAllocation{
                    CountryId = countryDb.Id,
                    EtfId = id,
                    Allocation = country.Percent
                });
            }

            _myEtfContext.SaveChanges();

            return Ok(countries);
        }
    }
}