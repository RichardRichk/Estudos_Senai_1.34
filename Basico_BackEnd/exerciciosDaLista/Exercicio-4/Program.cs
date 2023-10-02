// Faça um programa que leia 10 valores digitados pelo usuário e no final, escreva o maior e o
// menor valor lido.


double[] numeros = new double[10];


Console.WriteLine($"Digite 10 numeros");

for (var i = 0; i < 10; i++)
{
    Console.WriteLine($"Digite o {i+1}º numero:");
    
    numeros[i] = double.Parse(Console.ReadLine());
}

Console.WriteLine($"O maior numero e {numeros.Max()} e o menor e {numeros.Min()}");


