using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x;

            Console.WriteLine("Ola, vamos descobrir a taboada de um numero!\nDigite o numero desejado");
            x = double.Parse(Console.ReadLine());

            Console.WriteLine($"Vamos te mostrar a taboada do numero {x}:");
            

            for (double i = 0; i <= (x*10); i+=x)
            {
                Console.WriteLine(i);
                
                
            }
        }
    }
}
