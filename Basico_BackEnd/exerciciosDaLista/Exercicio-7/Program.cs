// Faça um algoritmo para ler 15 números e armazenar em um vetor. Após a leitura total dos
// 15 números, o algoritmo deve escrever esses 15 números lidos na ordem inversa da qual foi
// declarado.

float[] numeros = new float[15];

for (var i = 0; i < 15; i++)
{
    Console.WriteLine($"Digite o {i+1}º numero:");
    numeros[i] = float.Parse(Console.ReadLine());    
}

Console.WriteLine($"Agora vamos mostrar os numeros em ordem inversa a digitada:");

for (var i = 14; i >= 0; i--)
{
    Console.WriteLine($"{numeros[i]}");  
}
