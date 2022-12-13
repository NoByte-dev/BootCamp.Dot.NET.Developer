using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExplorandoExemplos.Models
{
   
    public class Pessoa
    {
        private string _nome;
        private int _idade;
        public string Nome 
        { 
            get => _nome.ToLower();
            
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Nome inválido");
                }
                _nome = value;
            }
        }
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
            Console.WriteLine($"Nome:{Nome} Idade:{Idade}");
        }
    }
}