using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Threading.Tasks;
using TravelUp.Data.DbQuery;
using TravelUp.Data.DbQuery.AuxiliaryClasses;
using TravelUp.Model;
using TravelUp.Services;

namespace TravelUp.Pages.Travels
{

    public class DetailsModel : PageModel
    {
        private readonly IDbTravelQueries _db;
        private readonly IDbFavouriteMTMQueries _dbF;
        private readonly IDbVisitedMTMQueries _dbV;
        private readonly IDbUserQueries _dbU;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ICalculateRating ratingCalc;

        public DetailsModel(IDbTravelQueries dbTravelQueries,
                            IDbFavouriteMTMQueries dbFavouriteMTMQueries,
                            IDbVisitedMTMQueries dbVisitedMTMQueries,
                            IDbUserQueries dbUserQueries,
                            UserManager<IdentityUser> userManager,
                            ICalculateRating calculateRating)
        {

            _db = dbTravelQueries;
            _dbF = dbFavouriteMTMQueries;
            _dbV = dbVisitedMTMQueries;
            _dbU = dbUserQueries;
            this.userManager = userManager;
            ratingCalc = calculateRating;
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

                    await _dbF.Create(new TravelUserFavouriteList
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
                    await _dbV.Create(new TravelUserVisitedList
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
            RatingValue= ratingCalc.Calculate(Travel.Rating.NumberOfVotes, Travel.Rating.Score);

            return Page();
        }
    }
}
