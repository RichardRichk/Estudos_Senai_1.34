using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int AnoAniversario;
            int MesAniversario;
            int DiaAniversario;

            Console.WriteLine("Ola, escreva o ano do seu aniversario:");
            AnoAniversario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ola, escreva o mes do seu aniversario:");
            MesAniversario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ola, escreva o dia do seu aniversario:");
            DiaAniversario = int.Parse(Console.ReadLine());

            if (AnoAniversario > 2013 || MesAniversario > 12 || DiaAniversario > 31)
            {
                Console.WriteLine($"Data invalida, escreva novamente");            
            }
            else
            {
                Console.WriteLine($"Vamos continuar o Cadastro...");
                
            }
            
        }
    }
}
