namespace PowerPlantManagement.Interfaces
{
    public interface IPowerPlant
    {
        string Name { get; set; }

        float Efficiency { get; set; }

        int Pmin { get; set; }

        int Pmax { get; set; }

        float Profitability { get; }
        int PCapacity { get; }

        int P { get; set; }
    }
}
