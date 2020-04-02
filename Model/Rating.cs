namespace TravelUp.Model
{
    public class Rating : Queryable
    {
        public int Id { get; set; }
        public long Score { get; set; }
        public int NumberOfVotes { get; set; }
    }
}
