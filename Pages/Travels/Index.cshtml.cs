using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TravelUp;
using TravelUp.DbQuery;
using TravelUp.Model;

namespace TravelUp.Pages.Travels
{
    public class IndexModel : PageModel
    {
        private readonly DbTravelQueries _db;

        public IndexModel(DbTravelQueries  dbTravelQueries)
        {
            _db = dbTravelQueries;
        }

        public IList<Travel> Travel { get;set; }

        public async Task OnGetAsync()
        {
            Travel = await _db.ReadAll();
        }
    }
}
