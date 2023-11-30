using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ola, vamos ver o valor gasto na compra das macas\nQuantas macas voce comprou ?");
            float NumeroMacas = float.Parse(Console.ReadLine());

            if (NumeroMacas < 12)
            {
                double ValorDaCompra = (NumeroMacas * 0.30);
                Console.WriteLine($"O valor da compra das macas foi de {ValorDaCompra.ToString("F2")}");
            }
            else
            {
                double ValorDaCompra = (NumeroMacas * 0.25);
                Console.WriteLine($"O valor da compra das macas foi de {ValorDaCompra.ToString("F2")}");
                
            }

        }
    }
}