using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float nota;

            Console.WriteLine("Ola, digite uma nota de 0 a 10:");
            nota = float.Parse(Console.ReadLine());

            while (nota <0 || nota >10)
            {
                Console.WriteLine($"Esta nota e invalida, favor digitar novamente a nota de 0 a 10:");
                nota = float.Parse(Console.ReadLine());                
            }

            Console.WriteLine($"Sua nota foi {nota}");
            
            
        }
    }
}
