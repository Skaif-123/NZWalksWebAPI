using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksWebAPI.Data;
using NZWalksWebAPI.Dtos.Region;
using NZWalksWebAPI.Models;
using NZWalksWebAPI.Models.NZWalks;

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

            var regionsDomain = dbContext.Regions.ToList();

            var regionDTO = new List<RegionGetRequestDto>();

            //mapping all Fileds of DomainModel class to DTO class


            foreach (var singleRecord in regionsDomain) {
                regionDTO.Add(
                new RegionGetRequestDto()
                {
                    Id = singleRecord.Id,
                    Name = singleRecord.Name
                }
                );

            }
            

            return Ok(regionDTO);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            var regionDomain = dbContext.Regions.FirstOrDefault(x=>x.Id==id);
            if (regionDomain == null)
            {
                //will return 404 
                return NotFound();
            }

            var regionDTO = new RegionGetRequestDto()
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name
            };

            return Ok(regionDTO);
        }




        [HttpPost]
        public IActionResult CreateRegion([FromBody]RegionPostRequestDto DTO)
        {
            var RegionModel = new Regions
            {
                Name = DTO.Name,
                Code = DTO.Code,
                RegionImageUrl = DTO.RegionImageUrl
            };

            //we have added and saved the changes to table 
            dbContext.Regions.Add(RegionModel);
            dbContext.SaveChanges();

            //displaying bacck the response using DTO again

            var getRegion = new RegionGetRequestDto
            {
                Id = RegionModel.Id,
                Name = RegionModel.Name
            };


            return CreatedAtAction(nameof(GetById),new {Id=getRegion.Id},getRegion);
        }
    }
}
