using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyEtf.Context;
using MyEtf.Models.Data;

namespace MyEtf.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly MyEtfContext _myEtfContext = new MyEtfContext();

        [HttpGet]
        public IActionResult Get()
        {
            var countries = _myEtfContext.Countries.ToList();
            return Ok(countries);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] Country country)
        {
            Country countryDb = _myEtfContext.Countries.FirstOrDefault(x => x.Name == country.Name);
            if(countryDb != null) return new OkObjectResult("Country already exists.");
            await _myEtfContext.AddAsync(country);
            await _myEtfContext.SaveChangesAsync();
            return new OkObjectResult("Country added.");
        }
    }
}