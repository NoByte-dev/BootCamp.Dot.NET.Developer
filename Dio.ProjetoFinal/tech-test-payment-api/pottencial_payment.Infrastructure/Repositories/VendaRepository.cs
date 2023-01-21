using Microsoft.EntityFrameworkCore;
using pottencial_payment.Domain.Entities;
using pottencial_payment.Domain.Interface.Repositories;
using pottencial_payment.Infrastructure.Context;
using System.Linq.Expressions;

namespace pottencial_payment.Infrastructure.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly AppDbContext _context;

        public VendaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Venda venda)
        {
            await _context.Vendas.AddAsync(venda);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Venda>> ToListAsync()
        {
            return await _context.Vendas.ToListAsync();
        }

        public async Task<Venda> FindAsync(int id)
        {
            return await _context.Vendas.FindAsync(id);
        }
        public async Task<Venda> FindAsync(Expression<Func<Venda, bool>> expression)
        {
            return await _context.Vendas.FirstOrDefaultAsync(expression);
        }
        public async Task<Venda> FindAsNoTrackingAsync(Expression<Func<Venda, bool>> expression)
        {
            return await _context.Vendas.AsNoTracking().FirstOrDefaultAsync(expression);
        }
        public async Task UpdateAsync(Venda venda)
        {
            _context.Vendas.Update(venda);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Venda venda)
        {
            _context.Vendas.Remove(venda);
            await _context.SaveChangesAsync();
        }
    }
}
