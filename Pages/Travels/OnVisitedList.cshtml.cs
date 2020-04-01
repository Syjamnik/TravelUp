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
    public class OnVisitedListModel : PageModel
    {
        private readonly DbUserQueries _db;
        private readonly UserManager<IdentityUser> _userManager;
        public OnVisitedListModel(DbUserQueries db,
             UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _db = db;
        }
        public IList<TravelUserVisitedList> OnVisitedList { get; set; }
        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            OnVisitedList = _db.Read(user.Id).OnVisitedList;
        }
    }
}