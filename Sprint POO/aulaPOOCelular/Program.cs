using aulaPOOCelular;
internal class Program
{
    private static void Main(string[] args)
    {
        Celulares celular = new Celulares();

        Console.WriteLine($"Ola, qual a cor do celular achado ?");
        celular.Cor = Console.ReadLine();

        Console.WriteLine($"E qual o modelo ?");
        celular.Modelo = Console.ReadLine();

        Console.WriteLine($"Qual o tamanho ? (P/M/G)");
        celular.Tamanho = char.Parse(Console.ReadLine().ToLower());

            Console.WriteLine($"O celular esta Desligado ? (S/N)");
            celular.OpcaoDesligado = char.Parse(Console.ReadLine());
            while (celular.OpcaoDesligado != 's' && celular.OpcaoDesligado != 'n'){
                Console.WriteLine($"O celular esta Desligado ? (S/N)");
                celular.OpcaoDesligado = char.Parse(Console.ReadLine());
            }

            //goto
            CelularLigado:

            if (celular.OpcaoDesligado == 'n')
            {
                do
                {
                    // CelularLigado:

                    Console.WriteLine($"No que gostaria de mexer ?");
                    Console.WriteLine
                    (@$"
                    [1] - Fazer ligacao;
                    [2] - Mandar mensagens;
                    [3] - Entrar no banco;
                    [4] - Ver informacoes do celular;

                    [0] - Desligar
                    ");
                    celular.Funcionalidades = char.Parse(Console.ReadLine());
                    
                    switch (celular.Funcionalidades)
                    {
                        case '1':
                        celular.FazerLigacao();
                            break;

                        case '2':
                        celular.EnviarMensagem();
                            break;

                        case '3':
                        Console.WriteLine($"Vai roubar nada teu ordinario!");
                        Thread.Sleep(1500);                   
                            break;

                        case '4':
                        Console.WriteLine
                        (@$"
                        Aqui estao as informacoes do celular:

                        Cor: {celular.Cor};

                        Modelo: {celular.Modelo};

                        Tamanho: {celular.Tamanho};
                        ");
                        Console.WriteLine($"Tecle (ENTER) para confirmar.");
                        Console.ReadKey();                    
                            break;

                        case '0':
                        celular.Desligar();
                            break;
                        default:
                            break;
                    }
                } while (celular.Funcionalidades != '0');

            }
            else
            {
                //CelularDesligado
                do
                {
                Console.WriteLine($"Consegue ligar o celular ? S/N");
                celular.EscolhaLigar = char.Parse(Console.ReadLine());
                if (celular.EscolhaLigar == 's')
                {
                    Console.Clear();
                    celular.OpcaoDesligado = 'n';
                    goto CelularLigado;
                }
                else
                {
                    Console.WriteLine($"Encerrando programa...");
                    Thread.Sleep(1250);
                    return;
                }
                } while (celular.EscolhaLigar != 'n' || celular.EscolhaLigar != 's');
                
            }        
    }
}