using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelUp.Data.DbQuery;
using TravelUp.Model;
using TravelUp.Utility;

namespace TravelUp.Pages.Users
{
    [Authorize(Roles = StaticDetails.AdminAndUser)]
    public class IndexModel : PageModel
    {
        private readonly DbUserQueries _db;

        public IndexModel(DbUserQueries dbUserQueries)
        {
            _db = dbUserQueries;
        }
        [BindProperty]
        public List<User> UserModelList { get; set; }

        public async Task OnGetAsync()
        {
            UserModelList = await _db.ReadAll();
        }
    }
}
