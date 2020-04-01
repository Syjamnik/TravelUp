using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelUp.Data.DbQuery;
using TravelUp.Model;

namespace TravelUp.Pages.Travels
{
    public class OnFavouriteListModel : PageModel
    {
        private readonly DbUserQueries _db;
        private readonly UserManager<IdentityUser> _userManager;
        public OnFavouriteListModel(DbUserQueries db,
             UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _db = db;
        }
        public IList<TravelUserFavouriteList> OnFavouriteList { get; set; }
        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            OnFavouriteList = _db.Read(user.Id).OnFavouriteList;
        }
    }
}