using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char resposta;

            int n1 = 0;
            int n2 = 1;
            int auxiliar;

            Console.WriteLine("Ola! Vou lhe mostrar a sequencia fibonaci, gostaria de ver ? (Digite 's' para Sim e 'n' para Nao)");
            resposta = char.Parse(Console.ReadLine());

            // FIBONACCI COM FOR:

            for (var i = 0; i < length; i++)
            {
                auxiliar = n1;
                n1 = n2;
                n2 = (n1 + auxiliar);

                Console.WriteLine($"{n2}");
                
                
            }





        }
    }
}
