using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagamento_Solo
{
    public class Credito : Cartao
    {
        Pagamento pagamento = new Pagamento();
        public float Limite {get; private set;} = 0.00f;

        public int parcelas {get; private set;}

        public override void Pagar()
        {
            if (pagamento.Valor > Limite)
            {
                Console.WriteLine($"O valor e maior que seu limite! Voce nao pode realizar a compra!");
                Console.WriteLine($"Voltando para menu inicial...");  
            }
            else
            {
                Console.WriteLine($"O valor sera parcelado em quantas vezes ? (De 1 a 12)");
                parcelas = int.Parse(Console.ReadLine());
                switch (parcelas)
                {
                    case <=6:
                    Console.WriteLine($"Sera cobrado 5% de juros.");                    
                        break;

                    case <=12:
                    Console.WriteLine($"Sera cobrado 8% de juros."); 
                        break;

                    default:
                    Console.WriteLine($"Numero de parcelas nao disponivel! Escreva novamente");                    
                        return;
                }
                            
            }
        }
    }
}