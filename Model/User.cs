using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using TravelUp.Dto;

namespace TravelUp.Model
{
    public class User : IdentityUser
    {

        #region cele i osiągnięcia
        public IList<TravelUserVisitedList> OnVisitedList{ get; set; }
        public IList<TravelUserFavouriteList> OnFavouriteList { get; set; }
        #endregion

        public User()
        {
            OnFavouriteList= new List<TravelUserFavouriteList>();
            OnVisitedList = new List<TravelUserVisitedList>();
        }
    }
}