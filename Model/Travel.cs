using System;
using System.Collections.Generic;

namespace TravelUp.Model
{
    public class Travel : Queryable
    {
        public string Header { get; set; }
        public string Text { get; set; }
        public readonly DateTime Created = DateTime.Now;
        public DateTime Visited { get; }
        public User Author { get; set; }
        public int Id { get; set; }
        public Rating Rating { get; } = new Rating();
        public IList<TravelUserVisitedList> OnVisitedList { get; set; } = new List<TravelUserVisitedList>();
        public IList<TravelUserFavouriteList> OnFavouriteList { get; set; } = new List<TravelUserFavouriteList>();
        public Travel()
        {
        }


    }
}
