using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ola, vamos descobrir se o triangulo e Equilátero, Isósceles ou Escaleno.\nMe informe o tamanho da base do triangulo:");
            float BaseTriangulo = float.Parse(Console.ReadLine());

            Console.WriteLine($"Agora me informe o tamanho do lado direito do triangulo:");
            float DireitaTriangulo = float.Parse(Console.ReadLine());

            Console.WriteLine($"Agora me informe o tamanho do lado esquerdo do triangulo:");
            float EsquerdaTriangulo = float.Parse(Console.ReadLine());

            if(BaseTriangulo == DireitaTriangulo && BaseTriangulo == EsquerdaTriangulo)
            {
                Console.WriteLine($"Este triangulo e Equilátero!");            
            }
            else if(BaseTriangulo != EsquerdaTriangulo && EsquerdaTriangulo != DireitaTriangulo && BaseTriangulo != DireitaTriangulo)
            {
                Console.WriteLine($"Este triangulo e Escaleno");
            }
            else
            {
                Console.WriteLine($"Este triangulo e Isósceles!");
            }


            // else if(BaseTriangulo == DireitaTriangulo && DireitaTriangulo != EsquerdaTriangulo || BaseTriangulo != DireitaTriangulo && DireitaTriangulo == EsquerdaTriangulo || DireitaTriangulo == EsquerdaTriangulo && BaseTriangulo != EsquerdaTriangulo || BaseTriangulo == EsquerdaTriangulo && BaseTriangulo != DireitaTriangulo)
            // {
            //     Console.WriteLine($"Este triangulo e Isósceles!");
            // } 
            // else
            // {
            //     Console.WriteLine($"Este triangulo e Escaleno");
            // } UMA FORMA DIFERENTE DE RESOLVER
            
        }
    }
}
