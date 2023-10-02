using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float AulasAnoLetivo;
            float AulasFaltantes;
            float PorcentagemFaltas;
            float NotaMinimaAprovacao = 7;
            float NotaTirada;
            float NotaTirada1;
            float NotaTirada2;
            double MediaAluno;



            Console.WriteLine("Ola, vamos ver se o aluno passou de ano ou esta reprovado\nQuantas aulas tem por ano?");
            AulasAnoLetivo = float.Parse(Console.ReadLine());

            Console.WriteLine($"Quantas Aulas o aluno faltou ?");
            AulasFaltantes = float.Parse(Console.ReadLine());

            PorcentagemFaltas = ((AulasFaltantes * 100) / AulasAnoLetivo);

            if (PorcentagemFaltas <25)
            {
                Console.WriteLine($"O aluno foi Reprovado pela frequencia de aulas abaixo de 75%.\nSua porcentagem de faltas foi de {PorcentagemFaltas.ToString("F2")}% no ano letivo");
            }
            else if(PorcentagemFaltas >=25)
            {
                Console.WriteLine($"Agora vamos calcular as notas do aluno.\nDigite a primeira nota:");
                NotaTirada = float.Parse(Console.ReadLine());

                Console.WriteLine($"Digite a Segunda Nota:");
                NotaTirada1 = float.Parse(Console.ReadLine());
                
                Console.WriteLine($"Digite a Terceira Nota:");
                NotaTirada2 = float.Parse(Console.ReadLine());

                MediaAluno = ((NotaTirada + NotaTirada1 + NotaTirada2) / 3);

                if (MediaAluno > 7)
                {
                    Console.WriteLine($"Voce foi aprovado com a nota de {MediaAluno.ToString("F2")} Parabens!");
                }
                else
                {
                    Console.WriteLine($"Voce foi reprovado com a nota de {MediaAluno.ToString("F2")}");
                }
            }
            
        }
    }
}
