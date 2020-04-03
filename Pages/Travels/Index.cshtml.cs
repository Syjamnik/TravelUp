using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelUp.Data.DbQuery;
using TravelUp.Data.DbQuery.AuxiliaryClasses;
using TravelUp.Model;

namespace TravelUp.Pages.Travels
{
    public class IndexModel : PageModel
    {
        private readonly IDbTravelQueries _db;

        public IndexModel(IDbTravelQueries dbTravelQueries)
        {
            _db = dbTravelQueries;
        }

        public IList<Travel> Travel { get; set; }

        public async Task OnGetAsync()
        {
            Travel = await _db.ReadAll();
        }
    }
}
