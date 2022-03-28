using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyEtf.Models.Dto;

namespace MyEtf.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Upload()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://www.ishares.com/uk/individual/en/products/251882/ishares-msci-world-ucits-etf-acc-fund/1506575576011.ajax?tab=all&fileType=json");
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
            return Ok(companies
                        .GroupBy(c => c.Country)
                        .Select(cl => new { Country = cl.First().Country, Percent = cl.Sum(c => c.Percent)})
                        .OrderByDescending(x => x.Percent)
            );
        }
    }
}