using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Ler o ano atual e o ano de nascimento de uma pessoa. Escrever uma mensagem que diga se
// ela poderá ou não votar este ano (não é necessário considerar o mês em que a pessoa nasceu).

            int anoNascimento;

            int idadeAtual;

            Console.WriteLine("Ola, qual ano voce nasceu ?");
            anoNascimento = int.Parse(Console.ReadLine().Trim(' '));

            idadeAtual = (DateTime.Now.Year - anoNascimento);

            if (idadeAtual <16)
            {
                Console.WriteLine($"Voce nao pode votar");               
            }
            else if (idadeAtual <=17)
            {
                Console.WriteLine($"Caso queira e tenha o titulo, pode votar");
                
            }
            else if (idadeAtual <70)
            {
                Console.WriteLine($"Voce e obrigado a votar caso nao tenha motivos para nao ir");
                
            }
            else
            {
                Console.WriteLine($"Voce nao e mais obrigado a votar");
                
            }
        }
    }
}
