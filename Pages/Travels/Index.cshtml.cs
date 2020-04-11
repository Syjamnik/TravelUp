using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelUp.Data.DbQuery;
using TravelUp.Data.DbQuery.AuxiliaryClasses;
using TravelUp.Model;

namespace TravelUp.Pages.Travels
{
    public class IndexModel : PageModel
    {
        private readonly IDbTravelQueries _db;
        private readonly IDbUserQueries _dbU;
        private readonly UserManager<IdentityUser> _userManager;
        public IndexModel(IDbTravelQueries dbTravelQueries, IDbUserQueries dbUserQueries, UserManager<IdentityUser> userManager)
        {
            _db = dbTravelQueries;
            _dbU = dbUserQueries;
            _userManager = userManager;
        }
        public IList<Travel> Travel { get; set; }
        public string UserEmail { get; set; }
        public async Task OnGetAsync()
        {
            Travel = await _db.ReadAll();
            string userId = _userManager.GetUserId(User);
            var UserFromDb = _dbU.Read(userId);

            if(UserFromDb != null)
            {
                UserEmail = UserFromDb.Email;
            }
        }
    }
}
