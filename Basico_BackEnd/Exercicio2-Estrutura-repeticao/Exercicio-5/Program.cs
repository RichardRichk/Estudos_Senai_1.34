using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char sexo;
            int Idade;

            int TotalHomens = 0;
            int TotalMulheres = 0;

            int IdadeHomens = 0;
            int IdadeMulheres = 0;

            float MediaIdadeHomens;
            float MediaIdadeMulheres;

            Console.Clear();

            for (var i = 1; i <=4; i++)
            {
                Console.WriteLine($"Ola entrevistado {i}, Qual seu sexo ? (digite 'f' para Sim e 'm' para Nao)");
                sexo = char.Parse(Console.ReadLine().ToLower().Trim(' '));

                while (sexo != 'f' && sexo != 'm')
                {
                    Console.WriteLine($"Entrevistado {i}, voce digitou um sexo invalido, favor digite novamente!\n(digite 's' para Sim e 'n' para Nao)");
                    sexo = char.Parse(Console.ReadLine().ToLower().Trim(' '));
                }    

                if (sexo == 'f')
                {
                    TotalMulheres ++;

                    Console.WriteLine($"Certo, e qual sua idade ?");
                    Idade = int.Parse(Console.ReadLine().ToLower().Trim(' '));

                    IdadeMulheres += Idade;
                }
                else
                {
                    TotalHomens ++;

                    Console.WriteLine($"Certo, e qual sua idade ?");
                    Idade = int.Parse(Console.ReadLine().ToLower().Trim(' '));

                    IdadeHomens += Idade;
                }
        
            }

                MediaIdadeHomens = (IdadeHomens / 2);

                MediaIdadeMulheres = (IdadeMulheres / 2); 

                Console.WriteLine($"A media da idade dos homens e de {MediaIdadeHomens} anos;");

                Console.WriteLine($"A media da idade das mulheres e de {MediaIdadeMulheres} anos.");
                
            
            
                    

        }
    }
}
