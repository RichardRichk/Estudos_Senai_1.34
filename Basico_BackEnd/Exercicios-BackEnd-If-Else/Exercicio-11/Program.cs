using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            char Letra;

            Console.WriteLine("Ola, Digite uma letra do Alfabeto:");
            Letra = char.Parse(Console.ReadLine().ToLower());
            if (Letra == 'a' || Letra == 'e' || Letra == 'i' || Letra == 'o' || Letra == 'u')
            {
                Console.WriteLine($"A Letra digitada foi uma vogal.");
                
            }
            else
            {
                Console.WriteLine($"A Letra digitada e uma consoante.");
                
            }
        }
    }
}
