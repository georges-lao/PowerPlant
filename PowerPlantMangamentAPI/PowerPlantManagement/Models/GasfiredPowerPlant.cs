using PowerPlantManagement.Interfaces;
using System;

namespace PowerPlantManagement.Models
{
    public class GasfiredPowerPlant : IPowerPlant
    {
        private float _profitability;
        private int _pCapacity;

        public string Name { get; set; }

        public float Efficiency { get; set; }

        public int Pmin { get; set; }

        public int Pmax { get; set; }

        public float Profitability  { get => _profitability;  }

        public int P { get; set; }

        public float GazEuroMwh { get; set; }

        public int PCapacity { get => _pCapacity; }

        public GasfiredPowerPlant (string name, float gazEuroMwh, float efficiency, int pmin, int pmax)
        {
            this.Name = name;
            this.GazEuroMwh = gazEuroMwh;
            this.Efficiency = efficiency;
            this.Pmin = pmin;
            this.Pmax = pmax;
            this._profitability = GazEuroMwh * (1 / Efficiency);
            this._pCapacity = pmax;
        }

    }
}
