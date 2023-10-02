using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // Atividade 1
            // Console.WriteLine("Ola, vamos calcular sua idade em meses, dias, horas e minutos!!!\nPara comecarmos, Qual seu nome ?");
            // string nome = (Console.ReadLine());

            // Console.WriteLine("Quantos anos voce tem ?");
            // int anos = Convert.ToInt32(Console.ReadLine());

            // float meses = (anos * 12);

            // float dias = (anos * 365);

            // float horas = (dias * 24);

            // float minutos = (horas * 60);

            // Console.WriteLine($"{nome} Sua Idade detalhada e de {anos} anos, {meses} meses, {dias} dias, {horas} horas e {minutos} minutos, ainda esta muito novo!");

            //Atividade 2
            // Console.WriteLine("Ola, vamos calcular suas notas!!!\nPara comecarmos, Qual seu nome ?");
            // string nome = Console.ReadLine();

            // Console.WriteLine("Qual sua primeira nota ?");
            // float nota1 = float.Parse(Console.ReadLine());

            // Console.WriteLine("Qual sua segunda nota ?");
            // float nota2 = float.Parse(Console.ReadLine());

            // Console.WriteLine("Qual sua terceira nota ?");
            // float nota3 = float.Parse(Console.ReadLine());

            // Console.WriteLine("Qual sua quarta nota ?");
            // float nota4 = float.Parse(Console.ReadLine());

            // Console.WriteLine("Qual sua quinta nota ?");
            // float nota5 = float.Parse(Console.ReadLine());

            // float media = ((nota1 + nota2 + nota3 + nota4 + nota5) / 5);

            // Console.WriteLine($"{nome} Sua media de notas e de {media}\ncontinue estudando!!!");


            //Exercicio 3

            Console.WriteLine("Ola, vamos calcular sua idade em anos e semanas!!!\nPara comecarmos, Qual seu nome ?");
            string nome = Console.ReadLine();

            Console.WriteLine("Em qual ano voce nasceu ?");
            int ano = Convert.ToInt32(Console.ReadLine());

            float idade = (DateTime.Now.Year - ano);

            float IdadeSemanas = (idade * 52);

            Console.WriteLine($"{nome} voce tem {idade} Anos e {IdadeSemanas} Semanas!!!");
            
        }
    }
}
