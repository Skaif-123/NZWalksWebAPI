using NZWalksWebAPI.Dtos.Vessel;
using NZWalksWebAPI.Models.Vessels;

namespace NZWalksWebAPI.Repository
{
    public interface IVesselRepository
    {

        public Task<List<Vessel>> GetAllAsync();

        public Task<Vessel?> GetByIdAsync(Guid id);

        public Task<Vessel> createVesselAsync(Vessel vessel);

        public Task<Vessel?> updateVesselAsync(string IMO_Number, UpdateVesselDto vessel);

        public Task<Vessel?> deleteVesselAsync(string IMO_Number);

    }
}
