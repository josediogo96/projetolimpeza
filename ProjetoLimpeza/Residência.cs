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

        public Residencia(string name, string Username)
        {
            if(Username.Length > 8)
            {
                throw new ArgumentException("O Username não pode conter mais de 8 caracteres");
            }
            
            this.Name = name;
            this.Username = Username;
            this.pisos = new List<Piso>();
        }

        // Metodo para adicionar um Piso à Residencia

        public void AdicionarPiso(string nomePiso)
        {
            //Verificar se tem mais de 10 pisos
            if(pisos.Count >= 10)
            {
                throw new ArgumentException("A residencia tem mais de 10 pisos");
            }

            //Verificar se tem pisos com o mesmo nome
            if(pisos.Exists(piso => piso.Name.Equals(nomePiso, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("Já existe um piso com este nome.");
            }

            // Criar um novo piso e adicionar à lista de pisos da residencia

            


        }





    }


}