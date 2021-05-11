namespace PowerPlantManagement.Interfaces
{
    public interface IPowerPlant
    {
        string Name { get; set; }

        double Efficiency { get; set; }

        int Pmin { get; set; }

        int Pmax { get; set; }

        double Profitability { get; }
        int PCapacity { get; }

        int P { get; set; }
    }
}
