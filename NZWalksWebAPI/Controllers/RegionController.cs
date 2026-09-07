using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksWebAPI.Data;
using NZWalksWebAPI.Models;

namespace NZWalksWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        //practicing for Regions GET API using dbcontext
        private readonly NZWalksDBContext dbContext;

        public RegionController(NZWalksDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult GetAll() {

            var regions = dbContext.Regions.ToList();

            return Ok(regions);
        }

    }
}
