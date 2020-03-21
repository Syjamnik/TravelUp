using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelUp.Model;

namespace TravelUp.DbQuery
{
    public class DbUserQueries 
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

        public Task<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByItem(User item)
        {
            throw new NotImplementedException();
        }

        public User Read(string id)
        {
            return _dbCtx.Users.Include(c => c.OnFavouriteList)
                .Include(c => c.OnVisitedList)
                .Where(c => c.Id.Equals(id.ToString()))
                .FirstOrDefault();
        }

        public async Task<List<User>> ReadAll()
        {
            return await _dbCtx.Users.ToListAsync();
        }

        public async Task<User> UpdateById(int id, User item)
        {
            var oldUser = _dbCtx.Users.Where(c => c.Id.Equals(id.ToString()))
                                      .FirstOrDefault();
            if(oldUser != null)
            {
                oldUser.OnFavouriteList = item.OnFavouriteList;
                oldUser.OnVisitedList = item.OnVisitedList;
                await _dbCtx.SaveChangesAsync();

                return oldUser;
            }
            return null;
        }
        public async Task<User> UpdateById(String id, User item)
        {
            var oldUser = _dbCtx.Users.Where(c => c.Id.Equals(id.ToString()))
                                      .FirstOrDefault();
            if (oldUser != null)
            {
                oldUser.OnFavouriteList = item.OnFavouriteList;
                oldUser.OnVisitedList = item.OnVisitedList;

                await _dbCtx.SaveChangesAsync();
                return oldUser;
            }
            else
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
    }
}
