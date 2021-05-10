using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPlantManagement.Controllers
{
    [ApiController]
    [Route("api/PowerPlants")]
    public class PowerPlantController : ControllerBase
    {
        
        public IActionResult GetPowerPlants()
        {
            return Ok(new JsonResult(
                new List<Object>()
                {
                    new {id = 1, Name = "windpark1" },
                    new {id = 2, Name = "windpark2"},
                    new {id = 2, Name = "gasfiredbig1"},
                    new {id = 2, Name = "gasfiredbig1"}
                }
                ) );
        }
 
    }
}
