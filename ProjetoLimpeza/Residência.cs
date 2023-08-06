using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        //Metodo para Editar Piso
        public void EditarPiso(string nomePisoAntigo, string nomePisoNovo)
        {
            Piso pisoParaEditar = pisos.Find(piso => piso.Name.Equals(nomePisoAntigo, StringComparison.OrdinalIgnoreCase));
            if (pisoParaEditar != null)
            {
                pisoParaEditar.Name = nomePisoNovo;
            }
            else
            {
                Console.WriteLine($"Piso '{nomePisoAntigo}' não encontrado.");
            }
 
        }

        //Metodo para apagar um piso
        public bool ApagarPiso(string nomePiso)
        {
            Piso pisoParaApagar = pisos.Find(piso => piso.Name.Equals(nomePiso, StringComparison.OrdinalIgnoreCase));
            if (pisoParaApagar != null)
            {
                pisos.Remove(pisoParaApagar);
                return true;
            }
            return false;
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

        // Metodo para editar divisão

        public void EditarDivisao(string nomePiso, string nomeDivisaoAntiga, string nomeDivisaoNova)
        {
            Divisao divisao = GetDivisao(nomePiso, nomeDivisaoAntiga);
            if (divisao != null) 
            {
                divisao.Name = nomeDivisaoNova;
                Console.WriteLine("Divisão editada com sucesso");
            }
            else 
            {
                Console.WriteLine($"Divisao '{nomeDivisaoAntiga} não encontrada");
            }
        }

        // Metodo para apagar divisão

        public bool ApagarDivisao(string nomePiso, string nomeDivisao)
        {
            Piso piso = GetPiso(nomeDivisao);
            if( piso != null )
            {
                piso.ApagarDivisao(nomeDivisao);

                return true;
            }
            return false;
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
        
        //Metodo para obter uma divisao especifica pelo nome do piso e o nome da divisao
        public Divisao GetDivisao(string nomePiso, string nomeDivisao)
        {
            Piso piso = GetPiso(nomePiso);
            if (piso != null)
            {
                return piso.GetDivisao(nomeDivisao);
            }
            else
            {
                Console.WriteLine("Não foi encontrado nenhum piso com esse nome.");
                return null;
            }
            
        }

        //Metodo para marcar uma divisao como limpa
        public void MarcarDivisaoComoLimpa(string nomePiso, string nomeDivisao)
        {
            Piso piso = GetPiso(nomePiso);
            if(piso != null)
            {
                piso.MarcarDivisaoComoLimpa(nomeDivisao);
            }
            else 
            {
                Console.WriteLine($"A '{nomeDivisao}' está limpa.");
            }
        }

        //Metodo para marcar uma divisao como suja

        public void MarcarDivisaoComoSuja(string nomePiso, string nomeDivisao)
        {
            Piso piso = GetPiso(nomePiso);
            if( piso != null )
            {
                piso.MarcarDivisaoComoSuja(nomeDivisao);
            }
            else 
            {
                Console.WriteLine($"A '{nomeDivisao}' está suja.");
            }
        }

        // Metodo para visualizar a estrutura da residencia em formato de arvore

        public void VizualizarEstruturaResidencia()
        {
            Console.WriteLine($"{Name}");
            foreach(var piso in pisos)
            {
                Console.WriteLine($"    - Piso {piso.Name}");
                foreach(var divisao in piso.GetDivisoes())
                {
                    Console.WriteLine($"    - {divisao.Name}");
                }
            }
        }

        //Metodo para visualizar o estado de limpeza das divisões da residência
        public void VizualizarEstadodeLimpeza()
        {
            Console.WriteLine($"Estado de limpeza da residencia '{Name}': ");
            foreach(var piso in pisos)
            {
                Console.WriteLine($"    Piso '{piso.Name}'");
                foreach(var divisao in piso.GetDivisoes())
                {
                    string estadoLimpeza = divisao.IsClean ? "Limpa" : "Suja";
                    Console.WriteLine($" {divisao.Name}: {estadoLimpeza}");
                }
            }
        }
    }

}