using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExplorandoExemplos.Models
{
   
    public class Pessoa
    {
        public Pessoa()
        {
            // Console.WriteLine("Digite Nome, confirme com Enter, em seguida Sobrenome");
            // Nome = Console.ReadLine();
            // Sobrenome = Console.ReadLine();
        }
        public Pessoa(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }
        private string _nome;
        private int _idade;
        public string Nome 
        { 
            get => _nome;
            
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Nome inválido");
                }
                _nome = value;
            }
        }
        public string Sobrenome { get; set; }
        public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();
        public int Idade
        {
            get => _idade;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Idade inválida");
                }
                _idade = value;
            }
        }
        public void Apresentar()
        {
            Console.WriteLine($"Nome:{NomeCompleto} Idade:{Idade}");
        }
    }
}