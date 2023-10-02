using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagamento_Solo
{
    public class Debito : Cartao
    {
        Pagamento pagamento = new Pagamento();
        public float Saldo {get; private set;} = 0.00f;
        public override void Pagar()
        {
            if (pagamento.Valor > Saldo)
            {
                Console.WriteLine($"O valor e maior que seu saldo! Voce nao pode realizar a compra!");
                Console.WriteLine($"Voltando para menu inicial...");                
            }
            else
            {
                Console.WriteLine($"Compra realizada, seu saldo agora e de:");
                Console.WriteLine($"{Saldo - pagamento.Valor}");                
            }
        }
    }
}