using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelUp.Data.DbQuery.AuxiliaryClasses;
using TravelUp.Model;
using TravelUp.Services.AuxilaryClasses;

namespace TravelUp.Data.DbQuery
{
    public class DbTravelQueries: IDbTravelQueries
    {
        private ApplicationDbContext _dbCtx;
        private IImageManager _imageManager;
        public DbTravelQueries(ApplicationDbContext dbCtx, IImageManager imageManager)
        {
            _dbCtx = dbCtx;
            _imageManager = imageManager;
        }
        public async Task<Travel> Create(Travel item)
        {
            await _dbCtx.AddAsync(item);
            await SaveChangesAsync();
            return item;
        }

        public async Task<Travel> DeleteById(int id)
        {

            Travel travel = _dbCtx.AllTravels.Where(c => c.Id == id)
                                             .FirstOrDefault();
            if(travel== null)
            {
                return null;
            }

            _dbCtx.AllTravels.Remove(travel);
            _imageManager.DeleteUploadedFiles(travel.ImagesAddr);
            await SaveChangesAsync();

            return travel;
        }

        public async Task<Travel> DeleteByItem(Travel item)
        {
            if(item== null)
                return null;
                   
            var travelToDelete=_dbCtx.AllTravels.Remove(item);
            _imageManager.DeleteUploadedFiles(item.ImagesAddr);

            await SaveChangesAsync();

            return item;
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
                oldTravel.Author = item.Author;

                await SaveChangesAsync();
                return oldTravel;
            }
            else
                return null;
        }

        public async Task<Travel> UpdateByObject(Travel oldItem, Travel newItem)
        {
            if (oldItem == null || newItem == null)
                return null;

            _dbCtx.AllTravels.Update(oldItem);
            oldItem.Text = newItem.Text;
            oldItem.Header = newItem.Header;
            oldItem.OnVisitedList = newItem.OnVisitedList;
            oldItem.OnFavouriteList = newItem.OnFavouriteList;
            oldItem.Author = newItem.Author;

            await SaveChangesAsync();

            return oldItem;
        }
        public async Task<List<Travel>> DeleteAllTravelsByAuthorId(string id)
        {
            var travelsToDelete = _dbCtx.AllTravels.Where(c => c.Author.Id == id).ToList();
            foreach(var travel in travelsToDelete)
            {
                _dbCtx.AllTravels.Remove(travel);
                _imageManager.DeleteUploadedFiles(travel.ImagesAddr);

            }
            await SaveChangesAsync();
            return travelsToDelete;
        }
        public List<Travel> ReadAllUserTravels(string id)
        {
            return _dbCtx.AllTravels.Where(c => c.Author.Id == id).ToList();
        }

        public async Task SaveChangesAsync()
        {
            await _dbCtx.SaveChangesAsync();
        }


    }
}
