using Pagamento_Solo;
internal class Program
{
    private static void Main(string[] args)
    {
        Credito credito = new Credito();
        
        Console.Clear();

        Console.WriteLine($"Hello World!");

        credito.Pagar();
                         
    }
}