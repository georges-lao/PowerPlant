using PowerPlantManagement.Interfaces;
using System;

namespace PowerPlantManagement.Models
{
    public class TurbojetPowerPlant : IPowerPlant
    {
        private double _profitability;
        private int _pCapacity;

        public string Name { get; set; }

        public double Efficiency { get; set; }

        public int Pmin { get; set; }

        public int Pmax { get; set; }

        public double Profitability { get => _profitability; }

        public int P { get; set; }

        public double KerosineEuroMwh { get; set; }

        public int PCapacity { get => _pCapacity; }

        public TurbojetPowerPlant(string name, double kerosineEuroMwh, double efficiency, int pmin, int pmax)
        {
            this.Name = name;
            this.KerosineEuroMwh = kerosineEuroMwh;
            this.Efficiency = efficiency;
            this.Pmin = pmin;
            this.Pmax = pmax;
            this._profitability = KerosineEuroMwh * (1 / Efficiency);
            this._pCapacity = pmax;
        }

    }
}
