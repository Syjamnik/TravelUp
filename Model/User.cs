using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using TravelUp.Dto;

namespace TravelUp.Model
{
    public class User : IdentityUser
    {
        #region istota
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        #endregion

        #region cele i osiągnięcia
        public IList<TravelUserVisitedList> OnVisitedList{ get; set; }
        public IList<TravelUserFavouriteList> OnFavouriteList { get; set; }
        #endregion

        public User()
        {
            OnFavouriteList= new List<TravelUserFavouriteList>();
            OnVisitedList = new List<TravelUserVisitedList>();
        }
        public User(UserDto userDto)
        {
            this.Name = userDto.Name;
            this.EmailAddress = userDto.EmailAddress;
        }
    
    }
}