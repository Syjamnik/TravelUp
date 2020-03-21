using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelUp;
using TravelUp.DbQuery;
using TravelUp.Model;

namespace TravelUp.Pages.Travels
{
    public class EditModel : PageModel
    {
        private readonly DbTravelQueries _db;

        public EditModel(DbTravelQueries dbTravelQueries)
        {
            _db = dbTravelQueries;
        }

        [BindProperty]
        public Travel Travel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
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

            await _db.UpdateById(Travel.Id, Travel);

            return RedirectToPage("./Index");
        }
    }
}
