using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelUp.Model;

namespace TravelUp.Data.DbQuery
{
    public class DbUserQueries : ICRUD<User, string>
    {
        private ApplicationDbContext _dbCtx;
        public DbUserQueries(ApplicationDbContext applicationDbContext)

        {
            _dbCtx = applicationDbContext;
        }
        public async Task<User> Create(User item)
        {
            await _dbCtx.AddAsync(item);

            await _dbCtx.SaveChangesAsync();
            return item;
        }

        public Task<bool> DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByItem(User item)
        {
            throw new NotImplementedException();
        }
        public async Task<User> TrackItem(string id)
        {
            return await _dbCtx.AllUsers.Include(c => c.OnFavouriteList)
                                        .Include(c => c.OnVisitedList)
                                        .Where(c => c.Id == id)
                                        .FirstOrDefaultAsync();
        }
        public User Read(string id)
        {
            return _dbCtx.AllUsers
                .Include(c => c.OnFavouriteList)
                    .ThenInclude(c => c.Travel)
                    .ThenInclude(c => c.Author)

                .Include(c => c.OnVisitedList)
                    .ThenInclude(c => c.Travel)
                    .ThenInclude(c => c.Author)
                .Where(c => c.Id.Equals(id.ToString()))
                .FirstOrDefault();
        }
        public async Task<List<User>> ReadAll()
        {
            return await _dbCtx.AllUsers.Include(c => c.OnFavouriteList)
                                        .Include(c => c.OnVisitedList).ToListAsync();
        }

        public async Task<User> UpdateById(string id, User item)
        {
            var oldUser = _dbCtx.AllUsers.Where(c => c.Id.Equals(id.ToString()))
                                      .FirstOrDefault();
            if (oldUser != null)
            {
                oldUser.OnFavouriteList = item.OnFavouriteList;
                oldUser.OnVisitedList = item.OnVisitedList;
                await _dbCtx.SaveChangesAsync();

                return oldUser;
            }
            return null;
        }
        public async Task<User> UpdateByObject(User oldItem, User newItem)
        {
            _dbCtx.Users.Update(oldItem);
            oldItem.OnVisitedList = newItem.OnVisitedList;
            oldItem.OnFavouriteList = newItem.OnFavouriteList;
            await _dbCtx.SaveChangesAsync();
            return oldItem;
        }
        public async void SaveChanges()
        {
            await _dbCtx.SaveChangesAsync();
        }
    }
}
