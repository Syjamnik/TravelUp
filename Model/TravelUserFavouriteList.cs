using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelUp.Model
{
    public class TravelUserFavouriteList
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int TravelId { get; set; }
        public Travel Travel { get; set; }
    }
}
