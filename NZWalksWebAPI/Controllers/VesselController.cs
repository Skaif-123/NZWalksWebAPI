using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksWebAPI.Data;
using NZWalksWebAPI.Dtos.Vessel;
using NZWalksWebAPI.Models.Vessels;

namespace NZWalksWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VesselController : ControllerBase
    {
        //DBContext  added
        private readonly VesselDBContext _context;
        public VesselController(VesselDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vesselDomain = await _context.Vessels.ToListAsync();

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
            var VesselDomain = await _context.Vessels.FirstOrDefaultAsync(x => x.Id == id);
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

            await _context.Vessels.AddAsync(vesselDomain);
            await _context.SaveChangesAsync();

            var displayVessel = new GetVesselsRequestDto
            {
                IMO_Number = vesselDomain.IMO_Number,
                Vessel_Name = vesselDomain.Vessel_Name,
                Call_Sign = vesselDomain.Call_Sign,
                DWT = vesselDomain.DWT
            };


            return Ok(displayVessel);
        }



        [HttpPut("{IMO_Number:string}")]
        public async Task<IActionResult> UpdateVessel([FromRoute] string IMO_Number, [FromBody] UpdateVesselDto updateVesselDto)
        {
            var vesselDomain = await _context.Vessels.FirstOrDefaultAsync(x => x.IMO_Number == IMO_Number);
            if (vesselDomain is null)
            {
                return NotFound();
            }

            vesselDomain.Vessel_Name = updateVesselDto.Vessel_Name;
            vesselDomain.Call_Sign = updateVesselDto.Call_Sign;
            vesselDomain.DWT = updateVesselDto.DWT;
            await _context.SaveChangesAsync();
            var displayVessel = new GetVesselsRequestDto
            {
                IMO_Number = vesselDomain.IMO_Number,
                Vessel_Name = vesselDomain.Vessel_Name,
                Call_Sign = vesselDomain.Call_Sign,
                DWT = vesselDomain.DWT
            };
            return Ok(displayVessel);
        }




        [HttpDelete("{IMO_Number:string}")]
        public async Task<IActionResult> DeleteVessel([FromRoute] string IMO_Number)
        {
            var vesselDomain = await _context.Vessels.FirstOrDefaultAsync(x => x.IMO_Number == IMO_Number);
            if (vesselDomain is null)
            {
                return NotFound();
            }

            _context.Vessels.Remove(vesselDomain);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
