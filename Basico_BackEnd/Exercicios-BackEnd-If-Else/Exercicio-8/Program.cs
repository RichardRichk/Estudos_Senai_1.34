using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float N1;
            float N2;
            float N3;
            float maior;
            float menor;

            Console.WriteLine($"Ola, vamos escrever alguns numeros\nDigite o primeiro numero:");
            N1 = float.Parse(Console.ReadLine());

            Console.WriteLine($"Agora digite o segundo numero:");
            N2 = float.Parse(Console.ReadLine());

            Console.WriteLine($"Agora digite o terceiro numero:");
            N3 = float.Parse(Console.ReadLine());
            
            maior = Math.Max(N1, Math.Max(N2, N3));

            menor = Math.Min(N1, Math.Min(N2, N3));

            Console.WriteLine($"O maior numero e {maior} e o menor numero e {menor}");
            
        }
    }
}
