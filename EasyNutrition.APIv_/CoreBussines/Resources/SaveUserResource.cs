using System.ComponentModel.DataAnnotations;

namespace EasyNutrition.APIv_.CoreBussines.Resources
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MaxLength(80)]
        public string Password { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MaxLength(40)]
        public string Lastname { get; set; }

        [Required]
        [MaxLength(20)]
        public string Birthday { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(10)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        public bool Active { get; set; }

        [Required]
        [MaxLength(100)]
        public string Linkedin { get; set; }

        public int RoleId { get; set; }

    }
}
