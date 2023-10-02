using System;
using System.Text.RegularExpressions;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nome = new string[2];

            float[] preco = new float[2];

            bool[] desconto = new bool[2];

            string promocao;

            char opcaoMenu;

            static bool ValidarStringLetra(string texto){
                if (Regex.IsMatch(texto, @"\d+$") || string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            do
            {
                Console.WriteLine($"Selecione uma opção:");
                Console.WriteLine($"1 - Cadastro");
                Console.WriteLine($"2 - Listar");
                Console.WriteLine($"0 - Sair");
                
                opcaoMenu = char.Parse(Console.ReadLine());
                Console.Clear();
            

                switch (opcaoMenu)
                {
                    case '1':
                    for (var i = 0; i < 2; i++)
                    {
                        do
                        {
                        Console.WriteLine($"Qual o nome do produto ?");
                        nome[i] = Console.ReadLine().Trim(' ');
                        } while (ValidarStringLetra(nome[i]));
                        
                        
                        Console.WriteLine($"Qual o preco do produto ?");
                        preco[i] = float.Parse(Console.ReadLine());

                        Console.WriteLine($"O produto esta em promocao ? S/N");
                        promocao = Console.ReadLine();
                        if (promocao == "s")
                        {
                            desconto[i] = true;
                        }
                        else
                        {
                            desconto[i] = false;
                        }
                        
                    }
                        break;

                    case '2':

                    for (var i = 0; i < 2; i++)
                    {
                        Console.WriteLine
                        (@$"Nome do produto: {nome[i]};
                        Preco do produto: {preco[i].ToString("C2")}; 
                        Esta em promocao ? {(promocao = (desconto[i]) ? "Sim" : "Nao")}
                        ");
                    }                

                        break;

                    case '0':
                        Console.WriteLine($"Encerrando programa...");
                    
                        break;

                    default:
                        Console.WriteLine($"Algo foi digitado incorretamente, favor digite novamente!");
                    
                        break;
                }

            } while (opcaoMenu != '0');
            
        }
    }
}