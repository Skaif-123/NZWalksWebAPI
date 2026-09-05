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
        private readonly NZWalksDBContext _dbcontext;
        public RegionController(NZWalksDBContext dBContext)
        {
            _dbcontext = dBContext;   
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = _dbcontext.Regions.ToList();  
  
            return Ok(regions);
        }
    }
}
