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
            Console.WriteLine("\n\n=== SuperClean - App de Limpeza Residencial ===");
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

            if (input == "1")
            {
                Console.WriteLine("Username: ");
                string username = Console.ReadLine();

                Console.WriteLine("Nome da residência:");
                string nomeResidencia = Console.ReadLine();
                appLimpeza.AdicionarUtilizador(username, nomeResidencia);

            }
            else if (input == "2")
            {
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                Console.WriteLine("Nome do Piso:");
                string nomePiso = Console.ReadLine();
                appLimpeza.AdicionarPiso(username, nomePiso);
            }
            else if (input == "3")
            {
                Console.WriteLine("Editar Piso:");
            }
            else if (input == "4")
            {
                Console.WriteLine("Apagar Piso:");
            }
            else if (input == "5")
            {
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                Console.WriteLine("Nome do Piso:");
                string nomePiso = Console.ReadLine();
                Console.WriteLine("Que Divisão pretende adicionar?");
                string nomeDivisao = Console.ReadLine();
                Console.WriteLine("Qual o tempo de limpeza em minutos?");
                int cleantime = int.Parse(Console.ReadLine());
                Console.WriteLine("De quantos em quantos dias quer esta divisão limpa?");
                int cleaninterval = int.Parse(Console.ReadLine());
                appLimpeza.AdicionarDivisao(username, nomePiso, nomeDivisao, cleantime, cleaninterval);
            }
            else if (input == "6")
            {
                Console.WriteLine("Editar Divisao");
            }
            else if (input == "7")
            {
                Console.WriteLine("Apagar Divisao");
            }
            else if (input == "8")
            {
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                Console.WriteLine("Nome do Piso:");
                string nomePiso = Console.ReadLine();
                Console.WriteLine("Nome da Divisão:");
                string nomeDivisao = Console.ReadLine();
                appLimpeza.MarcarDivisaoComoLimpa(username,nomePiso,nomeDivisao);
                
            }
            else if(input == "9")
            {
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                Console.WriteLine("Nome do Piso:");
                string nomePiso = Console.ReadLine();
                Console.WriteLine("Nome da Divisão:");
                string nomeDivisao = Console.ReadLine();
                appLimpeza.MarcarDivisaoComoSuja(username, nomePiso, nomeDivisao);
            }
            else if (input == "10")
            {
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                appLimpeza.VizualizarEstruturaResidencia(username);
            }
            else if (input == "11")
            {
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                appLimpeza.VisualizarEstadoDeLimpeza(username);
            }
            else if (input == "12")
            {
                Console.WriteLine("Gravar informação de ficheiro");
            }
            else
            {
                Console.WriteLine("Opção Inválida. Tente novamente\n");
            }

        }
        
    }
}


