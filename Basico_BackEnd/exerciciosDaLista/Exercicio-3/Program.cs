// Faça um algoritmo para ler: a descrição do produto (nome), a quantidade adquirida e o
// preço unitário. Calcular e escrever o total (total = quantidade adquirida * preço unitário), o
// desconto e o total a pagar (total a pagar = total - desconto), sabendo-se que:
// - Se quantidade <= 5 o desconto será de 2%
// - Se quantidade > 5 e quantidade &lt;=10 o desconto será de 3%
// - Se quantidade > 10 o desconto será de 5%
// Dica: utilize if / else if / else

using System.Text.RegularExpressions;

static bool ValidacaoDeStringSemNumeros(string texto){
    Regex regexSemNumeros = new Regex(@"\d"); // Expressão regular para encontrar dígitos (números)
    if (regexSemNumeros.IsMatch(texto) || string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto)) { 
        return true;
    }
    else
    {
        return false;
            
    }
    }

static double CalcDesconto(double q, double pu)
{
    if (q <= 5)
    {
        double desconto = (q*pu)*0.02d;

        return desconto;
    }
    else if (q > 5 && q <= 10)
    {
        double desconto = (q*pu)*0.03d;

        return desconto;
    }
    else
    {
        double desconto = (q*pu)*0.05d;

        return desconto;
    }
}

string[] NuExcluidos = {"0","1","2","3","4","5","6","7","8","9"};

string nome;

int quantidade;

double precoUnitario;

double desconto;

double precoFinal;

Console.WriteLine($"Qual o nome do produto ?");
nome = (Console.ReadLine().Trim(' ').ToLower());
while (ValidacaoDeStringSemNumeros(nome)){
    Console.WriteLine($"O nome do produto não pode ser nulo ou conter numeros!\nDigite o nome do produto:");

    Console.WriteLine($"");
    
    nome = (Console.ReadLine().Trim(' ').ToLower());
}

Console.WriteLine($"");

Console.WriteLine($"Qual o preco do produto ?");
precoUnitario = double.Parse(Console.ReadLine().Trim(' '));

Console.WriteLine($"");

Console.WriteLine($"Quantas unidades o cliente gostaria ?");
quantidade = int.Parse(Console.ReadLine().Trim(' '));

desconto = CalcDesconto(quantidade, precoUnitario);

precoFinal = (quantidade*precoUnitario)-desconto;

Console.WriteLine($"O cliente pediu {quantidade} unidades do produto {nome};\nO valor do desconto foi de {desconto.ToString("C2")}\nO valor final foi de {precoFinal.ToString("C2")}");







