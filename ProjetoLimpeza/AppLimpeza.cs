using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ProjetoLimpeza
{
    public class AppLimpeza
    {
        private List<Residencia> residencias;
        
        public AppLimpeza() 
        {
            residencias = new List<Residencia>();
        }

        //Metodo para adicionar um novo utilizador
        public void AdicionarUtilizador(string username,string nomeResidencia)
        {
            
            if (residencias.Exists(residencia => residencia.Name.Equals(nomeResidencia, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Utilizador '{username}' já existe");
            }

            //Criar uma residência para utilizador 
            Residencia newResidencia = new Residencia(nomeResidencia, username);
            residencias.Add(newResidencia);
            Console.WriteLine(residencias[0].Name);

            Console.WriteLine($"Utilizador '{username}' adicionado com sucesso");
        }

        //Metodo para encontrar um utilizador com base no nome de utilizador
        private Residencia EncontrarUtilizador(string username)
        {
            
            return residencias.Find(resindencia => resindencia.Name.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        //Metodo para adicionar um piso à residencia de um novo utilizador 
        public void AdicionarPiso(string username, string nomePiso)
        {
            Residencia residencia = EncontrarUtilizador(username);
            
            if (residencia != null)
            {
                residencia.AdicionarPiso(nomePiso);
                Console.WriteLine($"Piso '{nomePiso}' adicionado à residência de '{username}' com sucesso");
            }
            else 
            {
                Console.WriteLine($"Utilizador '{username}' não foi encontrado");
            } 
        }

        // Metodo para adicionar uma divisão a um piso da residência de utilizador 

        public void AdicionarDivisao(string username, string nomePiso, string nomeDivisao, int cleaningTime, int cleanInterval)
        {
            Residencia residencia = EncontrarUtilizador(username);
            if (residencia != null ) 
            {
                residencia.AdicionarDivisao(nomePiso, nomeDivisao, cleaningTime, cleanInterval);
                Console.WriteLine($"Divisão '{nomeDivisao}' adicionado ao Piso '{nomePiso}' da residência de '{username}' com sucesso ");
            }
            else
            {
                Console.WriteLine($"Utilizador '{username}' não encontrado");
            }
        }

        // Metodo para marcar uma divisão como limpa na residência de um utilizador

        public void MarcarDivisaoComoLimpa(string username, string nomePiso, string nomeDivisao)
        {
            Residencia residencia = EncontrarUtilizador(username);
            if(residencia != null)
            {
                residencia.MarcarDivisaoComoLimpa(nomePiso, nomeDivisao);
                Console.WriteLine($"Divisão '{nomeDivisao}' no piso '{nomePiso}' da residência de '{username}' marcada como limpa.");
            }
            else
            {
                Console.WriteLine($"Utilizador '{username}' não encontrado");
            }
        }

        //Metodo para marcar uma divisao como suja na residencia de um utilizador 

        public void MarcarDivisaoComoSuja(string username, string nomePiso, string nomeDivisao)
        {
            Residencia residencia = EncontrarUtilizador(username);
            if (residencia != null)
            {
                residencia.MarcarDivisaoComoSuja(nomePiso, nomeDivisao);
                Console.WriteLine($"Divisão '{nomeDivisao}' no piso '{nomePiso}' da residência de '{username}' marcada como suja.");
            }
            else
            {
                Console.WriteLine($"Utilizador '{username}' não encontrado");
            }
        }

        //Metodo para visualizar a estrutura da residencia de um utilizador em formato de arvore

        public void VizualizarEstruturaResidencia(string username)
        {
            Residencia residencia = EncontrarUtilizador(username);
            if (residencia != null)
            {
                residencia.VizualizarEstruturaResidencia();
            }
            else 
            {
                Console.WriteLine($"Utilizador '{username}' não encontrado.");
            }
        }

        //Metodo para visualizar o estado de limpeza das divisoes da residencia de um utilizador

        public void VisualizarEstadoDeLimpeza(string username)
        {
            Residencia residencia = EncontrarUtilizador(username);
            if(residencia != null)
            {
                residencia.VizualizarEstadodeLimpeza();
            }
            else 
            {
                Console.WriteLine($"Utilizador '{username}' não encontrado.");
            }
        }
    }
}
