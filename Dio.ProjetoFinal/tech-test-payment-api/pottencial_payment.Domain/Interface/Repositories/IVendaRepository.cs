using pottencial_payment.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace pottencial_payment.Domain.Interface.Repositories
{
    public interface IVendaRepository 
    {
        Task AddAsync(Venda venda);
        Task<IEnumerable<Venda>> ToListAsync();
        Task<Venda> FindAsync(int id);
        Task<Venda> FindAsync(Expression<Func<Venda, bool>> expression);
        Task<Venda> FindAsNoTrackingAsync(Expression<Func<Venda, bool>> expression);
        Task UpdateAsync(Venda venda);
        Task RemoveAsync(Venda venda);
    }
}
