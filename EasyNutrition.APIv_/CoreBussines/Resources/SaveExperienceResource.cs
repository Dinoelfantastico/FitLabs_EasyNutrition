using System.ComponentModel.DataAnnotations;

namespace EasyNutrition.APIv_.CoreBussines.Resources
{
    public class SaveExperienceResource
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        public int UserId { get; set; }
    }
}
