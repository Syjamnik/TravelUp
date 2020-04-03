using System.Collections.Generic;
using System.Threading.Tasks;

namespace TravelUp.Data.DbQuery.AuxiliaryClasses
{
    public interface ICRUD<T, I>
    {
        Task<T> Create(T item);
        Task<T> DeleteById(I id);
        Task<T> DeleteByItem(T item);
        T Read(I id);
        Task<List<T>> ReadAll();
        Task<T> UpdateById(I id, T item);
        Task<T> UpdateByObject(T oldItem, T newItem);
        Task SaveChangesAsync();

    }
}
