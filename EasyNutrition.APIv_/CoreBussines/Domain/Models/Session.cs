namespace EasyNutrition.APIv_.CoreBussines.Domain.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string StartAt { get; set; }
        public string EndAt { get; set; }

        public string Link { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
