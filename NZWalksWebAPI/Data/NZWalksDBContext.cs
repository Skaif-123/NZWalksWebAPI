using Microsoft.EntityFrameworkCore;


using NZWalksWebAPI.Models;

namespace NZWalksWebAPI.Data
{
    public class NZWalksDBContext:DbContext
    {
        public NZWalksDBContext(DbContextOptions<NZWalksDBContext> options) : base(options)
        {
        
                
        }

        public DbSet<Walks> Walks { get; set; }

        public DbSet<Regions> Regions { get; set; }

        public DbSet<Difficulty> Difficulties { get; set; }
    }
}
