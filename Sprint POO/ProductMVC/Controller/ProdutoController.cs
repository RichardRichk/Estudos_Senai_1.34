using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMVC.Model;
using ProductMVC.View;

namespace ProductMVC.Controller
{
    public class ProdutoController
    {
        //instanciar objeto Produto e ProdutoView
        Produto produto = new Produto();

        ProdutoView produtoView = new ProdutoView();
        public void ListarProdutos()
        {

            //Listar de produtos chamada pela model
            List<Produto> produtos = produto.Ler();

            produtoView.Listar(produtos);
        }

        //metodo para controlar accesar o cadstro de progtamas]
        public void CadastrarProduto()
        {
            //chama para a view que recen cada onjeto a ser iserido no csv
            Produto novoProduto = produtoView.Cadastrar();


            //chamada para a model para inserir esse onjeto na csv
            produto.Inserir(novoProduto);
        }
    }
}