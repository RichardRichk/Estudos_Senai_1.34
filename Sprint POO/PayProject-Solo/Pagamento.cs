using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagamento_Solo
{
    public class Pagamento
    {
        public DateTime Data = DateTime.Today;

        public float Valor;

        //Metodos
        public void DataVencimento(){
            Console.WriteLine($"Data de vencimento do boleto: {Data.ToString("dd/MM/yyyy")}");        
        }

        public void ReceberValor(){
            Valor = float.Parse(Console.ReadLine());
        }

        public string CancelarOperacao(){
            Console.WriteLine($"Cancelando operacao...");
            Thread.Sleep(1250);
            Console.WriteLine($"Voltando para menu inicial...");
            Thread.Sleep(2000);
            Console.Clear();
            return "";
        }
    }
}