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

namespace TravelUp.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly DbUserQueries _db;

        public IndexModel(DbUserQueries dbUserQueries)
        {
            _db = dbUserQueries;
        }

        public IList<User> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _db.ReadAll();
        }
    }
}
