using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PowerPlantManagement.Models
{
    public struct InputFuelsDto
    {
        [Required]
        [JsonProperty("gas(euro/MWh)")]
        public double gazEeuroMWh { get; set; }

        [Required]
        [JsonProperty("kerosine(euro/MWh)")]
        public double KerosineEuroMwh { get; set; }

        [Required]
        [JsonProperty("co2(euro/ton)")]
        public double Co2EuroTon { get; set; }

        [Required]
        [JsonProperty("wind(%)")]
        public int WindIndex { get; set; }
    }
}
