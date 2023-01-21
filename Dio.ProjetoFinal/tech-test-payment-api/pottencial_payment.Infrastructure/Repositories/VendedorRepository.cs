using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using pottencial_payment.Domain.Entities;
using pottencial_payment.Domain.Interface.Repositories;
using pottencial_payment.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace pottencial_payment.Infrastructure.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly AppDbContext _context;

        public VendedorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Vendedor vendedor)
        {
            await _context.Vendedores.AddAsync(vendedor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Vendedor>> ToListAsync()
        {
            return await _context.Vendedores.ToListAsync();
        }

        public async Task<Vendedor> FindAsync(int id)
        {
            return await _context.Vendedores.FindAsync(id);
        }
        public async Task<Vendedor> FindAsync(Expression<Func<Vendedor, bool>> expression)
        {
            return await _context.Vendedores.FirstOrDefaultAsync(expression);
        }
        public async Task<Vendedor> FindAsNoTrackingAsync(Expression<Func<Vendedor, bool>> expression)
        {
            return await _context.Vendedores.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task UpdateAsync(Vendedor vendedor)
        {
            _context.Vendedores.Update(vendedor);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Vendedor vendedor)
        {
            _context.Vendedores.Remove(vendedor);
            await _context.SaveChangesAsync();
        }
    }
}
