namespace PowerPlantManagement.Models
{
    public class InputPowerPlantDto
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public float Efficiency { get; set; }

        public int Pmin { get; set; }

        public int Pmax { get; set; }
    }
}
