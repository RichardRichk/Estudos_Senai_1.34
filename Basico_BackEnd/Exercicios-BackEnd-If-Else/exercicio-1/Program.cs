using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ola, vamos calcular seus gastos\nQual o valor do seu salario ?");
            float SalarioGanho = float.Parse(Console.ReadLine());

            Console.WriteLine($"Quanto voce gastou ?");
            float SalarioGasto = float.Parse(Console.ReadLine());

            float DinheiroRestante = (SalarioGanho - SalarioGasto);

            if(SalarioGanho > SalarioGasto)
            {
                Console.WriteLine($"Gastos dentro do orcamento, voce tem {DinheiroRestante} na sua conta, Continue assim!!!");
                
            }
            else
            {
                Console.WriteLine($"Orcamento Estourado, voce tem {DinheiroRestante} na sua conta, vai trabalhar e paga isso!!!");
                
            }
            
            
        }
    }
}
