// Escreva um algoritmo que permita a leitura dos nomes de 10 pessoas e armazene os nomes
// lidos em um vetor. Após isto, o algoritmo deve permitir a leitura de mais 1 nome qualquer de
// pessoa (para efetuar uma busca) e depois escrever a mensagem ACHEI, se o nome estiver
// entre os 10 nomes lidos anteriormente (guardados no vetor), ou NÃO ACHEI caso contrário.


string[] nomes = new string[10];

string nomeDigitado;

for (var i = 0; i < 10; i++)
{
    Console.WriteLine($"Ola, digite o {i+1}º nome:");
    nomes[i] = Console.ReadLine();
}

Console.WriteLine($"Certo, escreva um nome igual ou diferente dos anteriores:");
nomeDigitado = Console.ReadLine();

if (nomes.Contains(nomeDigitado))
{
    Console.WriteLine($"ACHEI");
}
else
{
    Console.WriteLine($"Não encontrado");  
}
