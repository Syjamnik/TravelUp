using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using TravelUp.DbQuery;
using TravelUp.Model;

namespace TravelUp.Pages.Travels
{
    public class DetailsModel : PageModel
    {
        private readonly DbTravelQueries _db;

        public DetailsModel(DbTravelQueries dbTravelQueries)
        {
            _db = dbTravelQueries;
        }

        public Travel Travel { get; set; }
        public double RatingValue { get; set; }

        public  IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
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
