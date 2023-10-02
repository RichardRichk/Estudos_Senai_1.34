using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ola, Nos informe a Senha para garantir seu acesso:");
            int senha = int.Parse(Console.ReadLine());

            if (senha == 1234)
            {
                Console.WriteLine($"ACESSO    PERMITIDO");   
            }
            else
            {
                Console.WriteLine($"ACESSO    NEGADO");              
            }
        }
    }
}
