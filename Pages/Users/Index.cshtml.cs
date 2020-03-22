using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelUp.DbQuery;
using TravelUp.Model;

namespace TravelUp.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly DbUserQueries _db;

        public IndexModel(DbUserQueries dbUserQueries)
        {
            _db = dbUserQueries;
        }

        public IList<User> UserModel { get; set; }

        public async Task OnGetAsync()
        {
            UserModel = await _db.ReadAll();
        }
    }
}
