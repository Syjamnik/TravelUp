using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelUp;
using TravelUp.Model;

namespace TravelUp.Pages.Travels
{
    public class DeleteModel : PageModel
    {
        private readonly TravelUp.ApplicationDbContext _context;

        public DeleteModel(TravelUp.ApplicationDbContext context)
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

            Travel = await _context.Travels.FirstOrDefaultAsync(m => m.Id == id);

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

            Travel = await _context.Travels.FindAsync(id);

            if (Travel != null)
            {
                _context.Travels.Remove(Travel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
