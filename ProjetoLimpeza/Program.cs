// See https://aka.ms/new-console-template for more information
using ProjetoLimpeza;

class Program
{
    static void Main()
    {
        AppLimpeza appLimpeza = new AppLimpeza();

        bool sair = false;
        while(!sair)
        {
            Console.WriteLine("=== SuperClean - App de Limpeza Residencial ===");
            Console.WriteLine("1 - Criar Utilizador");
            Console.WriteLine("2 - Adicionar Piso");
            Console.WriteLine("3 - Editar Piso");
            Console.WriteLine("4 - Apagar Piso");
            Console.WriteLine("5 - Adicionar Divisão");
            Console.WriteLine("6 - Editar Divisão");
            Console.WriteLine("7 - Apagar Divisão");
            Console.WriteLine("8 - Marcar Divisão como limpa");
            Console.WriteLine("9 - Marcar Divisão como suja");
            Console.WriteLine("10 - Visualizar estrutura da Residência");
            Console.WriteLine("11 - Visualizar estado de limpeza");
            Console.WriteLine("12 - Gravar informação para ficheiro");
            Console.WriteLine("0 - Sair");

            Console.WriteLine("\nDigite uma opção:");
            string input = Console.ReadLine();
        }
        
    }
}


