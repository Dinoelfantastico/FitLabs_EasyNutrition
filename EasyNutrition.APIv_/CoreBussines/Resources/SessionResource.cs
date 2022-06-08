namespace EasyNutrition.APIv_.CoreBussines.Resources
{
    public class SessionResource
    {
        public int Id { get; set; }
        public string StartAt { get; set; }
        public string EndAt { get; set; }

        public string Link { get; set; }

        public UserResource User { get; set; }
    }
}
