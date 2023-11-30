// - Escreva um algoritmo que imprima a tabuada (de 1 a 10) para os números de 1 a 10.
// Exemplo: tabuada do 1, tabuada do 2, etc... Dica: utilize um laço dentro do outro.

Console.WriteLine($"Vamos ver a taboada dos numeros de 1 a 10");

for (var t = 1; t < 11; t++)
{
    Console.WriteLine($"Taboada do {t}:");
    Console.WriteLine($"");
    
    
    for (var n = 1; n < 11; n++)
    {
        Console.WriteLine($"{t}x{n}={t*n}");
        Console.WriteLine($"");
        
        
    }
}

