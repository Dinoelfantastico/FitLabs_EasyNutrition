using System.ComponentModel.DataAnnotations;

namespace EasyNutrition.APIv_.CoreBussines.Resources
{
    public class SaveProgressResource
    {

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }


        public int SessionId { get; set; }
    }
}
