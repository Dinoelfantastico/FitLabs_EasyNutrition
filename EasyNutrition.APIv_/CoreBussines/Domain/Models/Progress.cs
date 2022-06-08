namespace EasyNutrition.APIv_.CoreBussines.Domain.Models
{
    public class Progress
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
    }
}
