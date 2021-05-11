using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPlantManagement.Models
{
    public class InputRequestDto
    {
        public int load { get; set; }

        public InputFuelsDto Fuels { get; set; }

        public List<InputPowerPlantDto> InputPowerPlantDtos {  get; set; }

    }
}
