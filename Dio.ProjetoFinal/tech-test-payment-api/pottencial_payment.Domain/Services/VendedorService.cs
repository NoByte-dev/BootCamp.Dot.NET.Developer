using pottencial_payment.Domain.Entities;
using pottencial_payment.Domain.Interface.Repositories;
using pottencial_payment.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace pottencial_payment.Domain.Services
{
    public class VendedorService : IVendedorService
    {
        public readonly IVendedorRepository _repository;

        public VendedorService(IVendedorRepository repository)
        {
            _repository = repository;
        }

        public async Task AdicionarAsync(Vendedor vendedor)
        {
            ValidacaoCpf(vendedor);
            ValidacaoNome(vendedor);
            ValidacaoDeEmail(vendedor);
            ValidacaoDeTelefone(vendedor);
            await _repository.AddAsync(vendedor);
        }

        public async Task<IEnumerable<Vendedor>> ObterListaAsync()
        {
            return await _repository.ToListAsync();
        }
        public async Task<Vendedor> ObterPorIdAsync(int id)
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
        public async Task AtualizarAsync(Vendedor vendedor)
        {
            ValidacaoCpf(vendedor);
            ValidacaoNome(vendedor);
            ValidacaoDeEmail(vendedor);
            ValidacaoDeTelefone(vendedor);
            var VendedorDb = await _repository.FindAsNoTrackingAsync(x => x.Id == vendedor.Id);
            if (vendedor == null)
                throw new ArgumentException("Esse vendedor não existe");
            await _repository.UpdateAsync(vendedor);
        }

        public async Task DeletarAsync(int id)
        {
            if (id == null)
                throw new ArgumentNullException($"O id {id} não pode ser nulo");
            else
            {
                var entity = await _repository.FindAsync(id);
                if (entity == null)
                    throw new ArgumentException("Esse vendedor não existe");
                await _repository.RemoveAsync(entity);
            }
        }
        private static bool ValidarCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
            {
                return false;
            }

            var repetidos = int.Parse(string.Concat(cpf.GroupBy(x => x).Select(x => x.Count())));
            if (repetidos == 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }
            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
        private static void ValidacaoCpf(Vendedor vendedor)
        {
            if (!ValidarCpf(vendedor.Cpf))
                throw new ArgumentException("Cpf informado não é válido");
        }
        private static void ValidacaoNome(Vendedor vendedor)
        {
            if (vendedor.Nome.Length <= 3 || vendedor.Nome.Length >= 40)
            {
                throw new ArgumentException("Nome inválido");
            }
        }
        private static void ValidacaoDeEmail(Vendedor vendedor)
        {
            Regex EmailRegex = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            if (vendedor.Email.Length <= 0)
            {
                throw new ArgumentException("Email não pode ser nulo!");
            }
            if (!EmailRegex.IsMatch(vendedor.Email))
            {
                throw new ArgumentException("Email não corresponde a um email válido!");
            }
        }
        private static void ValidacaoDeTelefone(Vendedor vendedor)
        {
            Regex TelefoneRegex = new Regex(@"^\(?[1-9]{2}\)?\s?(?:[0-9]|9[0-9])[0-9]{3}\-?[0-9]{4}$");
            if (!TelefoneRegex.IsMatch(vendedor.Telefone))
            {
                throw new ArgumentException("Telefone não corresponde a um telefone válido");
            }
        }

    }
}
