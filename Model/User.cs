using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TravelUp.Model
{
    public class User : IdentityUser
    {

        #region cele i osiągnięcia
        public IList<TravelUserVisitedList> OnVisitedList { get; set; } = new List<TravelUserVisitedList>();
        public IList<TravelUserFavouriteList> OnFavouriteList { get; set; } = new List<TravelUserFavouriteList>();
        #endregion
    }
}