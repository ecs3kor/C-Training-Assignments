using Microsoft.EntityFrameworkCore;

namespace Bosch.eCommerce.Persistance
{
    public interface ICommonRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetDetailsAsync(int id);
        Task<int> InsertAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(int id);
    }
}
