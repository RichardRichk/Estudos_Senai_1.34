using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aulaPOOCelular
{
    public class Celulares
    {
        public string Cor;
        public string Modelo;
        public char Tamanho;

        public char OpcaoDesligado;
        public bool Desligado;

        public char OpcaoDesbloqueado;
        public bool Desbloqueado;

        public char EscolhaLigar;

        public char Funcionalidades;


        public char EscolhaLigacao;

        public char EscolhaMensagem;


        public void Ligar(){
            Console.WriteLine($"Ligando...");
            Thread.Sleep(1250);
            Console.WriteLine($"Bem vindo!");                    
        }

        public void Desligar(){
            Console.WriteLine($"Ate logo!");
            Console.WriteLine($"Desligando...");
            Thread.Sleep(1250);
            return;                        
        }

        public void Voltar(){
            Console.WriteLine($"Retornando...");
            Thread.Sleep(1250);
            return;                        
        }

        public void FazerLigacao(){
        do
        {
            Console.WriteLine
            (@$"
            Para quem gostaria de ligar ?
            [1] - Goku;
            [2] - Iron man;
            [3] - Batman; 

            [0] - Voltar;           
            ");
            EscolhaLigacao = char.Parse(Console.ReadLine());
            switch (EscolhaLigacao)
            {
                case '1':
                Console.WriteLine($"Ligando para Goku...");
                Thread.Sleep(1250);
                Console.WriteLine($"Oi, Eu sou o Goku!"); 
                Console.WriteLine($"Tecle (ENTER) para confirmar.");
                Console.ReadKey();               
                    break;

                case '2':
                Console.WriteLine($"Ligando para Iron man...");
                Thread.Sleep(1250);
                Console.WriteLine($"E eu sou... O Homem de Ferro! (som de estalo)"); 
                Console.WriteLine($"Tecle (ENTER) para confirmar.");
                Console.ReadKey(); 
                    break;

                case '3':
                Console.WriteLine($"Ligando para Batman...");
                Thread.Sleep(1250);
                Console.WriteLine($"I am The Batman, ou Bruce Wayne, quem fala ?"); 
                Console.WriteLine($"Tecle (ENTER) para confirmar.");
                Console.ReadKey(); 
                    break;

                case '0':
                this.Voltar();
                    break;

                default:
                Console.WriteLine($"Opcao invalida, digite novamente!");
                Thread.Sleep(1250);
                    break;
            }

        } while (EscolhaLigacao != '0');
            
        }

        public void EnviarMensagem(){
        do
        {
            Console.WriteLine
            (@$"
            Para quem gostaria de Enviar a mensagem ?
            [1] - Goku;
            [2] - Iron man;
            [3] - Batman; 

            [0] - Voltar;           
            ");
            EscolhaMensagem = char.Parse(Console.ReadLine());
            switch (EscolhaMensagem)
            {
                case '1':
                Console.WriteLine($"Escreva sua mensagem...");
                Console.ReadLine();
                Thread.Sleep(1250);
                Console.WriteLine($"Oi, Eu sou o Goku! Mas nao posso falar agora, desculpe!"); 
                Console.WriteLine($"Tecle (ENTER) para confirmar.");
                Console.ReadKey();               
                    break;

                case '2':
                Console.WriteLine($"Escreva sua mensagem...");
                Console.ReadLine();
                Thread.Sleep(1250);
                Console.WriteLine($"E eu sou... O Homem de Ferro! (som de estalo)... Mas nao posso falar agora, desculpe!"); 
                Console.WriteLine($"Tecle (ENTER) para confirmar.");
                Console.ReadKey(); 
                    break;

                case '3':
                Console.WriteLine($"Escreva sua mensagem...");
                Console.ReadLine();
                Thread.Sleep(1250);
                Console.WriteLine($"I am The Batman, ou Bruce Wayne, quem fala ?"); 
                Console.WriteLine($"Tecle (ENTER) para confirmar.");
                Console.ReadKey(); 
                    break;

                case '0':
                this.Voltar();
                    break;

                default:
                Console.WriteLine($"Opcao invalida, digite novamente!");
                Thread.Sleep(1250);
                    break;
            }

        } while (EscolhaMensagem != '0');
            
        }
    }
}