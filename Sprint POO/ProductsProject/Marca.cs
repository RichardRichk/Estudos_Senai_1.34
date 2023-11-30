using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosProjeto
{
    public class Marca
    {
        public int CodigoMarca { get; set; }

        public string NomeMarca { get; set; }

        public DateTime DataCadastro;

        Random CodigoRandom = new Random();

        public static List<Marca> marcas = new List<Marca>();


        public void CadastrarMarca()
        {
            Marca NewMarca = new Marca();

            Console.WriteLine($"Qual o nome da marca ?");
            NewMarca.NomeMarca = Console.ReadLine();

            Console.Clear();

            Console.WriteLine($"Marca cadastrada com sucesso!!!");
            Console.WriteLine($"");

            NewMarca.CodigoMarca = CodigoRandom.Next(100,1000);
            NewMarca.DataCadastro = DateTime.Today;     

            Console.WriteLine($"Codigo de cadastro: {NewMarca.CodigoMarca}");
            Console.WriteLine($"Data de cadastro: {NewMarca.DataCadastro}");

            Thread.Sleep(1200);
                        
            marcas.Add(NewMarca);
        }

        public void Listar()
        {
            foreach (var x in marcas)
            {
                Console.WriteLine
                (@$"
         ==============================================
                Nome da marca: {x.NomeMarca}
                Codigo da marca: {x.CodigoMarca}
                Data de cadastro: {x.DataCadastro}
         ==============================================
                ");
            }

            Console.WriteLine($"Tecle (Enter) para continuar:");
            while(Console.ReadKey().Key != ConsoleKey.Enter );
        }

        public void DeletarMarca()
        {

        }
    }
}