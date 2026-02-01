
int[] meuArray = [20, 14, 15, 1, 6, 2];

var resultadoSoma = SomarRecursivamente(meuArray, 0);
Console.WriteLine($"Resultado somar recursivamente: {resultadoSoma}");

var resultadoContador = ContarRecursivamente(meuArray, 0);
Console.WriteLine($"Resultado contar recursivamente: {resultadoContador}");

var resultadoValorMaisAlto = ValorMaisAltoRecursivamente(meuArray, 0);
Console.WriteLine($"Resultado valor mais alto recursivamente: {resultadoValorMaisAlto}");

static int SomarRecursivamente(int[] array, int indice)
{
    if (indice >= array.Length)
        return 0;

    return array[indice] + SomarRecursivamente(array, indice + 1);
}

static int ContarRecursivamente(int[] array, int indice)
{
    if (indice >= array.Length)
        return 0;

    return 1 + ContarRecursivamente(array, indice + 1);
}
static int ValorMaisAltoRecursivamente(int[] array, int indice)
{
    if (indice == array.Length - 1)
        return array[indice];

    int maior = ValorMaisAltoRecursivamente(array, indice + 1);

    if (array[indice] > maior)
    {
        return array[indice];
    }
    else
    {
        return maior;
    }
}