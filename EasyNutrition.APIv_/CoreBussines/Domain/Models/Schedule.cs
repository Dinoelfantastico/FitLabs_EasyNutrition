namespace EasyNutrition.APIv_.CoreBussines.Domain.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string StartAt { get; set; }
        public string EndAt { get; set; }
        public bool State { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
