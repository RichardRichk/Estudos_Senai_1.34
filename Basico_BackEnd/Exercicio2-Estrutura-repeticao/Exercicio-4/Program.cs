using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char sexo;

            char resposta;

            float respostaPositiva = 0;

            float respostaNegativa = 0;

            float feminino = 0;

            float masculino = 0;

            float femininoPositivo = 0;

            float masculinoNegativo = 0;

            float porcentagemHomensNegativo;


            for (var i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Ola Entrevistado {i}, Qual seu sexo ? (Responda F para feminino, e M para masculino)");
                sexo = char.Parse(Console.ReadLine().ToLower().Trim(' '));

                while (sexo != 'f' && sexo != 'm')
                {
                    Console.WriteLine($"Entrevistado {i}, voce digitou um sexo invalido! (Responda F para feminino, e M para masculino)");
                    sexo = char.Parse(Console.ReadLine().ToLower());
                }

                if (sexo == 'f')
                {
                    feminino++;
                }
                else if (sexo == 'm')
                {
                    masculino++;
                }
                
        
                Console.WriteLine($"Certo, e voce conhece a nossa empresa ? (Digite s para Sim e n para Nao)");
                resposta = char.Parse(Console.ReadLine().ToLower().Trim(' '));

                while (resposta != 's' && resposta != 'n')
                {
                    Console.WriteLine($"Entrevistado {i}, voce digitou uma opcao invalida! (Digite s para Sim e n para Nao)");
                    resposta = char.Parse(Console.ReadLine().ToLower());
                }

                if (resposta == 's')
                {
                    respostaPositiva++;
                }
                else if (resposta == 'n')
                {
                    respostaNegativa++;
                }

                if (sexo == 'f' && resposta == 's')
                {
                    femininoPositivo++;
                }
                else if (sexo == 'm' && resposta == 'n')
                {
                    masculinoNegativo++;
                }

            }

            porcentagemHomensNegativo = (masculinoNegativo * 100) / 10;

            Console.WriteLine($"{respostaPositiva} pessoas responderam sim!");

            Console.WriteLine($"{respostaNegativa} pessoas responderam nao!");

            Console.WriteLine($"{femininoPositivo} mulheres que responderam sim!");

            Console.WriteLine($"A porcentagem de homens que responderam nao foi de {porcentagemHomensNegativo.ToString("F2")}%");

            Console.WriteLine($"Foram analisados {masculino} homens!");


        }
    }
}
