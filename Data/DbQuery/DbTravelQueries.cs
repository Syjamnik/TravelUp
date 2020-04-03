using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelUp.Data.DbQuery.AuxiliaryClasses;
using TravelUp.Model;

namespace TravelUp.Data.DbQuery
{
    public class DbTravelQueries: IDbTravelQueries
    {
        private ApplicationDbContext _dbCtx;
        public DbTravelQueries(ApplicationDbContext dbCtx)
        {
            this._dbCtx = dbCtx;
        }
        public async Task<Travel> Create(Travel item)
        {
            await _dbCtx.AddAsync(item);
            await SaveChangesAsync();
            return item;
        }

        public async Task DeleteById(int id)
        {
            Travel travel = _dbCtx.AllTravels.Where(c => c.Id == id)
                                             .FirstOrDefault();
            _dbCtx.AllTravels.Remove(travel);
            await SaveChangesAsync();
        }

        public async Task DeleteByItem(Travel item)
        {
            _dbCtx.AllTravels.Remove(item);
            await SaveChangesAsync();
        }

        public Travel Read(int id)
        {
            return _dbCtx.AllTravels.Include(c => c.Rating)
                                    .Include(c=> c.Author)
                                    .Where(t => t.Id == id)
                                    .FirstOrDefault();
        }
        public async Task<List<Travel>> ReadAll()
        {
            return await _dbCtx.AllTravels.Include(c => c.Rating)
                                          .Include(c => c.Author)
                                          .ToListAsync();
        }
        public async Task<Travel> UpdateById(int id, Travel item)
        {
            Travel oldTravel = _dbCtx.AllTravels.Where(t => t.Id == id)
                                                .FirstOrDefault();

            if (oldTravel != null)
            {
                oldTravel.Text = item.Text;
                oldTravel.Header = item.Header;
                oldTravel.OnVisitedList = item.OnVisitedList;
                oldTravel.OnFavouriteList = item.OnFavouriteList;

                await SaveChangesAsync();
                return oldTravel;
            }
            else
                return null;
        }

        public async Task<Travel> UpdateByObject(Travel oldItem, Travel newItem)
        {
            _dbCtx.AllTravels.Update(oldItem);
            oldItem = newItem;
            await SaveChangesAsync();

            return oldItem;
        }
        public async Task SaveChangesAsync()
        {
            await _dbCtx.SaveChangesAsync();
        }

    }
}
