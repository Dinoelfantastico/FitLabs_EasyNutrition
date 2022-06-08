using System.ComponentModel.DataAnnotations;

namespace EasyNutrition.APIv_.CoreBussines.Resources
{
    public class SaveSessionResource
    {
        public string StartAt { get; set; }
        public string EndAt { get; set; }

        [Required]
        [MaxLength(100)]
        public string Link { get; set; }

        public int UserId { get; set; }
    }
}
