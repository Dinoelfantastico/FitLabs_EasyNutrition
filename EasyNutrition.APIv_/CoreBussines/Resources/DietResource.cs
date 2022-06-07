namespace EasyNutrition.APIv_.CoreBussines.Resources
{
    public class DietResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public SessionResource Session { get; set; }
    }
}
