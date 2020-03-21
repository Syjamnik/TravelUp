using System.Collections.Generic;
using TravelUp.Model;

namespace TravelUp.Dto
{
    
    public class UserDto
    {
        #region istota
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Password{ get; set; }
        public string ConfirmPassword { get; set; }
        #endregion

        #region cele i osiągnięcia

        #endregion
        public UserDto()
        {

        }
        public UserDto(User userToConvert)
        {
            this.Name = userToConvert.UserName;
            this.EmailAddress = EmailAddress; 
        }

    }
}
