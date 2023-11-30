using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMVC.Model;

namespace ProductMVC.View
{
    public class ProdutoView
    {
        //metodo para exibir os dados da lista de produtos

        public void Listar(List<Produto> produto)
        {
            Console.Clear();

            foreach (var item in produto)
            {
                Console.WriteLine($"\nCodigo: {item.Codigo}");
                Console.WriteLine($"Nome: {item.Nome}");
                Console.WriteLine($"Preco: {item.Preco:C2}");                            
            }
        }

        public Produto Cadastrar()
        {
            Produto novoProduto = new Produto();

            Console.WriteLine($"Quantos produtos gostaria de cadastrar ?");
            int quantidade = int.Parse(Console.ReadLine());
                
            Console.WriteLine($"Informe o codigo:");
            novoProduto.Codigo = int.Parse(Console.ReadLine());

            Console.WriteLine($"Informe o nome: ");
            novoProduto.Nome = Console.ReadLine();
                
            Console.WriteLine($"Informe o preco: ");
            novoProduto.Preco = float.Parse(Console.ReadLine());

            return novoProduto;
            
            
        }
    }
}