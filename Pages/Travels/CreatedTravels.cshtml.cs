using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelUp.Data.DbQuery.AuxiliaryClasses;
using TravelUp.Model;

namespace TravelUp.Pages.Travels
{
    public class CreatedTravelsModel : PageModel
    {

        private readonly IDbTravelQueries _db;
        private readonly UserManager<IdentityUser> _userManager;

        public CreatedTravelsModel(IDbTravelQueries dbTravelQueries,
            IDbUserQueries dbUserQueries,
            UserManager<IdentityUser> userManager)
        {
            _db = dbTravelQueries;
            _userManager = userManager;
        }

        public IList<Travel> Travel { get; set; }


        public  void OnGet()
        {
            string userId = _userManager.GetUserId(User);
            Travel =  _db.ReadAllUserTravels(userId);
        }
    }
}