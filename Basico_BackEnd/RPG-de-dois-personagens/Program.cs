using RPG_de_dois_personagens;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        Personagens p1 = new Personagens();
        Personagens p2 = new Personagens();

        char escolhaAtaque;
        char escolhaDefesa;

        Console.WriteLine($"Digite o nome do primeiro personagem:");
        p1.nome = Console.ReadLine();

        Console.WriteLine($"Digite a idade do primeiro personagem:");
        p1.idade = int.Parse(Console.ReadLine());

        Console.WriteLine($"Digite o nome da armadura do primeiro personagem:");
        p1.nomeArmadura = Console.ReadLine();

        Console.WriteLine($"Digite o nome da I.A do primeiro personagem:");
        p1.ia = Console.ReadLine();
        Console.Clear();



        Console.WriteLine($"Digite o nome do segundo personagem:");
        p2.nome = Console.ReadLine();

        Console.WriteLine($"Digite a idade do segundo personagem:");
        p2.idade = int.Parse(Console.ReadLine());

        Console.WriteLine($"Digite o nome da armadura do segundo personagem:");
        p2.nomeArmadura = Console.ReadLine();

        Console.WriteLine($"Digite o nome da I.A do segundo personagem:");
        p2.ia = Console.ReadLine();
        Console.Clear();


        Console.WriteLine($"============================");
        Console.WriteLine
        (@$" 
        Primeiro Personagem:
        Nome: {p1.nome}
        Idade: {p1.idade}
        Armadura: {p1.nomeArmadura}
        IA: {p1.ia}
        ");

        Console.WriteLine($"============================");
        

        Console.WriteLine
        (@$"
        Segundo personagem:
        Nome: {p2.nome}
        Idade: {p2.idade}
        Armadura: {p2.nomeArmadura}
        IA: {p2.ia}
        ");
        Console.WriteLine($"============================");


        Console.WriteLine($"Aperte (Enter) para confirmar:");
        Console.ReadLine();

        for (int i = 0; i < 2; i++)
        {

            //Ataque p1 e Defesa p2
            Console.WriteLine($"Vez do personagem {p1.nome} atacar!\nDigite qual opcao deseja:");
            Console.WriteLine
            (@$"
            [1] - Ataque de energia;
            [2] - Ataque com soco.
            ");
            escolhaAtaque = char.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine($"Vez do personagem {p2.nome} Defender!\nDigite qual opcao deseja:");
            Console.WriteLine
            (@$"
            [1] - Defender ataque de energia;
            [2] - Defender ataque com soco;
            [3] - Usar restauracao de armadura.
            ");
            escolhaDefesa = char.Parse(Console.ReadLine());
            Console.Clear();


            if (escolhaAtaque == '1' && escolhaDefesa == '1')
            {
                Console.WriteLine($"{p1.nome} Atacou com energia!"); 
                Console.WriteLine($"{p2.nome} defendeu energia!"); 
                Console.WriteLine($"Nao ouve danos a armadura de {p2.nome}!");
                Console.WriteLine($"");
                
                
            }
            else if (escolhaAtaque == '2' && escolhaDefesa == '2')
            {
                 Console.WriteLine($"{p1.nome} atacou com soco!");
                 Console.WriteLine($"{p2.nome} defendeu soco!");
                 Console.WriteLine($"Nao ouve danos a armadura de {p2.nome}!");
                 Console.WriteLine($"");
                 
            }
            else
            {
                switch (escolhaAtaque)
                {
                case '1':
                    p1.AtacarEnergia();
                    p2.DanoEnergia();                   
                    break;

                case '2':
                    p1.AtacarSoco(); 
                    p2.DanoSoco();                  
                    break;

                default:
                    while (escolhaAtaque != '1' && escolhaAtaque != '2')
                    {
                        Console.WriteLine($"Opcao nao encontrada, Digite novamente:");
                        Console.WriteLine
                        (@$"
                        [1] - Ataque de energia;
                        [2] - Ataque com soco.
                        ");
                        
                        escolhaAtaque = char.Parse(Console.ReadLine());
                    }
                    break;
                }

                switch (escolhaDefesa)
                {
                case '1':
                    Console.WriteLine($"{p2.nome} defendeu energia!");                   
                    break;

                case '2':
                    Console.WriteLine($"{p2.nome} defendeu soco!");                   
                    break;

                case '3':
                    p2.RestaurarArmadura();
                    ;
                    break;

                default:
                    while (escolhaAtaque != '1' && escolhaAtaque != '2' && escolhaAtaque != '3')
                    {
                        Console.WriteLine($"Opcao nao encontrada, Digite novamente:");
                        Console.WriteLine
                        (@$"
                        [1] - Defender ataque de energia;
                        [2] - Defender ataque com soco;
                        [3] - Usar restauracao de armadura.
                        ");
                        
                        escolhaDefesa = char.Parse(Console.ReadLine());
                    }                
                    break;
                }
            }  
            //FIM ataque p1 e Defesa p2  


            //Ataque p2 e Defesa p1
            Console.WriteLine($"Vez do personagem {p2.nome} atacar!\nDigite qual opcao deseja:");
            Console.WriteLine
            (@$"
            [1] - Ataque de energia;
            [2] - Ataque com soco.
            ");
            escolhaAtaque = char.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine($"Vez do personagem {p1.nome} Defender!\nDigite qual opcao deseja:");
            Console.WriteLine
            (@$"
            [1] - Defender ataque de energia;
            [2] - Defender ataque com soco;
            [3] - Usar restauracao de armadura.
            ");
            escolhaDefesa = char.Parse(Console.ReadLine());
            Console.Clear();


            if (escolhaAtaque == '1' && escolhaDefesa == '1')
            {
                Console.WriteLine($"{p2.nome} Atacou com energia!"); 
                Console.WriteLine($"{p1.nome} defendeu energia!"); 
                Console.WriteLine($"Nao ouve danos a armadura de {p1.nome}!");
                Console.WriteLine($"");
                
                
            }
            else if (escolhaAtaque == '2' && escolhaDefesa == '2')
            {
                 Console.WriteLine($"{p2.nome} atacou com soco!");
                 Console.WriteLine($"{p1.nome} defendeu soco!");
                 Console.WriteLine($"Nao ouve danos a armadura de {p1.nome}!");
                 Console.WriteLine($"");
                 
            }
            else
            {
                switch (escolhaAtaque)
                {
                case '1':
                    p2.AtacarEnergia();
                    p1.DanoEnergia();                   
                    break;

                case '2':
                    p2.AtacarSoco(); 
                    p1.DanoSoco();                  
                    break;

                default:
                    while (escolhaAtaque != '1' && escolhaAtaque != '2')
                    {
                        Console.WriteLine($"Opcao nao encontrada, Digite novamente:");
                        Console.WriteLine
                        (@$"
                        [1] - Ataque de energia;
                        [2] - Ataque com soco.
                        ");
                        
                        escolhaAtaque = char.Parse(Console.ReadLine());
                    }
                    break;
                }

                switch (escolhaDefesa)
                {
                case '1':
                    Console.WriteLine($"{p1.nome} defendeu energia!");                   
                    break;

                case '2':
                    Console.WriteLine($"{p1.nome} defendeu soco!");                   
                    break;

                case '3':
                    p2.RestaurarArmadura();
                    ;
                    break;

                default:
                    while (escolhaAtaque != '1' && escolhaAtaque != '2' && escolhaAtaque != '3')
                    {
                        Console.WriteLine($"Opcao nao encontrada, Digite novamente:");
                        Console.WriteLine
                        (@$"
                        [1] - Defender ataque de energia;
                        [2] - Defender ataque com soco;
                        [3] - Usar restauracao de armadura.
                        ");
                        
                        escolhaDefesa = char.Parse(Console.ReadLine());
                    }                
                    break;
                }
            }  
            //Fim ataque p2 e Defesa p1    

        }

        if (p1.armadura > p2.armadura)
            {
                Console.WriteLine($"Jogador {p1.nome} terminou com {p1.armadura} de armadura e ganhou o jogo!");
                Console.WriteLine($"Jogador {p2.nome} terminou com {p2.armadura} de armadura e perdeu o jogo!");
                               
            }
            else if (p2.armadura > p1.armadura)
            {
                Console.WriteLine($"Jogador {p2.nome} terminou com {p2.armadura} de armadura e ganhou o jogo!");
                Console.WriteLine($"Jogador {p1.nome} terminou com {p1.armadura} de armadura e perdeu o jogo!");
            }
            else
            {
                Console.WriteLine($"O jogo terminou em empate! Ambos com {p1.armadura} de armadura!");
                
            }
    }
}