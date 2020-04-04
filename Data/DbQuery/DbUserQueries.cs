using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelUp.Data.DbQuery.AuxiliaryClasses;
using TravelUp.Model;

namespace TravelUp.Data.DbQuery
{
    public class DbUserQueries:IDbUserQueries
    {
        private ApplicationDbContext _dbCtx;
        public DbUserQueries(ApplicationDbContext applicationDbContext)

        {
            _dbCtx = applicationDbContext;
        }
        public async Task<User> Create(User item)
        {
            await _dbCtx.Users.AddAsync(item);
            await SaveChangesAsync();
            return item;
        }

        public async Task<User> DeleteById(string id)
        {
            if (id == null)
            {
                return null;
            }
            var user = _dbCtx.Users.Where(c => c.Id == id)
                                   .FirstOrDefault();
            if (user == null)
                return null;

            _dbCtx.Users.Remove(user);
            await SaveChangesAsync();
            return user as User;
        }

        public async Task<User> DeleteByItem(User item)
        {
            if (item == null)
                return null;

            _dbCtx.Users.Remove(item);
            await SaveChangesAsync();

            return item;
        }
        public async Task<User> TrackItem(string id)
        {
            if (id == null)
            {
                return null;
            }
            return await _dbCtx.AllUsers.Include(c => c.OnFavouriteList)
                                        .Include(c => c.OnVisitedList)
                                        .Where(c => c.Id == id)
                                        .FirstOrDefaultAsync();
        }
        public User Read(string id)
        {
            if (id == null)
            {
                return null;
            }
            return _dbCtx.AllUsers
                .Include(c => c.OnFavouriteList).ThenInclude(c => c.Travel).ThenInclude(c => c.Author)
                .Include(c => c.OnVisitedList).ThenInclude(c => c.Travel).ThenInclude(c => c.Author)
                .Where(c => c.Id.Equals(id.ToString())).FirstOrDefault();
        }
        public async Task<List<User>> ReadAll()
        {
            return await _dbCtx.AllUsers
                .Include(c => c.OnFavouriteList).ThenInclude(c => c.Travel).ThenInclude(c => c.Author)
                .Include(c => c.OnVisitedList).ThenInclude(c => c.Travel).ThenInclude(c => c.Author)
                .ToListAsync();
        }

        public async Task<User> UpdateById(string id, User item)
        {
            if (id == null)
            {
                return null;
            }
            User oldUser = _dbCtx.AllUsers.Where(c => c.Id.Equals(id.ToString()))
                                          .FirstOrDefault();

            if (oldUser != null)
            {
                oldUser.OnFavouriteList = item.OnFavouriteList;
                oldUser.OnVisitedList = item.OnVisitedList;
                await SaveChangesAsync();

                return oldUser;
            }
            return null;
        }
        public async Task<User> UpdateByObject(User oldItem, User newItem)
        {
            _dbCtx.Users.Update(oldItem);
            oldItem.OnVisitedList = newItem.OnVisitedList;
            oldItem.OnFavouriteList = newItem.OnFavouriteList;
            await SaveChangesAsync();
            return oldItem;
        }
        public async Task SaveChangesAsync()
        {
            await _dbCtx.SaveChangesAsync();
        }
    }
}
