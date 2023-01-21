using pottencial_payment.Domain.Entities;
using pottencial_payment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pottencial_payment.Domain.Interface.Services
{
    public interface IVendaService
    {
        Task AdicionarAsync(Venda venda);
        Task<IEnumerable<Venda>> ObterListaAsync();
        Task<Venda> ObterPorIdAsync(int id);
        Task AtualizarAsync(Venda venda);
        Task DeletarAsync(int id);
        Task AtualizarStatus(int id, StatusVendaEnum status);
    }
}
