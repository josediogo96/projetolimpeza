using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLimpeza

{


    public class Residencia
    {
        public string Name { get; private set; }

        private List<Piso> pisos;

        public string Username { get; private set; }

        public Residencia(string name, string username)
        {
            if (username.Length > 8)
            {
                throw new ArgumentException("O Username não pode conter mais de 8 caracteres");
            }

            this.Name = name;
            this.Username = username;
            pisos = new List<Piso>();
        }

        // Metodo para adicionar um Piso à Residencia
        public void AdicionarPiso(string nomePiso)
        {
            //Verificar se tem mais de 10 pisos
            if (pisos.Count >= 10)
            {
                throw new ArgumentException("A residencia tem mais de 10 pisos");
            }

            //Verificar se tem pisos com o mesmo nome
            if (pisos.Exists(piso => piso.Name.Equals(nomePiso, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("Já existe um piso com este nome.");
            }

            // Criar um novo piso e adicionar à lista de pisos da residencia
            Piso newPiso = new Piso(nomePiso);
            pisos.Add(newPiso);
        }

        // Metodo para obter todos os nomes dos pisos de uma residência
        public List<string> GetPisos()
        {
            List<string> nomePisos = new List<string>();
            foreach (var piso in pisos)
            {
                nomePisos.Add(piso.Name);
            }

            return nomePisos;
        }


        // Metodo para obter um piso específico pelo nome
        public Piso GetPiso(string nomePiso)
        {
            return pisos.Find(piso => piso.Name.Equals(nomePiso, StringComparison.OrdinalIgnoreCase));
        }


        // Metodo para adicionar uma nova divisão a um piso de residência

        public void AdicionarDivisao(string nomePiso, string nomeDivisao, int cleaningtime, int cleaninterval)
        {
            Piso piso = GetPiso(nomePiso);
            if (piso != null) 
            {
                piso.AdicionarDivisao(nomeDivisao, cleaningtime, cleaninterval);
            }
            else 
            {
                Console.WriteLine($"'{nomePiso}' não encontrado nesta residência");
            }
        }

        // Metodo para obter todas as divisões de um piso da residência
        public List<Divisao> GetDivisoes(string nomePiso)
        {
            Piso piso = GetPiso(nomePiso);
            if(piso != null)
            {
               return piso.GetDivisoes();
                
            }
            else 
            {
                Console.WriteLine($"Piso '{nomePiso}' não encontrado nesta residencia");
                return new List<Divisao>();
            }
        }
          
    }


}