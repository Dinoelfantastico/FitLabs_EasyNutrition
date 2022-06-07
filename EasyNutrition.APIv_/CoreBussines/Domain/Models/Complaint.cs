namespace EasyNutrition.APIv_.CoreBussines.Domain.Models
{
    public class Complaint
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
