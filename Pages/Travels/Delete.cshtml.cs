using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TravelUp.Data;
using TravelUp.Model;
using TravelUp.Utility;

namespace TravelUp.Pages.Travels
{

    [Authorize(Roles = StaticDetails.AdminAndUser)]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Travel Travel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Travel = await _context.AllTravels.FirstOrDefaultAsync(m => m.Id == id);

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

            Travel = await _context.AllTravels.FindAsync(id);

            if (Travel != null)
            {
                _context.AllTravels.Remove(Travel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
