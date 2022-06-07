namespace EasyNutrition.APIv_.CoreBussines.Resources
{
    public class ProgressResource
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public SessionResource Session { get; set; }
    }
}
