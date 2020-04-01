using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelUp.Model;

namespace TravelUp.Data.DbQuery
{
    public class DbFavouriteMTMQueries
    {
        private ApplicationDbContext _dbContext;
        public DbFavouriteMTMQueries(ApplicationDbContext applicationDbContext)
        {
            this._dbContext = applicationDbContext;
        }
        public async Task add(TravelUserFavouriteList item) {
            await _dbContext.TravelUserFaMTMs.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }
        public async Task delete(string idUser){
            var objToDelete=  _dbContext.TravelUserFaMTMs.Where(c => c.UserId == idUser).FirstOrDefault();
            _dbContext.TravelUserFaMTMs.Remove(objToDelete);
            await _dbContext.SaveChangesAsync();
        }

    }
}
