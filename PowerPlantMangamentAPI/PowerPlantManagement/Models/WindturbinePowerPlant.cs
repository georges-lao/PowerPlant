using PowerPlantManagement.Interfaces;
using System;

namespace PowerPlantManagement.Models
{
    public class WindturbinePowerPlant : IPowerPlant
    {
        private double _profitability;
        private int _pCapacity;

        public string Name { get; set; }

        public double Efficiency { get; set; }

        public int Pmin { get; set; }

        public int Pmax { get; set; }

        public double Profitability { get => _profitability; }

        public int P { get; set; }

        public int WindIndex { get; set; }

        public int PCapacity { get => _pCapacity; }

        public WindturbinePowerPlant(string name, int windIndex, double efficiency,int pmin, int pmax)
        {
            this.Name = name;
            this.WindIndex = windIndex;
            this.Efficiency = efficiency;
            this.Pmin = pmin;
            this.Pmax = pmax;
            this._profitability = 1/10;
            this._pCapacity = Convert.ToInt32(Math.Floor((windIndex/(double)100) * pmax));
        }

    }
}
