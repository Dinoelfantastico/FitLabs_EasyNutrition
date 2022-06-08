namespace EasyNutrition.APIv_.CoreBussines.Resources
{
    public class SaveSubscriptionResource
    {
        public bool Active { get; set; }
        public int MaxSessions { get; set; }
        public int Price { get; set; }

        public int UserId { get; set; }
    }
}
