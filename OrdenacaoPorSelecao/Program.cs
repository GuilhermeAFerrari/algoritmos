int[] numeros = { 12, 3, 4, 78, 5, 2, 56, 5, 1, 99 };

Ordenar(numeros);

Console.WriteLine($"Array ordenado:");
foreach (var item in numeros)
{
    Console.WriteLine(item);
}

static void Ordenar(int[] numeros)
{
    for (int i = 0; i < numeros.Length - 1; i++)
    {
        var menorIndice = i;

        for (int j = i + 1; j < numeros.Length; j++)
        {
            if (numeros[j] < numeros[menorIndice])
            {
                menorIndice = j;
            }
        }

        if (menorIndice != i)
        {
            int temp = numeros[i];
            numeros[i] = numeros[menorIndice];
            numeros[menorIndice] = temp;

            //(numeros[menorIndice], numeros[i]) = (numeros[i], numeros[menorIndice]); // tuple Swap
        }
    }
}
