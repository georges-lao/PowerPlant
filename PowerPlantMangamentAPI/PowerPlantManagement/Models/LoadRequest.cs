using PowerPlantManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPlantManagement.Models
{
    public class LoadRequest
    {
        private int _load;
        private List<IPowerPlant> _powerPlants;

        public LoadRequest (InputRequestDto request)
        {
            this._load = request.load;
            initialisePowerPlantList(request);
        }

        private void initialisePowerPlantList(InputRequestDto request)
        {
            _powerPlants = new List<IPowerPlant>();
            foreach (var item in request.InputPowerPlantDtos)
            {
                if (item.Type.Equals("gasfired"))
                {
                    _powerPlants.Add(new GasfiredPowerPlant(item.Name, request.Fuels.gazEeuroMWh, item.Efficiency, item.Pmin, item.Pmax));
                }
                if (item.Type.Equals("turbojet"))
                {
                    _powerPlants.Add(new TurbojetPowerPlant(item.Name, request.Fuels.KerosineEuroMwh, item.Efficiency, item.Pmin, item.Pmax));
                }
                if (item.Type.Equals("windturbine"))
                {
                    _powerPlants.Add(new WindturbinePowerPlant(item.Name, request.Fuels.WindIndex , item.Efficiency, item.Pmin, item.Pmax));
                }
            }
        }

        public List<OutputPowerPlantDto> GetLoadPlan()
        {
            var loaded = 0;
            var result = new List<OutputPowerPlantDto>();
            var list = _powerPlants.OrderByDescending(y => y.PCapacity).OrderBy(x => x.Profitability);

            foreach (var item in list)
            {
                if (_load > loaded)
                {
                    if (item.PCapacity > (_load - loaded))
                    {
                        result.Add(new OutputPowerPlantDto() { Name = item.Name, p = (_load - loaded) });
                        loaded += item.PCapacity;
                    }
                    else
                    {
                        result.Add(new OutputPowerPlantDto() { Name = item.Name, p = item.PCapacity });
                        loaded += item.PCapacity;
                    }
                    
                }
                else
                {
                    result.Add(new OutputPowerPlantDto() { Name = item.Name, p = 0 });
                }

                
            }

            return result;
        }
    }
}
