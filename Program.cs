using System;
using System.IO;
namespace Editor
{

    /*simples editar no console c# basico*/
    class Program
    {

        static void Menu()
        {
            System.Console.WriteLine("Bem vindo ao Editor de Texto!");
            System.Console.WriteLine("0 - Para sair");
            System.Console.WriteLine("1- Abri arquivo");
            System.Console.WriteLine("2- Criar novo arquivo");

            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }

        }

        static void Abrir()
        {
            System.Console.WriteLine("Qual o caminho do arquivo:");
            System.Console.WriteLine("ex:: C:/dev/<nome>");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                Console.Clear();
                string text = file.ReadToEnd();
                System.Console.WriteLine(text);
            }
            System.Console.WriteLine("");
            Menu();

        }
        static void Editar()
        {
            Console.Clear();
            System.Console.WriteLine("Digite seu texto (ESC para sair!)");
            System.Console.WriteLine("---------------------------------");
            string text = "";
            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.Clear();
            Salvar(text);

        }
        static void Salvar(string text)
        {
            Console.Clear();
            System.Console.WriteLine(" Qual caminho voçê deseja salvar o arquivo.");
            System.Console.WriteLine("ex:: C:/dev/<nome>");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }
            Console.ReadLine();
            Console.Clear();
            System.Console.WriteLine($"O arquivo [{path}] foi salvo com Secesso!!!");
            System.Console.WriteLine("");
            Menu();
        }


        //================================================================================
        static void Main(string[] args)
        {
            Menu();
        }
        //==============================================================================
    }
}