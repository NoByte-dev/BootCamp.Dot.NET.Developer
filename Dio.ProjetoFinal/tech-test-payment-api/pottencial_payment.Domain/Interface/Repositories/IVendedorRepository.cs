using pottencial_payment.Domain.Entities;
using System.Linq.Expressions;

namespace pottencial_payment.Domain.Interface.Repositories
{
    public interface IVendedorRepository
    {
        Task AddAsync(Vendedor vendedor);
        Task<IEnumerable<Vendedor>> ToListAsync();
        Task<Vendedor> FindAsync(int id);
        Task<Vendedor> FindAsync(Expression<Func<Vendedor, bool>> expression);
        Task<Vendedor> FindAsNoTrackingAsync(Expression<Func<Vendedor, bool>> expression);
        Task UpdateAsync(Vendedor vendedor);
        Task RemoveAsync(Vendedor vendedor);
    }
}
