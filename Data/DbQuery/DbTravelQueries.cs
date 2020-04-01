using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelUp.Data;
using TravelUp.Model;

namespace TravelUp.Data.DbQuery
{
    public class DbTravelQueries : ICRUD<Travel, int>
    {
        private ApplicationDbContext _dbCtx;
        public DbTravelQueries(ApplicationDbContext dbCtx)
        {
            this._dbCtx = dbCtx;
        }
        public async Task<Travel> Create(Travel item)
        {
            await _dbCtx.AddAsync(item);
            await _dbCtx.SaveChangesAsync();
            return item;
        }

        public Task<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByItem(Travel item)
        {
            throw new NotImplementedException();
        }

        public Travel Read(int id)
        {
            return _dbCtx.AllTravels.Include(c => c.Rating)
                                 .Where(t => t.Id == id)
                                 .FirstOrDefault();
        }
        public async Task<List<Travel>> ReadAll()
        {
            return await _dbCtx.AllTravels.Include(c => c.Rating)
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


                await _dbCtx.SaveChangesAsync();
                return oldTravel;
            }
            else
                return null;
        }

        public async Task<Travel> UpdateByObject(Travel oldItem, Travel newItem)
        {
            _dbCtx.AllTravels.Update(oldItem);
            oldItem = newItem;
            await _dbCtx.SaveChangesAsync();
            return oldItem;
        }

    }
}
