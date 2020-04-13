using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TravelUp.Data.DbQuery;
using TravelUp.Data.DbQuery.AuxiliaryClasses;
using TravelUp.Model;
using TravelUp.Utility;

namespace TravelUp.Pages.Travels
{
    [Authorize(Roles = StaticDetails.AdminAndUser)]
    public class EditModel : PageModel
    {
        private readonly IDbTravelQueries _db;

        public EditModel(IDbTravelQueries dbTravelQueries)
        {
            _db = dbTravelQueries;
        }

        [BindProperty]
        public Travel Travel { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Travel = _db.Read(id: id.Value);

            if (Travel == null)
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

            var updatedObj= await _db.UpdateById(Travel.Id, Travel);
            if (updatedObj == null)
            {
                return NotFound();
            }
            return RedirectToPage("./Index");
        }
    }
}
