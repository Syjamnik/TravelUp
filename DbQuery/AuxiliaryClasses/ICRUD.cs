using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model= TravelUp.Model;

namespace TravelUp.DbQuery
{
    interface ICRUD<T>
    {
        public Task<T> Create(T item);
        public T Read(int id);
        public Task<T> UpdateByObject(T oldItem, T newItem);
        public Task<T> UpdateById(int id,T item);
        public Task<bool> DeleteByItem(T item);
        public Task<bool> DeleteById(int id);

    }
}
