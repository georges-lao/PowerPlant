using PowerPlantManagement.Interfaces;
using System;

namespace PowerPlantManagement.Models
{
    public class WindturbinePowerPlant : IPowerPlant
    {
        private float _profitability;
        private int _pCapacity;

        public string Name { get; set; }

        public float Efficiency { get; set; }

        public int Pmin { get; set; }

        public int Pmax { get; set; }

        public float Profitability { get => _profitability; }

        public int P { get; set; }

        public int WindIndex { get; set; }

        public int PCapacity { get => _pCapacity; }

        public WindturbinePowerPlant(string name, int windIndex, float efficiency,int pmin, int pmax)
        {
            this.Name = name;
            this.WindIndex = windIndex;
            this.Efficiency = efficiency;
            this.Pmin = pmin;
            this.Pmax = pmax;
            this._profitability = 0;
            this._pCapacity = Convert.ToInt32(Math.Ceiling((double) (windIndex/100) * pmax));
        }

    }
}
