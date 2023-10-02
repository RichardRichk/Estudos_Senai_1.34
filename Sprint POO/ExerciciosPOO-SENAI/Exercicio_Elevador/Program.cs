using Exercicio_Elevador;
internal class Program
{
    private static void Main(string[] args)
    {
        Elevador elevador = new Elevador();

        Console.WriteLine($"Bem vindo ao hotel sem nome, vamos ao elevador!");

        elevador.Inicializa();

        do{
            Console.WriteLine
            (@$"
            Menu inicial:

            [E] - Entrada Elevador;
            [S] - Saida Elevador;

            [F] - Sair do programa;
            
            ");

            elevador.SubirDescer();
        }while( != 'F');
        
        
    }
}