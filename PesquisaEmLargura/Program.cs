var grafo = new GrafoBfs();

grafo.AddAresta(0, 1);
grafo.AddAresta(0, 2);
grafo.AddAresta(1, 3);
grafo.AddAresta(1, 4);
grafo.AddAresta(2, 3);
grafo.AddAresta(3, 4);

var caminhoBfs = grafo.MenorCaminhoBfs(0, 4);

Console.WriteLine("BFS: " + string.Join(" -> ", caminhoBfs));

class GrafoBfs
{
    private readonly Dictionary<int, List<int>> _adj = new();

    public void AddAresta(int origem, int destino)
    {
        if (!_adj.ContainsKey(origem))
            _adj[origem] = new List<int>();

        _adj[origem].Add(destino);
    }

    public List<int> MenorCaminhoBfs(int inicio, int destino)
    {
        var fila = new Queue<int>();
        var visitado = new HashSet<int>();
        var pai = new Dictionary<int, int>();

        fila.Enqueue(inicio);
        visitado.Add(inicio);

        while (fila.Count > 0)
        {
            int atual = fila.Dequeue();

            if (atual == destino)
                return Reconstruir(pai, inicio, destino);

            if (!_adj.ContainsKey(atual))
                continue;

            foreach (var vizinho in _adj[atual])
            {
                if (!visitado.Contains(vizinho))
                {
                    visitado.Add(vizinho);
                    pai[vizinho] = atual;
                    fila.Enqueue(vizinho);
                }
            }
        }

        return new List<int>();
    }

    private List<int> Reconstruir(
        Dictionary<int, int> pai, int inicio, int destino)
    {
        var caminho = new List<int>();
        int atual = destino;

        while (atual != inicio)
        {
            caminho.Add(atual);
            atual = pai[atual];
        }

        caminho.Add(inicio);
        caminho.Reverse();
        return caminho;
    }
}
