using Microsoft.EntityFrameworkCore;
using NZWalksWebAPI.Models.Vessels;

namespace NZWalksWebAPI.Data
{
    public class VesselDBContext:DbContext
    {
        public VesselDBContext(DbContextOptions<VesselDBContext> options)
            : base(options) 
        {
            
        }

        public DbSet<Vessel> Vessels { get; set; }


    }
}
