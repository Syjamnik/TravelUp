using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelUp.Model
{
    public class Travel : Queryable
    {
        [Required]
        [MaxLength(150)]
        public string Header { get; set; }
        [Required]
        [MinLength(50)]
        public string Text { get; set; }
        public readonly DateTime Created = DateTime.Now;
        public DateTime Visited { get; }
        
        public User Author { get; set; }
        public int Id { get; set; }

        [Required]
        public string AddressOfThePlace { get; set; }
        public Rating Rating { get; } = new Rating();
        public IList<TravelUserVisitedList> OnVisitedList { get; set; } = new List<TravelUserVisitedList>();
        public IList<TravelUserFavouriteList> OnFavouriteList { get; set; } = new List<TravelUserFavouriteList>();
        public Travel()
        {
        }


    }
}
