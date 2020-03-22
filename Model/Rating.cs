namespace TravelUp.Model
{
    public class Rating : Queryable
    {
        public int Id { get; set; }
        public long Votes { get; set; }
        public int NumberOfVotes { get; set; }
    }
}
