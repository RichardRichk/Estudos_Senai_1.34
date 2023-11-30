using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string usuario;
            string senha;

            Console.WriteLine("Ola, vamos criar um usuario e senha!\nDigite seu nome de usuario:");
            usuario = (Console.ReadLine());

            Console.WriteLine($"Agora digite sua senha:\n(A SENHA NAO PODE SER IGUAL AO NOME DE USUARIO)");
            senha = (Console.ReadLine());

            while (senha == usuario)
            {
                Console.WriteLine($"A senha nao pode ser igual ao nome de usuario. Repita o procedimento!\nDigite o nome de usuario:");
                usuario = (Console.ReadLine());
                
                Console.WriteLine($"Agora digite sua senha:\n(A SENHA NAO PODE SER IGUAL AO NOME DE USUARIO)");
                senha = (Console.ReadLine());               
            }

            Console.WriteLine($"Usuario e senha criados!\nBEM VINDO!");
            
            
        }
    }
}
