using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TravelUp.Data.DbQuery;
using TravelUp.Model;
using TravelUp.Utility;

namespace TravelUp.Pages.Travels
{
    [Authorize(Roles = StaticDetails.AdminAndUser)]
    public class CreateModel : PageModel
    {
        private readonly DbTravelQueries _db;

        public CreateModel(DbTravelQueries dbTravelQueries)
        {
            _db = dbTravelQueries;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Travel Travel { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _db.Create(Travel);
            return RedirectToPage("./Index");
        }
    }
}
