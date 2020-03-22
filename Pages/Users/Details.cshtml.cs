using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TravelUp.DbQuery;
using TravelUp.Model;

namespace TravelUp.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly DbUserQueries _db;

        public DetailsModel(DbUserQueries dbUserQueries)
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
