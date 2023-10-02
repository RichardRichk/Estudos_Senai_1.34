using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float raio;
            float diametro;
            double comprimento;
            double area;
            

            Console.WriteLine("Qual o Raio da circunferencia ?");
            raio = float.Parse(Console.ReadLine());
            
            diametro = (raio * 2);

            comprimento = (2 * raio * Math.PI);

            area = (Math.PI * (Math.Pow(raio, 2)));

            Console.WriteLine($"O raio da circunferencia digitado foi de {raio.ToString("F2")};\nO Diametro e de {diametro.ToString("F2")};\nO Comprimento e {comprimento.ToString("F2")};\nE a area e de {area.ToString("F2")}.");
            

        }
    }
}
