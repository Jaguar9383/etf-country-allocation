using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEtf.Context;
using MyEtf.Models.Data;

namespace MyEtf.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EtfsController : ControllerBase
    {
        private readonly MyEtfContext _myEtfContext = new MyEtfContext();

        [HttpGet]
        public IActionResult Get()
        {
            var etfs = _myEtfContext.Etfs.Include(x => x.Allocations).ThenInclude(x => x.Country).ToList();
            return Ok(etfs);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var etfDb = _myEtfContext.Etfs.FirstOrDefault(x => x.Id == id);
            if(etfDb == null) return Ok("Etf not found.");
            return Ok(etfDb);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] Etf etf)
        {
            Etf etfDb = _myEtfContext.Etfs.FirstOrDefault(x => x.Name == etf.Name);
            if(etfDb != null) return new OkObjectResult("Etf already exists.");
            await _myEtfContext.AddAsync(etf);
            await _myEtfContext.SaveChangesAsync();
            return new OkObjectResult("Etf added.");
        }
    }
}
