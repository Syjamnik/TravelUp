using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TravelUp.DbQuery;
using TravelUp.Model;

namespace TravelUp.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly DbUserQueries _db;

        public EditModel(DbUserQueries dbUserQueries)
        {
            _db = dbUserQueries;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _db.UpdateById(UserModel.Id, UserModel);

            return RedirectToPage("./Index");
        }


    }
}
