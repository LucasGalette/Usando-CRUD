using static System.Console;
using System;

namespace ConsoleCRUD
{
    class MainClass
    {
        public static void printMenu(String[] options)
        {
            foreach (string item in options)
            {
                WriteLine(item);
            }
            WriteLine("Escolha sua opção:");
        }

        public static void Main(String[] args)
        {
            WriteLine(">>>> CADASTRO DE PESSOAS <<<<");
            String[] options = { "1-Cadastrar",
                                 "2-Editar",
                                 "3-Excluir",
                                 "4-Listar",
                                 "5-Sair"};
            int option = 0;
            while (true)
            {
                printMenu(options);
                try
                {
                    option = Convert.ToInt32(ReadLine());
                }
                catch (System.FormatException)
                {
                    WriteLine("Por favor, didite uma opção entre 1 e " + options.Length);
                    continue;
                }
                catch (Exception)
                {
                    WriteLine("Um erro aconteceu!!");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        Cadastrar();
                        break;
                    case 2:
                        Editar();
                        break;
                    case 3:
                        Excluir();
                        break;
                    case 4:
                        Listar();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        WriteLine("Por favor, didite uma opção entre 1 e " + options.Length);
                        break;
                }
            }
        }

        static List<string> nomes = new List<string>();
        static List<int> idades = new List<int>();
        private static void Cadastrar()
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(">>>> CADASTRO DE PESSOA <<<<\n");
            ResetColor();
            string nome = "";
            WriteLine("Dígite o nome da pessoa:");
            nome = ReadLine();
            int index = nomes.IndexOf(nome);
            if (index >= 0)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Nome já existente");
                ResetColor();
            }
            else
            {
                nomes.Add(nome);
                WriteLine("Dígite a idade da pessoa:");
                idades.Add(Convert.ToInt32(ReadLine()));
            }
        }
        private static void Editar()
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(">>>> EDIÇÃO DE PESSOA <<<<\n");
            ResetColor();
            string nome = "";
            WriteLine("Escreva o nome que você deseja editar:");
            nome = ReadLine();
            int index = nomes.IndexOf(nome);
            if (index >= 0)
            {
                WriteLine(">>>> Regitro que será editado <<<<");
                WriteLine($"Nome: {nomes[index]}");
                WriteLine($"Nome: {idades[index]}\n");
                WriteLine("Digite o nome:");
                nome = ReadLine();
                index = nomes.IndexOf(nome);
                if (index >= 0)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Nome já existente");
                    ResetColor();
                }
                else
                {
                    nomes[index] = nome;
                    WriteLine("Digite a idade:");
                    idades[index] = Convert.ToInt32(ReadLine());
                    WriteLine("Pessoa editada com sucesso!!");
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Registro não encontrado!!!");
                ResetColor();
            }
        }
        private static void Excluir()
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(">>>> EXCLUSÃO DE PESSOA <<<<\n");
            ResetColor();
            string nome = "";
            WriteLine("Escreva o nome que você deseja excluir:");
            nome = ReadLine();
            int index = nomes.IndexOf(nome);
            int soun;
            if (index >= 0)
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine(">>>> Regitro que será excluido <<<<");
                ResetColor();
                WriteLine($"Nome: {nomes[index]}");
                WriteLine($"Idade: {idades[index]}");
                WriteLine("Continuar?");
                WriteLine("1-Sim");
                WriteLine("2-Não");
                soun = Convert.ToInt32(ReadLine());
                if (soun == 1)
                {
                    nomes.RemoveAt(index);
                    idades.RemoveAt(index);
                    WriteLine("Pessoa excluida com sucesso!!");
                }
                else
                {
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine("Exclusão de pessoa cancelada!!");
                    ResetColor();
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Registro não encontrado!!!");
                ResetColor();
            }
        }
        private static void Listar()
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(">>>> LISTAGEM DE PESSOA <<<<\n");
            ResetColor();
            int pos = 0;
            foreach (var item in nomes)
            {
                WriteLine($"Nome: {item}, Idade: {idades[pos]}");
                pos++;
            }
        }
    }
}