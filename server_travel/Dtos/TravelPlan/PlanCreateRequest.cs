namespace server_travel.Dtos.TravelPlan
{
    public class PlanCreateRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? TourId { get; set; }
    }
}
