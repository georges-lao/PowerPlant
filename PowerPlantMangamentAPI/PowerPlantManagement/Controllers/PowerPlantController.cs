using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PowerPlantManagement.Models;
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
        
        public IActionResult GetPowerPlantsList()
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

        [HttpPost]
        public IActionResult GetPowerPlantsLoads([FromBody]JObject request)
        {
            InputRequestDto loadRequest;
            try
            {
                //deserialize
                loadRequest = new InputRequestDto() { load = Convert.ToInt32(request["load"].ToString()) };
                loadRequest.Fuels = JsonConvert.DeserializeObject<InputFuelsDto>(request["fuels"].ToString());
                loadRequest.InputPowerPlantDtos = JsonConvert.DeserializeObject<List<InputPowerPlantDto>>(request["powerplants"].ToString());
            }
            catch (Exception e)
            {
                //Exception and log policy to implement
                return BadRequest();
            }
            var result = new LoadRequest(loadRequest);

            return Ok(new JsonResult(
                    result.GetLoadPlan()
                )); ;
        }
 
    }
}
