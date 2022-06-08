using System.ComponentModel.DataAnnotations;

namespace EasyNutrition.APIv_.CoreBussines.Resources
{
    public class SaveScheduleResource
    {
        [Required]
        [MaxLength(500)]
        public string StartAt { get; set; }

        [Required]
        [MaxLength(500)]
        public string EndAt { get; set; }

        public bool State { get; set; }

        public int UserId { get; set; }

    }
}
