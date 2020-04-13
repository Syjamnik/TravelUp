using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelUp.Data.DbQuery;
using TravelUp.Data.DbQuery.AuxiliaryClasses;
using TravelUp.Model;
using TravelUp.Utility;

namespace TravelUp.Pages.Travels
{
    [Authorize(Roles = StaticDetails.AdminAndUser)]
    public class OnFavouriteListModel : PageModel
    {
        private readonly IDbUserQueries _db;
        private readonly UserManager<IdentityUser> _userManager;
        public OnFavouriteListModel(IDbUserQueries db,
             UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _db = db;
        }
        public IList<TravelUserFavouriteList> OnFavouriteList { get; set; }

        // deleteMethod
        public async Task<IActionResult> OnGetAsync(int? id)
        {

            var userId =  _userManager.GetUserId(User);
            var userFromDb = _db.Read(userId);

            if (userFromDb == null)
            {
                return NotFound();
            }

            var elementToDelete = userFromDb.OnFavouriteList.Where(c => c.Travel.Id == id && c.User.Id == userId)
                                                            .FirstOrDefault();
            
            if (elementToDelete != null)
            {
                userFromDb.OnFavouriteList.Remove(elementToDelete);
                await _db.UpdateById(userId, userFromDb);
            }


            OnFavouriteList = userFromDb.OnFavouriteList;
            return Page();
        }
    }
}