namespace TravelUp.Model
{
    public class TravelUserVisitedList
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int TravelId { get; set; }
        public Travel Travel { get; set; }
    }
}
