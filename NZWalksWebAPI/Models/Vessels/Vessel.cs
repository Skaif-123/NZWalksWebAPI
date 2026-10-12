using System.ComponentModel.DataAnnotations;

namespace NZWalksWebAPI.Models.Vessels
{
    public class Vessel
    {
        [Key]
        public Guid Id { get; set; }

        public  string IMO_Number { get; set; }

        public string Vessel_Name { get; set; }

        public string Call_Sign { get; set; }

        public int DWT { get; set; }

    }
}
