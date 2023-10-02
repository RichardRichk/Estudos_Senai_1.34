using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ola, vamos descobrir qual time venceu a partida!\nMe informe a quantidade de gols do time 1 ?");
            int time1 = int.Parse(Console.ReadLine());

            Console.WriteLine($"Muito bem!\nAgora me informe os gols do time 2 ?");
            int time2 = int.Parse(Console.ReadLine());

            if (time1 == time2)
            {
                Console.WriteLine($"Time 1 e time 2 empataram a partida");               
            }
            else if (time1 > time2)
            {
                Console.WriteLine($"Time 1 venceu a partida contra o Time 2");             
            }
            else
            {
                Console.WriteLine($"Time 2 venceu a partida contra o Time 1");
                
            }

            
        }
    }
}
