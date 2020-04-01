using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelUp.Model;

namespace TravelUp.Data.DbQuery
{
    public class DbVisitedMTMQueries
    {
        private ApplicationDbContext _dbContext;
        public DbVisitedMTMQueries(ApplicationDbContext applicationDbContext)
        {
            this._dbContext = applicationDbContext;
        }
        public async Task add(TravelUserVisitedList item)
        {
            await _dbContext.TravelUserVisMTMs.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public List<TravelUserVisitedList> getAll(string UserId)
        {
            return _dbContext.TravelUserVisMTMs.Where(c => c.UserId == UserId).ToList();
        }

        public async Task delete(string idUser)
        {
            var objToDelete = _dbContext.TravelUserVisMTMs.Where(c => c.UserId == idUser).FirstOrDefault();
            _dbContext.TravelUserVisMTMs.Remove(objToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
