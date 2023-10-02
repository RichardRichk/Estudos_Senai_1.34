using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosProjeto
{
    public class Login
    {
        public bool Logado;

        Usuario user = new Usuario();
        
        public Login(){

            do{
                Console.Clear();

                MenuInicial();

                if (Logado)
                {
                    GerarMenu();
                }
                else
                {
                    Console.WriteLine($"Usuario nao cadastrado!!!");
                    Console.WriteLine($"Voltando para o menu inicial...");
                    Thread.Sleep(2000);
                    Console.Clear();                 
                }
            }while(user.Email == null || user.Senha == null);

        }
        public void login()
        {

        }

        public void Logar(Usuario usuarios)
        {
            Console.WriteLine($"Insira seu email:");
            string email = Console.ReadLine();

            Console.WriteLine($"Insira sua senha:");
            string senha = Console.ReadLine();
            
            if (email == usuarios.Email && senha == usuarios.Senha)
            {
                this.Logado = true;
                Console.WriteLine($"Login efetuado com sucesso!");
                GerarMenu();
            }
            else
            {
                this.Logado = false;
                Console.WriteLine($"Falha ao logar!");    

                Console.WriteLine($"Voltando para o menu inicial...");
                Thread.Sleep(2000);
                Console.Clear();  

                MenuInicial();            
            }
        }

        public void Deslogar(Usuario usuario)
        {
            Logado = false;
            Console.WriteLine($"Voltando para menu inicial...");
            Thread.Sleep(2000);
            Console.Clear();

            MenuInicial();
        }

        public void GerarMenu()
        {
            Produto produto = new Produto();
            Marca marca = new Marca();
            string opcao;

            do{
                Console.WriteLine
                (@$"
                [1] - Cadastrar Produto
                [2] - Listar Produtos
                [3] - Remover Produto
                -------------------------
                [4] - Cadastrar Marca
                [5] - Listar Marcas
                [6] - Remover Marca


                [0] - Voltar para menu inicial.
                ");

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                    produto.Cadastrar();
                        break;

                    case "2":
                    produto.Listar();
                        break;

                    case "3":
                    Console.WriteLine($"Informe o codigo do produto para remove-lo:");
                    int codigoProduto = int.Parse(Console.ReadLine());
                    
                    produto.Deletar(codigoProduto);
                        break;

                    case "4":
                    marca.CadastrarMarca();
                        break;

                    case "5":
                    marca.Listar();
                        break;

                    case "6":
                    Console.WriteLine($"Informe o codigo da marca para remove-la:");
                    int codigoMarca = int.Parse(Console.ReadLine());
                    
                    marca.DeletarMarca();
                        break;

                    case "0":
                    Console.WriteLine($"Voltando para menu inicial...");
                    Thread.Sleep(2000);
                    Console.Clear();

                    MenuInicial();
                        break;

                    default:
                    Console.WriteLine($"opcao invalida");  
                        break;
                }
            }while(opcao != "0");
            
        }

        public void MenuInicial()
        {
            Console.WriteLine
            (@$"
            [1] - Login;
            [2] - Cadastrar;

            [0] - Sair do programa.
            ");

            int escolhaMenuInicial = int.Parse(Console.ReadLine());

            switch (escolhaMenuInicial)
            {
                case 1:
                Logar(user);
                    break;
                
                case 2:
                user.CadastrarUser();
                Logado = true;
                    break;
                
                case 0:
                Console.WriteLine($"Saindo do programa...");
                Thread.Sleep(2000);
                Console.Clear();
                Environment.Exit(0);
                    break;
                default:
                Console.WriteLine($"Opcao nao cadastrada! Digite novamente!");
                Thread.Sleep(1200);
                Console.Clear();
                    break;
            }
            
        }
    }
}