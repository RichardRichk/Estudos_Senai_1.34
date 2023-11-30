// Um posto está vendendo combustíveis com a seguinte tabela de descontos:
// Álcool:
// . até 20 litros, desconto de 3% por litro Álcool
// . acima de 20 litros, desconto de 5% por litro
// Gasolina:
// . até 20 litros, desconto de 4% por litro Gasolina
// . acima de 20 litros, desconto de 6% por litro

// Escreva um algoritmo que leia o número de litros vendidos e o tipo de combustível (codificado
// da seguinte forma: A-álcool, G-gasolina), calcule e imprima o valor a ser pago pelo cliente
// sabendo-se que o preço do litro da gasolina é R$ 5,30 e o preço do litro do álcool é R$ 4,90.
// Dica: utilize switch case e funções/métodos para otimizar o algorítimo.

using System.Globalization;

double la;

char tipo;

double valorDesconto;

double valorFinal;

const double precoAlcool = 4.90d;

const double precoGasolina = 5.30d;

static double ValorAlcool(double a, double pA)
{
    if (a <=20)
    {
        return (a*pA)*0.03d;
    }
    else
    {
        return (a*pA)*0.05d;
    }
}

static double ValorGasolina(double a, double pG)
{
    if (a <=20)
    {
        return (a*pG)*0.03d;
    }
    else
    {
        return (a*pG)*0.05d;
    }
}

Console.WriteLine($"Ola, qual a de hoje ?\n(Digite 'A' para Alcool e 'G' para Gasolina)");
tipo = char.Parse(Console.ReadLine().ToLower());

while (tipo != 'a' && tipo != 'g')
{  
    Console.WriteLine($"Voce digitou errado, digite novamente:\n(Digite 'A' para Alcool e 'G' para Gasolina)");
    tipo = char.Parse(Console.ReadLine().ToLower());
}

Console.WriteLine($"Certo, e quantos litros ?");
la = double.Parse(Console.ReadLine().Trim(' '));

    switch (tipo)
    {
        case 'a':

        valorDesconto = ValorAlcool(la, precoAlcool);

        valorFinal = (la*4.90d) - valorDesconto;

        Console.WriteLine(
            @$"O valor de desconto da gasolina foi de: {Math.Round(valorDesconto, 2).ToString("C", new CultureInfo("pt-Br"))};
            O valor total foi de: {Math.Round(valorFinal, 2).ToString("C", new CultureInfo("pt-Br"))}");
        
        

            break;
        case 'g':

        valorDesconto = ValorGasolina(la, precoGasolina);

        valorFinal = (la*5.30d) - valorDesconto;

        Console.WriteLine(
            @$"O valor de desconto da gasolina foi de: {Math.Round(valorDesconto, 2).ToString("C", new CultureInfo("pt-Br"))};
            O valor total foi de: {Math.Round(valorFinal, 2).ToString("C", new CultureInfo("pt-Br"))}");

            break;
    }

