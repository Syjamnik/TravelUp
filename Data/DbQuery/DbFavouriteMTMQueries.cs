using System.Linq;
using System.Threading.Tasks;
using TravelUp.Data.DbQuery.AuxiliaryClasses;
using TravelUp.Model;

namespace TravelUp.Data.DbQuery
{
    public class DbFavouriteMTMQueries : IDbFavouriteMTMQueries
    {
        private ApplicationDbContext _dbCtx;
        public DbFavouriteMTMQueries(ApplicationDbContext applicationDbContext)
        {
            this._dbCtx = applicationDbContext;
        }
        public async Task Create(TravelUserFavouriteList item)
        {
            await _dbCtx.TravelUserFaMTMs.AddAsync(item);
            await SaveChangesAsync();
        }
        public async Task Delete(string idUser)
        {
            var objToDelete = _dbCtx.TravelUserFaMTMs.Where(c => c.UserId == idUser)
                                                     .FirstOrDefault();
            _dbCtx.TravelUserFaMTMs.Remove(objToDelete);

            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbCtx.SaveChangesAsync();
        }

    }
}
