namespace server_travel.Dtos.Tour
{
    public class TourSearchRequest
    {
        public string? DistrictName { get; set; }
        public string? TravelType { get; set; }
        public int? Person { get; set; }
        public DateTime? TravelDate { get; set; }
    }
}
