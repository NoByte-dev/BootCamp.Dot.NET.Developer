using pottencial_payment.Domain.Entities;
using pottencial_payment.Domain.Enums;
using pottencial_payment.Domain.Interface.Repositories;
using pottencial_payment.Domain.Interface.Services;
using System.Collections;

namespace pottencial_payment.Domain.Services
{
    public class VendaService : IVendaService
    {
        public readonly IVendaRepository _repository;

        public VendaService(IVendaRepository repository)
        {
            _repository = repository;
        }

        public async Task AdicionarAsync(Venda venda)
        {
            ValidarVenda(venda);
            await _repository.AddAsync(venda);
        }
        public async Task<IEnumerable<Venda>> ObterListaAsync()
        {
            return await _repository.ToListAsync();
        }
        public async Task<Venda> ObterPorIdAsync(int id)
        {


            if (id == null)
                throw new ArgumentNullException($"O id {id} não pode ser nulo");
            else
            {
                var entity = await _repository.FindAsync(x => x.Id == id);
                if (entity == null)
                    throw new ArgumentException("Não foi possível achar o ID" + id);
                return entity;
            }
        }
        public async Task AtualizarAsync(Venda venda)
        {
            ValidarVenda(venda);
                var vendaDb = await _repository.FindAsNoTrackingAsync(x => x.Id == venda.Id);
                if (venda == null)
                    throw new ArgumentException("Essa venda não existe");
                await _repository.UpdateAsync(venda);
        }

        public async Task DeletarAsync(int id)
        {
            if (id == null)
                throw new ArgumentNullException($"O id {id} não pode ser nulo");
            else
            {
                var entity = await _repository.FindAsync(id);
                if (entity == null)
                    throw new ArgumentException("Essa venda não existe");
                await _repository.RemoveAsync(entity);
            }
        }
        public async Task AtualizarStatus(int id, StatusVendaEnum status)
        {
            var entity = await ObterPorIdAsync(id);

            switch (entity.Status)
            {
                case StatusVendaEnum.AguardandoPagamento when status == StatusVendaEnum.PagamentoAprovado:
                case StatusVendaEnum.AguardandoPagamento when status == StatusVendaEnum.Cancelado:
                    entity.Status = status;
                    break;
                case StatusVendaEnum.PagamentoAprovado when status == StatusVendaEnum.EnviadoPraTransportadora:
                case StatusVendaEnum.PagamentoAprovado when status == StatusVendaEnum.Cancelado:
                    entity.Status = status;
                    break;
                case StatusVendaEnum.EnviadoPraTransportadora when status == StatusVendaEnum.Entregue:
                    entity.Status = status;
                    break;
                default:
                    throw new ArgumentException("Alteração de Status Inválida");
            }
            await _repository.UpdateAsync(entity);
        }
        private static void ValidarVenda(Venda venda)
        {
            if (venda.DataVenda == null)
            {
                throw new ArgumentException("Data inválida.");
            }
            if (venda.VendedorId <= 0)
            {
                throw new ArgumentException("Vendedor não econtrado");
            }
            if (venda.Itens.Count <= 0)
            {
                throw new ArgumentException("A quantidade de itens é inválida");
            }
        }
    }
}
