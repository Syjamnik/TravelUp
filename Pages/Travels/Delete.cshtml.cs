using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TravelUp.Data;
using TravelUp.Data.DbQuery;
using TravelUp.Data.DbQuery.AuxiliaryClasses;
using TravelUp.Model;
using TravelUp.Utility;

namespace TravelUp.Pages.Travels
{

    [Authorize(Roles = StaticDetails.AdminAndUser)]
    public class DeleteModel : PageModel
    {
        private readonly IDbTravelQueries _dbT;

        public DeleteModel(IDbTravelQueries dbTravelQueries)
        {
            _dbT = dbTravelQueries;
        }

        [BindProperty]
        public Travel Travel { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Travel = _dbT.Read(id.GetValueOrDefault());

            if (Travel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
               var deletedTravel= await _dbT.DeleteById(id.GetValueOrDefault());

            if (deletedTravel == null)
                return NotFound();

            return RedirectToPage("./Index");
        }
    }
}
