using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TravelUp.Data.DbQuery;
using TravelUp.Data.DbQuery.AuxiliaryClasses;
using TravelUp.Model;
using TravelUp.Services.AuxilaryClasses;
using TravelUp.Utility;

namespace TravelUp.Pages.Travels
{
    [Authorize(Roles = StaticDetails.AdminAndUser)]
    public class CreateModel : PageModel
    {
        private readonly IDbTravelQueries _db;
        private readonly IDbUserQueries _dbU;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IImageManager _imageManager;

        public CreateModel(IDbTravelQueries dbTravelQueries, UserManager<IdentityUser> userManager, IDbUserQueries dbUserQueries,
            IImageManager imageManager)
        {
            _db = dbTravelQueries;
            _dbU = dbUserQueries;
            _userManager = userManager;
            _imageManager = imageManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Travel Travel { get; set; }
        public List<IFormFile> Images { get; set;}
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userId = _userManager.GetUserId(User);

            Travel.Author = _dbU.Read(userId);
            Travel.ImagesAddr = _imageManager.SaveUploadedFiles(Images);

            await _db.Create(Travel);
            return RedirectToPage("./Index");
        }



    }
}
