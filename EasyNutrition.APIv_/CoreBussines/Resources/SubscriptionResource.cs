namespace EasyNutrition.APIv_.CoreBussines.Resources
{
    public class SubscriptionResource
    {
        public int Id { get; set; }


        public bool active { get; set; }
        public int maxSessions { get; set; }
        public int price { get; set; }

        public UserResource User { get; set; }
    }
}
