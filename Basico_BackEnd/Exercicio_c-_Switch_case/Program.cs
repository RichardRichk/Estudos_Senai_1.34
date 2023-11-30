using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int Escolha;
            char Escolha_2;

            Here:
            Thread.Sleep(500);
            Console.WriteLine(@$"
            =======================================
            | Eae, qual vai ser a bebida de hoje ? |
            | Temos Essas opcoes:                  | 
            | -Energetico (Digite 1);              | 
            | -Whisky (Digite 2);                  | 
            | -Agua (Digite 3);                    | 
            | -Suco (Digite 4);                    | 
            =======================================
            ");
            Escolha = int.Parse(Console.ReadLine().ToLower());
            
            switch (Escolha)
            {
                case 1:
                    Console.WriteLine($"Saindo um Red Bull");                   
                    break;

                case 2:
                    Console.WriteLine($"Esta bebida acompanha Gelo, aceita ?\n(Digite s para sim) E (digite n para nao)");
                    Escolha_2 = char.Parse(Console.ReadLine().ToLower());
                    if (Escolha_2 == 's')
                    {
                        Console.WriteLine($"Aqui esta seu whisky com gelo!");                        
                    }    
                    else
                    {
                        Console.WriteLine($"Aqui esta seu whisky sem gelo!");
                        
                    }                
                    break;

                case 3:
                    Console.WriteLine($"Saindo uma aguinha");               
                    break;

                case 4:
                    Console.WriteLine($"O suco acompanha gelo, aceita ?\n(Digite s para sim) E (digite n para nao)");
                    Escolha_2 = char.Parse(Console.ReadLine().ToLower());
                        switch (Escolha_2)
                        {
                            case 's':
                                Console.WriteLine($"Aqui esta seu suco natural com gelo!");
                                break;
                            default:
                                Console.WriteLine($"Aqui esta seu suco natural sem gelo!");                               
                                break;
                        }
                                            
                    break;

                default:
                    Thread.Sleep(500);
                    Console.WriteLine($"Voce nao escolheu nenhuma bebida do cardapio, Escolha uma, vamos beber!");
                    goto Here;
                    break;
            }
            
        }  
    }
}
