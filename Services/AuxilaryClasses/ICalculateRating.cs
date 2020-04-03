namespace TravelUp.Services
{
    public interface ICalculateRating
    {
        int Calculate(int numberOfVotes, long score);
    }
}
