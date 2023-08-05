using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLimpeza
{
    internal class Divisao
    {
        public string Name { get; private set; }

        public int CleanTime { get; private set; }

        public int CleanInterval { get; private set; }  

        public string Id { get; private set; }

        public bool IsClean { get; private set; }
        
        public bool IsDirty { get; private set; }

        public DateTime LastCleaningDate { get; private set; }

        public Divisao(string name, int cleaningtime, int cleaninterval)
        {
            if (name.Length > 10)
            {
                throw new ArgumentException("O nome da divisão não pode ter mais de 10 caracteres.");
            }

            Name = name;
            CleanTime = cleaningtime;
            CleanInterval = cleaninterval;
            Id = Guid.NewGuid().ToString(); // ID único gerado pelo sistema
            IsClean = false; 
            IsDirty = false;
            LastCleaningDate = DateTime.MinValue; // Inicializa com uma data mínima
        }

        // Metodo para colocar a divisão como limpa
        public void MarcarComoLimpa()
        {
            IsClean = true;
            IsDirty = false;
            LastCleaningDate = DateTime.Now;
            Console.WriteLine($"Divisão '{Name}' marcada como limpa");
        } 

        // Metodo para colocar a divisão como suja
        public void MarcarComoSuja()
        {
            IsClean = false;
            IsDirty = true;
            Console.WriteLine($"Divisão '{Name}' marcada como suja");
        }

        // Metodo para verificar o estado da divisão (limpa, suja, atrasada para limpeza)
        public string VerificarEstadoDaDivisao()
        {
            if(IsClean) 
            {
                return "Verde (Limpa)";    
            }

            else if (IsDirty) 
            {
                return "Vermelho (Sujo)";
            }

            else if (LastCleaningDate != DateTime.MinValue && (DateTime.Now - LastCleaningDate).Days > CleanInterval) 
            {
                return "Vermelho (Atrasado para limpeza)";
            }

            else if ( LastCleaningDate != DateTime.MinValue &&(DateTime.Now - LastCleaningDate).Days >= CleanInterval - 2)
            {
                return "Amarelo (Limpeza próxima)";
            }

            else 
            {
                return "Indefenido";
            }
        }
    }


}
