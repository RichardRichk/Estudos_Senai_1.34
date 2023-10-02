using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char Operacao;
            float numero;
            float numero1;
            float resultado;

            Console.WriteLine(@$"
            |===================================== |
            |       Vamos Fazer Calculos!          | 
            |                                      |
            | Informe a operacao desejada:         |
            | '+' Para adicao;                     | 
            | '-' Para subtracao;                   |
            | '*' Para multiplicacao;              |
            | '/' Para divisao.                    |
            |                                      |
            |===================================== | 
            ");
            Operacao = char.Parse(Console.ReadLine());

            Console.WriteLine($"Informe o Primeiro numero:");
            numero = float.Parse(Console.ReadLine());

            Console.WriteLine($"Informe o Segundo numero:");
            numero1 = float.Parse(Console.ReadLine());

            switch (Operacao)
            {
                case '+':
                resultado = (numero + numero1);
                Console.WriteLine($"O resultado e {resultado.ToString("F2")}");               
                    break;

                case '-':
                resultado = (numero - numero1);
                Console.WriteLine($"O resultado e {resultado.ToString("F2")}");
                    break;

                case '*':
                resultado = (numero * numero1);
                Console.WriteLine($"O resultado e {resultado.ToString("F2")}");
                    break;

                case '/':
                resultado = (numero / numero1);
                Console.WriteLine($"O resultado e {resultado.ToString("F2")}");
                    break;
                
                default:
                Console.WriteLine($"A operacao digitada nao corresponde a nenhuma operacao realizavel pela calculadora!");
                
                    break;
            }
            
            
        }
    }
}