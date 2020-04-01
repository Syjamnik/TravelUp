using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Threading.Tasks;
using TravelUp.Data.DbQuery;
using TravelUp.Model;

namespace TravelUp.Pages.Travels
{

    public class DetailsModel : PageModel
    {
        private readonly DbTravelQueries _db;
        private readonly DbFavouriteMTMQueries _dbF;
        private readonly DbVisitedMTMQueries _dbV;
        private readonly DbUserQueries _dbU;
        UserManager<IdentityUser> userManager;

        public DetailsModel(DbTravelQueries dbTravelQueries, DbFavouriteMTMQueries dbFavouriteMTMQueries,
                            DbVisitedMTMQueries dbVisitedMTMQueries, DbUserQueries dbUserQueries, UserManager<IdentityUser> userManager)
        {

            _db = dbTravelQueries;
            _dbF = dbFavouriteMTMQueries;
            _dbV = dbVisitedMTMQueries;
            _dbU = dbUserQueries;
            this.userManager = userManager;
        }

        public Travel Travel { get; set; }
        public double RatingValue { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? addTo)
        {
            if (id == null)
            {
                return NotFound();
            }
            Travel = _db.Read(id.GetValueOrDefault());
            User user = _dbU.Read(userManager.GetUserId(User));
            // adding to favourite, visited places
            {

                // favourite
                // if there user don't have this travel on the list then add this travel
                if (addTo == 1 &&
                    user.OnFavouriteList.Where(c => c.User.Id == user.Id &&
                                                   c.Travel.Id == Travel.Id).FirstOrDefault() == null)
                {

                    await _dbF.add(new TravelUserFavouriteList
                    {
                        User = user,
                        Travel = Travel
                    });
                }
                //visited
                // if there user don't have this travel  on the list then add this travel
                if (addTo == 2 &&
                    user.OnFavouriteList.Where(c => c.User.Id == user.Id &&
                                                   c.Travel.Id == Travel.Id).FirstOrDefault() == null)
                {
                    await _dbV.add(new TravelUserVisitedList
                    {
                        User = user,
                        Travel = Travel
                    });
                }
            }


            Travel = _db.Read(id.GetValueOrDefault());

            if (Travel == null)
            {
                return NotFound();
            }
            if (Travel.Rating.NumberOfVotes <= 0)
                RatingValue = 0;
            else
                RatingValue = Travel.Rating.Votes / Travel.Rating.NumberOfVotes;

            Math.Round(RatingValue);



            return Page();
        }
    }
}
