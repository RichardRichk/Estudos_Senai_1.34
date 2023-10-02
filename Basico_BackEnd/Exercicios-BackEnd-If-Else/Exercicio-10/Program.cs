using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int NivelDeSuspeita = 0;
            string Resposta;
            string Resposta_1;
            string Resposta_2;
            string Resposta_3;
            string Resposta_4;

            Console.WriteLine("Telefonou para a vitima ?(Responda com sim ou nao)");
            Resposta = (Console.ReadLine().ToLower()); 
                if (Resposta == "sim")
            {   
                NivelDeSuspeita ++;
            }
            
            Console.WriteLine($"Esteve no local do crime?(Responda com sim ou nao)");
                Resposta_1 = (Console.ReadLine().ToLower());
                if (Resposta_1 == "sim")
                {
                    NivelDeSuspeita ++;
                }

            Console.WriteLine($"Mora perto da vítima?(Responda com sim ou nao)");
            Resposta_2 = (Console.ReadLine().ToLower());
                if (Resposta_2 == "sim")
                {
                    NivelDeSuspeita ++;
                }
            
            Console.WriteLine($"Devia para a vítima?(Responda com sim ou nao)");
            Resposta_3 = (Console.ReadLine().ToLower());
                if (Resposta_3 == "sim")
                {
                    NivelDeSuspeita ++;
                }
            
            Console.WriteLine($"Já trabalhou com a vítima?(Responda com sim ou nao)");
            Resposta_4 = (Console.ReadLine().ToLower());
                if (Resposta_4 == "sim")
                {
                    NivelDeSuspeita ++;
                }

                
            
            if (NivelDeSuspeita <=1)
            {
                Console.WriteLine($"Voce e inocente");                
            }
            else if (NivelDeSuspeita == 2)
            {
                Console.WriteLine($"Voce e suspeita");          
            }
            else if (NivelDeSuspeita <=4)
            {
                Console.WriteLine($"Voce e cumplice");
            }
            else
            {
                Console.WriteLine($"Voce e culpado");
                
            }
            
        }
    }
}
