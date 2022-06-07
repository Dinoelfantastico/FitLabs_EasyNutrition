namespace EasyNutrition.APIv_.CoreBussines.Resources
{
    public class ComplaintResources
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public UserResource User { get; set; }
    }
}
