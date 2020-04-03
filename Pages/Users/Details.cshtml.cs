using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelUp.Data.DbQuery;
using TravelUp.Data.DbQuery.AuxiliaryClasses;
using TravelUp.Model;
using TravelUp.Utility;

namespace TravelUp.Pages.Users
{
    [Authorize(Roles = StaticDetails.User)]
    public class DetailsModel : PageModel
    {
        private readonly IDbUserQueries _db;

        public DetailsModel(IDbUserQueries dbUserQueries)
        {
            _db = dbUserQueries;
        }

        public User UserModel { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserModel = _db.Read(id);

            if (UserModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
