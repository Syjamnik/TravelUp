using System.Threading.Tasks;

namespace TravelUp.DbQuery
{
    interface ICRUD<T, I>
    {
        public Task<T> Create(T item);
        public T Read(I id);
        public Task<T> UpdateByObject(T oldItem, T newItem);
        public Task<T> UpdateById(I id, T item);
        public Task<bool> DeleteByItem(T item);
        public Task<bool> DeleteById(I id);

    }
}
