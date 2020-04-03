using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelUp.Data.DbQuery.AuxiliaryClasses;
using TravelUp.Model;

namespace TravelUp.Data.DbQuery
{
    public class DbVisitedMTMQueries: IDbVisitedMTMQueries
    {
        private ApplicationDbContext _dbCtx;
        public DbVisitedMTMQueries(ApplicationDbContext applicationDbContext)
        {
            this._dbCtx = applicationDbContext;
        }
        public async Task Create(TravelUserVisitedList item)
        {
            await _dbCtx.TravelUserVisMTMs.AddAsync(item);
            await SaveChangesAsync();
        }
        public async Task Delete(string idUser)
        {
            var objToDelete = _dbCtx.TravelUserVisMTMs.Where(c => c.UserId == idUser).FirstOrDefault();
            _dbCtx.TravelUserVisMTMs.Remove(objToDelete);
            await SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbCtx.SaveChangesAsync();
        }
    }
}
