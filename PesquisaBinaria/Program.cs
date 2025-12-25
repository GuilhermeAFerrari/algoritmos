int[] numeros = { 1, 3, 5, 7, 9, 11, 13 };
int valorProcurado = 1;

int resultado = PesquisaBinaria(numeros, valorProcurado);

if (resultado != -1)
    Console.WriteLine($"Valor encontrado na posição {resultado}");
else
    Console.WriteLine("Valor não encontrado");

static int PesquisaBinaria(int[] array, int valor)
{
    int inicio = 0;
    int fim = array.Length - 1;

    while (inicio <= fim)
    {
        int meio = (inicio + fim) / 2;

        if (array[meio] == valor)
            return meio;

        if (array[meio] < valor)
        {
            inicio = meio + 1;
        }
        else
        {
            fim = meio - 1;
        }
    }

    return -1;
}