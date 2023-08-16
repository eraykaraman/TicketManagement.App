using System.Linq.Expressions;
using TicketManagement.App.Data.Entities;

namespace TicketManagement.App.Services.Abstracts
{
    public interface IService<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(object id);
        Task<T?> GetByFilter(Expression<Func<T, bool>> filter);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(object id);
    }
}
