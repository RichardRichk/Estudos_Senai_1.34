using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagamento_Solo
{
    public abstract class Cartao : Pagamento
    {
        public string NumeroCartao;
        public string Bandeira;
        public string Titular;
        public string Cvv;
        
        private char Correto;

        //Metodos
        public abstract void Pagar();

        public string SalvarCartao(){
            
            do{
            Console.Clear();
            Console.WriteLine($"Qual o numero do cartao ?");
            NumeroCartao = Console.ReadLine();
            Console.Clear();

            Console.WriteLine($"Qual a Bandeira do cartao ?");
            Bandeira = Console.ReadLine();
            Console.Clear();

            Console.WriteLine($"Qual o nome do titular do cartao ?");
            Titular = Console.ReadLine();
            Console.Clear();

            Console.WriteLine($"Qual o codigo de seguranca do cartao ?");
            Cvv = Console.ReadLine();
            Console.Clear();

            
            Console.WriteLine
            (@$"
             ==================================================================================
            |                                                                                  |
            |                                                                                  |
                           Numero: {NumeroCartao};                                            
            |                                                                                  |
            |                                                                                  |
                           Bandeira: {Bandeira};                                              
            |                                                                                  |
            |                                                                                  |
                           Nome Do Titular: {Titular};                                        
            |                                                                                  |
            |                                                                                  |
                           Codigo De Seguranca: {Cvv};                                        
            |                                                                                  |
            |                                                                                  |
             ==================================================================================
            ");
            

            Console.WriteLine($"As informacoes acima estao corretas ?");
            Console.WriteLine($"Digite 'S' para Sim e 'N' para Nao");
            Correto = char.Parse(Console.ReadLine());

            Console.Clear();
            }while(Correto == 'n');

            Console.WriteLine($"Salvando cartao...");
            Thread.Sleep(1500);
            Console.Clear();
            
            
            return "Cartao salvo com sucesso!";
            
        }
    }
}