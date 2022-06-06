using System.ComponentModel.DataAnnotations;

namespace EasyNutrition.APIv_.CoreBussines.Resources
{
    public class SaveRoleResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

    }
}
