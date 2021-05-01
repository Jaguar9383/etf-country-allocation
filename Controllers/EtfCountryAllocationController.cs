using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEtf.Context;
using MyEtf.Models.Data;

namespace MyEtf.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class EtfCountryAllocationController : ControllerBase {
        private readonly MyEtfContext _myEtfContext = new MyEtfContext();

        [HttpGet("{etfId}")]
        public IActionResult Get(Guid etfId) {
            var result = _myEtfContext.EtfCountryAllocations.Where(x => x.EtfId == etfId).Include(x => x.Country).Include(x => x.Etf);
            return Ok(result);
        }

        [HttpPost("{etfId}")]
        public async Task<IActionResult> Update([FromBody] List<EtfCountryAllocation> etfCountryAllocations, Guid etfId) {
            var etfCountryAllocationsDb = _myEtfContext.EtfCountryAllocations.Where(x => x.EtfId == etfId);
            if (etfCountryAllocationsDb.Count() > 0) {
                _myEtfContext.EtfCountryAllocations.RemoveRange(etfCountryAllocationsDb);
                await _myEtfContext.SaveChangesAsync();
            }
            etfCountryAllocations.ForEach(x => { x.Country = null; x.Etf = null; });
            await _myEtfContext.EtfCountryAllocations.AddRangeAsync(etfCountryAllocations);
            await _myEtfContext.SaveChangesAsync();

            return Ok();
        }
    }
}