using PowerPlantManagement.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PowerPlantManagement.Models
{
    public class RequestProcessor
    {
        private int _load;
        private List<IPowerPlant> _powerPlants;

        public RequestProcessor (InputRequestDto request)
        {
            this._load = request.load;
            initialisePowerPlantList(request);
        }
       
        public List<OutputPowerPlantDto> GetLoadPlan()
        {
            var loaded = 0;
            var ToLoad = 0;
            var result = new List<OutputPowerPlantDto>();
            var list = _powerPlants.OrderBy(x => x.Profitability).ThenByDescending(x => x.PCapacity);
            var RequirePPNb = getRequirePowerPlantCount(list);
            var count = 0;

            foreach (var item in list)
            {
                if (count < RequirePPNb)
                {
                    item.P = item.Pmin;
                    loaded += item.Pmin;
                    count++;
                }
                else
                    break;
            }

            foreach (var item in list)
            {                
                    if ((item.PCapacity - item.P) < (_load - loaded))
                    {
                        ToLoad = item.PCapacity - item.P;
                        item.P += ToLoad;
                        loaded += ToLoad;
                    }
                    else
                    {
                        ToLoad = _load - loaded;
                        item.P += ToLoad;
                        loaded += ToLoad;
                    }
                    result.Add(new OutputPowerPlantDto() { Name = item.Name, p = item.P });                                               
            }

            return result;
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
                    _powerPlants.Add(new WindturbinePowerPlant(item.Name, request.Fuels.WindIndex, item.Efficiency, item.Pmin, item.Pmax));
                }
            }
        }

        private int getRequirePowerPlantCount(IEnumerable<IPowerPlant> list)
        {
            var result = 0;
            var loaded = 0;

            foreach (var item in list)
            {
                if (loaded < _load)
                {
                    result++;
                    loaded += item.PCapacity;
                }
                else
                {
                    break;
                }
            }
            return result;
        }
    }
}
