namespace EasyNutrition.APIv_.CoreBussines.Resources
{
    public class SaveScheduleResource
    {
        public string StartAt { get; set; }

        public string EndAt { get; set; }

        public bool State { get; set; }

        public int UserId { get; set; }
    }
}
