namespace NZWalksWebAPI.Dtos.Vessel
{
    public class CreateVesselDto
    {

        public string IMO_Number { get; set; }

        public string Vessel_Name { get; set; }

        public string Call_Sign { get; set; }

        public int DWT { get; set; }
    }
}
