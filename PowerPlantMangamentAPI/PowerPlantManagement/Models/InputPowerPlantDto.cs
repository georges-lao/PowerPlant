using System.ComponentModel.DataAnnotations;

namespace PowerPlantManagement.Models
{
    public class InputPowerPlantDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        [Required]
        [MaxLength(6)]
        public float Efficiency { get; set; }

        [Required]
        [MaxLength(12)]
        public int Pmin { get; set; }

        [Required]
        [MaxLength(12)]
        public int Pmax { get; set; }
    }
}
