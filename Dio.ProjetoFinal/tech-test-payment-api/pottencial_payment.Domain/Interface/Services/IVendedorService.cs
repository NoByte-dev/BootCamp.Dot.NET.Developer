using pottencial_payment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pottencial_payment.Domain.Interface.Services
{
    public interface IVendedorService
    {
        Task AdicionarAsync(Vendedor vendedor);
        Task<IEnumerable<Vendedor>> ObterListaAsync();
        Task<Vendedor> ObterPorIdAsync(int id);
        Task AtualizarAsync(Vendedor vendedor);
        Task DeletarAsync(int id);

    }
}
