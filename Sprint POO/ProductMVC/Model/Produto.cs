using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMVC.Model
{
    public class Produto
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public float Preco { get; set; }

        //caminho da pasta e do arquivo definido
        private const string PATH = "Database/Produto.csv";

        public Produto()
        {
            //obter o caminho da pasta
           string pasta = PATH.Split("/")[0]; //"Database"


            //se nao existir uma pasta Database, entao cria-se uma
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            //se nao existir um arquivo csv no caminho, entao cria-se um
            if (!File.Exists(PATH))
            {
                File.Create(PATH);
            }

        }


        public List<Produto> Ler()
        {
            //instanciar uma lista de produto
            List<Produto> produtos = new List<Produto>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach (string item in linhas)
            {
               string[] atributos = item.Split(";");

               Produto p = new Produto();

               p.Codigo = int.Parse(atributos[0]);
               p.Nome = atributos[1];
               p.Preco = float.Parse(atributos[2]);

               produtos.Add(p);
            }

            return produtos;
        }

        //metodo para preparar a linha do csv
        public string PrepararLinhasCSV(Produto p)
        {
            return $"{p.Codigo};{p.Nome};{p.Preco}";
        }

        //metodo para inserir produto no arquivo csv
        public void Inserir(Produto p)
        {
            string[] linhas = {PrepararLinhasCSV(p)};

            File.AppendAllLines(PATH, linhas);
        }
    }
}