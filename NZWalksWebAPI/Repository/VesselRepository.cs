using Microsoft.EntityFrameworkCore;
using NZWalksWebAPI.Data;
using NZWalksWebAPI.Dtos.Vessel;
using NZWalksWebAPI.Models.Vessels;

namespace NZWalksWebAPI.Repository
{
    public class VesselRepository : IVesselRepository
    {
        private readonly VesselDBContext _dBContext;

        public VesselRepository(VesselDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<Vessel> createVesselAsync(Vessel vessel)
        {
            await _dBContext.Vessels.AddAsync(vessel);
            await _dBContext.SaveChangesAsync();
            return vessel;
        }

        public async Task<Vessel?> deleteVesselAsync(string IMO_Number)
        {
            var vessel = await _dBContext.Vessels.FirstOrDefaultAsync(v => v.IMO_Number == IMO_Number);
            if (vessel != null)
            {
                _dBContext.Vessels.Remove(vessel);
                await _dBContext.SaveChangesAsync();
            }

            else if (vessel is null) { return null; }
            return vessel;
        }

        public async Task<List<Vessel>> GetAllAsync()
        {
            return await _dBContext.Vessels.ToListAsync();
        }

        public async Task<Vessel?> GetByIdAsync(Guid id)
        {
            return await _dBContext.Vessels.FirstOrDefaultAsync(v => v.Id == id);
        }



        public async Task<Vessel?> updateVesselAsync(string IMO_Number, UpdateVesselDto vessel)
        {
            var vesselDomain = await _dBContext.Vessels.FirstOrDefaultAsync(v => v.IMO_Number == IMO_Number);

            if (vesselDomain == null)
            {
                return null;
            }

            vesselDomain.Vessel_Name = vessel.Vessel_Name;
            vesselDomain.Call_Sign = vessel.Call_Sign;
            vesselDomain.DWT = vessel.DWT;
            await _dBContext.SaveChangesAsync();
            return vesselDomain;

        }
    }
}
