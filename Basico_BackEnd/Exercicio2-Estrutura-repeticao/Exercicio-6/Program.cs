using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ola! Vou lhe mostrar a taboada de todos os numeros de 1 a 10");

            float taboada;

            Console.WriteLine($"Qual numero da taboada voce gostaria de saber ?");
            taboada = float.Parse(Console.ReadLine());

            Console.WriteLine($"Aqui vai a taboada do {taboada}:");
            
            

            for (var i = 1; i <=10; i++)
            {
                Console.WriteLine($"{taboada.ToString("F2")}x{i} = {taboada * i}");                
            }
        }
    }
}
