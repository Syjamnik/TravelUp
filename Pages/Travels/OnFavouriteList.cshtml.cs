using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelUp.Data.DbQuery;
using TravelUp.Data.DbQuery.AuxiliaryClasses;
using TravelUp.Model;

namespace TravelUp.Pages.Travels
{
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
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var user = await _userManager.GetUserAsync(User);
            var userFromDb = _db.Read(user.Id);

            if (id.HasValue)
            {
                var elementToDelete = userFromDb.OnFavouriteList.Where(c => c.Travel.Id == id && c.User.Id == user.Id).FirstOrDefault();
                if (elementToDelete != null)
                {
                    userFromDb.OnFavouriteList.Remove(elementToDelete);
                    await _db.UpdateById(user.Id, userFromDb);
                }
            }

            OnFavouriteList = userFromDb.OnFavouriteList;
            return Page();
        }
    }
}