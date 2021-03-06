﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelUp.Data.DbQuery;
using TravelUp.Data.DbQuery.AuxiliaryClasses;
using TravelUp.Model;
using TravelUp.Services;
using TravelUp.Services.AuxilaryClasses;
using TravelUp.Utility;

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
        private readonly IImageManager _imageManager;

        public DetailsModel(IDbTravelQueries dbTravelQueries,
                            IDbFavouriteMTMQueries dbFavouriteMTMQueries,
                            IDbVisitedMTMQueries dbVisitedMTMQueries,
                            IDbUserQueries dbUserQueries,
                            UserManager<IdentityUser> userManager,
                            ICalculateRating calculateRating,
                            IImageManager imageManager)
        {

            _db = dbTravelQueries;
            _dbF = dbFavouriteMTMQueries;
            _dbV = dbVisitedMTMQueries;
            _dbU = dbUserQueries;
            this.userManager = userManager;
            ratingCalc = calculateRating;
            _imageManager = imageManager;
        }

        public Travel Travel { get; set; }
        public double RatingValue { get; set; }
        public List<string> ImageAddresses { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id, int? addTo)
        {
            if (id == null)
            {
                return NotFound();
            }

            Travel = _db.Read(id.GetValueOrDefault());
            ImageAddresses = _imageManager.LoadUploadedFileAddresses(Travel.ImagesAddr);
            if (Travel == null)
            {
                return NotFound();
            }



            // adding to favourite, visited places
            if(addTo != null)
            {
                var idOfUser = userManager.GetUserId(User);
                User user = _dbU.Read(idOfUser);
                if (user == null)
                {
                    return NotFound();
                }

                await addToVisitedOrFavurite(addTo, user);
            }

            RatingValue= ratingCalc.Calculate(Travel.Rating.NumberOfVotes, Travel.Rating.Score);

            return Page();
        }
        [Authorize(Roles = StaticDetails.AdminAndUser)]
        private async Task addToVisitedOrFavurite(int? addTo, User user)
        {
            // we want the user to stay on the same page
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
                user.OnVisitedList.Where(c => c.User.Id == user.Id &&
                                               c.Travel.Id == Travel.Id).FirstOrDefault() == null)
            {
                await _dbV.Create(new TravelUserVisitedList
                {
                    User = user,
                    Travel = Travel
                });
            }
        }
    }
}
