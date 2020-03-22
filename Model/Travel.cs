using System.Collections.Generic;

namespace TravelUp.Model
{
    public class Travel : Article, Queryable
    {
        public int Id { get; set; }
        public Rating Rating { get; } = new Rating();
        public IList<TravelUserVisitedList> OnVisitedList { get; set; } = new List<TravelUserVisitedList>();
        public IList<TravelUserFavouriteList> OnFavouriteList { get; set; } = new List<TravelUserFavouriteList>();
        public Travel() : base()
        {
        }

    }
}
