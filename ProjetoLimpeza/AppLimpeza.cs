using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            if(residencias.Exists(residencias => residencias.Name.Equals(nomeResidencia, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Utilizador '{username}' já existe");
            }

            //Criar uma residência para utilizador 
            Residencia newResidencia = new Residencia(nomeResidencia, username);
            residencias.Add(newResidencia);

            Console.WriteLine($"Utilizador '{username}' adicionado com sucesso");
        }

        //Metodo para encontrar um utilizador com base no nome de utilizador
        private Residencia EncontrarUtilizador(string username)
        {
            return residencias.Find(resindencia => resindencia.Name.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
    }
}
