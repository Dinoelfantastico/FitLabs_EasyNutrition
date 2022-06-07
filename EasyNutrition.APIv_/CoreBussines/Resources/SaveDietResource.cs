using System.ComponentModel.DataAnnotations;

namespace EasyNutrition.APIv_.CoreBussines.Resources
{
    public class SaveDietResource
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        public int SessionId { get; set; }
    }
}
