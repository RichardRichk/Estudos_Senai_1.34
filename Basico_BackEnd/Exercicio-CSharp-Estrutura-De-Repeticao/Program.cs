using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
                //WHILE

            // Console.WriteLine($"Qual sua idade ?");
            // idade = int.Parse(Console.ReadLine());

            // while (idade <0 && idade <=100)
            // {
            //     Console.WriteLine($"insira uma idade valida");
            //     idade = int.Parse(Console.ReadLine()); 
            // }

            // Console.WriteLine($"Qual seu salario ?");
            // salario = float.Parse(Console.ReadLine());

            // while (salario <0)
            // {
            //     Console.WriteLine($"insira um salario valido");
            //     salario = float.Parse(Console.ReadLine());
            // }
            
            // Console.WriteLine($"Qual seu Estado-Civil ?\n(S = solteiro), (C = casado), (V = viuvo), (D = divorciado)");
            // EstadoCivil = char.Parse(Console.ReadLine().ToLower());

            // while (EstadoCivil != 's' || EstadoCivil != 'c' || EstadoCivil != 'v' || EstadoCivil != 'd')
            // {
            //     Console.WriteLine($"insira um Estado-Civil valido\n(S = solteiro), (C = casado), (V = viuvo), (D = divorciado)");
            //     EstadoCivil = char.Parse(Console.ReadLine().ToLower());
            // }

                    //DO WHILE
            
            // bool idadeCerta = false;
            // int idade;

            // Console.WriteLine($"Qual a idade do Richard ?");
            // idade = int.Parse(Console.ReadLine()); 

            // if (idade != 19)
            // {
            //      do
            // {
            //     Console.WriteLine($"Errou, e agora, Qual a idade do Richard ?");
            //     idade = int.Parse(Console.ReadLine());    

            // } while (idade != 19);
            // }


                    //FOR
            
            for (int t = 0; t <=50; t++)
            {
                Console.WriteLine(t);
                
            }

            
            
                
                
        }
    }
}

