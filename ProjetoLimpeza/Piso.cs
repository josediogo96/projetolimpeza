using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLimpeza
{
    public class Piso
    {
        public string Name { get; set; }

        private List<Divisao> divisoes;

        public Piso(string name)
        {
             if (name.Length > 10)
             {
                throw new ArgumentException("O nome do piso não pode ter mais de 10 caracteres.");
             }

            Name = name;
            this.divisoes = new List<Divisao>();
        }

        // Metodo para adicionar nova divisão ao piso

        public void AdicionarDivisao(string nomeDivisao, int cleaningtime, int cleaninterval)
        {
            // Verificar se existe divisão com o mesmo nome
            if(divisoes.Exists(divisao => divisao.Name.Equals(nomeDivisao, StringComparison.OrdinalIgnoreCase))) 
            {
                throw new ArgumentException("Já existe uma divisão com este nome neste piso.");
            }

            // Cria uma nova divisão e adiciona à lista de divisões do piso

            Divisao newdivision = new Divisao(nomeDivisao, cleaningtime, cleaninterval);

            divisoes.Add(newdivision);
        }

        // Metodo para obter todas as divisoes do piso 

        public List<Divisao> GetDivisoes()
        { 
            return divisoes;
        }

        // Metodo para obter uma divisao especifica pelo nome

        public Divisao GetDivisao(string nomedivisao) 
        {
            return divisoes.Find(divisao => divisao.Name.Equals(nomedivisao, StringComparison.OrdinalIgnoreCase));
        }

        // Metodo para marcar uma divisao como limpa 

        public void MarcarDivisaoComoLimpa(string nomeDivisao)
        {
            Divisao divisao = GetDivisao(nomeDivisao);

            if(divisao != null)
            {
                divisao.MarcarComoLimpa();
            }
            
            else
            {
                Console.WriteLine($"A '{nomeDivisao}' não foi encontrada neste piso");
            }
        }

        // Metodo para marcar uma divisao como suja

        public void MarcarDivisaoComoSuja(string nomeDivisao)
        {
            Divisao divisao = GetDivisao(nomeDivisao);

            if (divisao != null)
            {
                divisao.MarcarComoSuja();
            }

            else 
            {
                Console.WriteLine($"A '{nomeDivisao}' não foi encontrada neste piso");
            }
        }
    }
}
