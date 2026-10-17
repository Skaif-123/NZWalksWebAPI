using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksWebAPI.Data;
using NZWalksWebAPI.Dtos.Vessel;
using NZWalksWebAPI.Models.Vessels;
using NZWalksWebAPI.Repository;

namespace NZWalksWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VesselController : ControllerBase
    {
        //DBContext  added

        private readonly IVesselRepository _vesselRepository;
        private readonly IMapper mapper;

        public VesselController(IVesselRepository vesselRepository,IMapper mapper)
        {
           
            _vesselRepository = vesselRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vesselDomain = await _vesselRepository.GetAllAsync();

            return Ok(mapper.Map<List<GetVesselsRequestDto>>(vesselDomain));
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var VesselDomain = await _vesselRepository.GetByIdAsync(id);
            if (VesselDomain is null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<GetVesselsRequestDto>(VesselDomain));
        }



        [HttpPost]
        public async Task<IActionResult> CreateVessel([FromBody] CreateVesselDto createVesselDto)
        {
            var vesselDomain =mapper.Map<Vessel>(createVesselDto);

            var createdVessel = await _vesselRepository.createVesselAsync(vesselDomain);

            return Ok(mapper.Map<GetVesselsRequestDto>(createdVessel));
        }



        [HttpPut("{IMO_Number}")]
        public async Task<IActionResult> UpdateVessel([FromRoute] string IMO_Number, [FromBody] UpdateVesselDto updateVesselDto)
        {
            var vesselDomain = await _vesselRepository.updateVesselAsync(IMO_Number, updateVesselDto);
            
            if (vesselDomain is null)
            {
                return NotFound();
            }

                return Ok(mapper.Map<GetVesselsRequestDto>(vesselDomain));
        }




        [HttpDelete("{IMO_Number}")]
        public async Task<IActionResult> DeleteVessel([FromRoute] string IMO_Number)
        {
            var vesselDomain = await _vesselRepository.deleteVesselAsync(IMO_Number);
            if (vesselDomain is null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
