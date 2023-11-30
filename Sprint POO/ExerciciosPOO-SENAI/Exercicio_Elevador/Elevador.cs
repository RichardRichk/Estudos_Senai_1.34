using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio_Elevador
{
    public class Elevador
    {
        public int AndarAtual { get; set; }

        public int CapacidadeElevador = 7;

        public int QuantidadeLotacao;

        public int AndaresPredio = 5;

        public int EscolhaAndar;

        //METODOS:
        public void Inicializa()
        {
            AndarAtual = 0;

            QuantidadeLotacao = 0;
        }

        public void Entrar()
        {
            if (QuantidadeLotacao >= CapacidadeElevador)
            {
                Console.WriteLine($"Desculpe, o elevador esta lotado, escolha outra opcao.");
            }
            else
            {
                Console.WriteLine($"Uma pessoa entrou no elevador.");

                QuantidadeLotacao++;
            }
        }

        public void Sair()
        {
            if (QuantidadeLotacao == 0)
            {
                Console.WriteLine($"Desculpe, nao tem ninguem no elevador para sair no momento, escolha outra opcao");
            }
            else
            {
                Console.WriteLine($"Uma pessoa saiu no elevador.");
                QuantidadeLotacao--;
            }
        }

        // public void Subir()
        // {
        //     if (AndarAtual >= AndaresPredio)
        //     {
        //         Console.WriteLine($"Desculpe, voce esta no ultimo andar, escolha outr opcao.");
        //     }
        //     else
        //     {
        //         AndarAtual++;
        //         Console.WriteLine($"Subindo para {AndarAtual}º");

        //     }
        // }

        // public void Descer()
        // {
        //     if (AndarAtual == 0)
        //     {
        //         Console.WriteLine($"Desculpe, voce ja esta no terreo, escolha outra opcao.");                
        //     }
        //     else
        //     {
        //         AndarAtual --;
        //         if (AndarAtual == 0)
        //         {
        //             Console.WriteLine($"Descendo para Terreo");                   
        //         }
        //         else
        //         {
        //             Console.WriteLine($"Descendo para {AndarAtual}º");
        //         }
        // 
        // }

        public void SubirDescer(){

                Console.WriteLine($"Qual andar gostaria de ir ?");
                Console.WriteLine
                (@$"
                [0] - Terreo;
                [1] - Primeiro andar;
                [2] - Segundo andar;
                [3] - Terceiro andar;
                [4] - Quarto andar;
                [5] - Quinto andar.
                ");
                EscolhaAndar = int.Parse(Console.ReadLine());

                if (EscolhaAndar == AndarAtual)
                {
                    Console.WriteLine($"Voce ja esta neste andar!");                
                }

                switch (EscolhaAndar)
                {
                    case 0:
                    Console.WriteLine($"indo para o terreo!");
                    AndarAtual = 0;               
                        break;
                    case 1:
                    Console.WriteLine($"indo para o Primeiro andar!");
                    AndarAtual = 1;
                        break;
                    case 2:
                    Console.WriteLine($"indo para o Segundo andar!");
                    AndarAtual = 2;
                        break;
                    case 3:
                    Console.WriteLine($"indo para o Terceiro andar!");
                    AndarAtual = 3;
                        break;
                    case 4:
                    Console.WriteLine($"indo para o Quarto andar!");
                    AndarAtual = 4;
                        break;
                    case 5:
                    Console.WriteLine($"indo para o Quinto andar!");
                    AndarAtual = 5;
                        break;
                    default:
                    Console.WriteLine($"Desculpe, mas esse andar nao existe! Digite novamente!");                
                        break;
                }
        }
        
    }
}
