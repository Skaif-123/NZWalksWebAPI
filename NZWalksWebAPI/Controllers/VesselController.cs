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
        public VesselController(VesselDBContext context,IVesselRepository vesselRepository)
        {
           
            _vesselRepository = vesselRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vesselDomain = await _vesselRepository.GetAllAsync();

            var VesselDto = new List<GetVesselsRequestDto>();


            foreach (var vessels in vesselDomain)
            {
                VesselDto.Add(new GetVesselsRequestDto
                {
                    IMO_Number = vessels.IMO_Number,
                    Vessel_Name = vessels.Vessel_Name,
                    Call_Sign = vessels.Call_Sign,
                    DWT = vessels.DWT
                });
            }

            return Ok(VesselDto);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var VesselDomain = await _vesselRepository.GetByIdAsync(id);
            if (VesselDomain is null)
            {
                return NotFound();
            }


            var DisplayVessel = new GetVesselsRequestDto
            {
                Call_Sign = VesselDomain.Call_Sign,
                IMO_Number = VesselDomain.IMO_Number,
                Vessel_Name = VesselDomain.Vessel_Name,
                DWT = VesselDomain.DWT

            };

            return Ok(DisplayVessel);
        }



        [HttpPost]
        public async Task<IActionResult> CreateVessel([FromBody] CreateVesselDto createVesselDto)
        {
            var vesselDomain = new Vessel
            {
                IMO_Number = createVesselDto.IMO_Number,
                Vessel_Name = createVesselDto.Vessel_Name,
                Call_Sign = createVesselDto.Call_Sign,
                DWT = createVesselDto.DWT
            };

            var createdVessel = await _vesselRepository.createVesselAsync(vesselDomain);


            var displayVessel = new GetVesselsRequestDto
            {
                IMO_Number = createdVessel.IMO_Number,
                Vessel_Name = createdVessel.Vessel_Name,
                Call_Sign = createdVessel.Call_Sign,
                DWT = createdVessel.DWT
            };


            return Ok(displayVessel);
        }



        [HttpPut("{IMO_Number}")]
        public async Task<IActionResult> UpdateVessel([FromRoute] string IMO_Number, [FromBody] UpdateVesselDto updateVesselDto)
        {
            var vesselDomain = await _vesselRepository.updateVesselAsync(IMO_Number, updateVesselDto);
            
            if (vesselDomain is null)
            {
                return NotFound();
            }

            
            var displayVessel = new GetVesselsRequestDto
            {
                IMO_Number = vesselDomain.IMO_Number,
                Vessel_Name = vesselDomain.Vessel_Name,
                Call_Sign = vesselDomain.Call_Sign,
                DWT = vesselDomain.DWT
            };
            return Ok(displayVessel);
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
