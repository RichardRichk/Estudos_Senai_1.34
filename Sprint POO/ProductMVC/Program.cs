using ProductMVC.Model;
using ProductMVC.Controller;

internal class Program
{
    private static void Main(string[] args)
    {
        Produto p = new Produto();

        ProdutoController controller = new ProdutoController();

        controller.CadastrarProduto();

        controller.ListarProdutos();
    }
}