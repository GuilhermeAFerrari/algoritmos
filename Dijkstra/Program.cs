var grafo = new GrafoDijkstra();

grafo.AddAresta(0, 1, 1);
grafo.AddAresta(0, 2, 10);
grafo.AddAresta(1, 3, 4);
grafo.AddAresta(1, 3, 2);
grafo.AddAresta(1, 4, 1);
grafo.AddAresta(2, 3, 1);
grafo.AddAresta(3, 4, 4);
grafo.AddAresta(3, 4, 1);

var caminhoDijkstra = grafo.MenorCaminhoDijkstra(0, 4);

Console.WriteLine("Dijkstra: " + string.Join(" -> ", caminhoDijkstra));


public class GrafoDijkstra
{
    private readonly Dictionary<int, List<(int destino, int peso)>> _adj = new();

    public void AddAresta(int origem, int destino, int peso)
    {
        if (!_adj.ContainsKey(origem))
            _adj[origem] = new List<(int, int)>();

        _adj[origem].Add((destino, peso));
    }

    public List<int> MenorCaminhoDijkstra(int inicio, int destino)
    {
        var dist = new Dictionary<int, int>();
        var pai = new Dictionary<int, int>();
        var pq = new PriorityQueue<int, int>();

        foreach (var v in _adj.Keys)
            dist[v] = int.MaxValue;

        dist[inicio] = 0;
        pq.Enqueue(inicio, 0);

        while (pq.Count > 0)
        {
            int atual = pq.Dequeue();

            if (atual == destino)
                return Reconstruir(pai, inicio, destino);

            foreach (var (vizinho, peso) in _adj[atual])
            {
                int novaDist = dist[atual] + peso;

                if (novaDist < dist.GetValueOrDefault(vizinho, int.MaxValue))
                {
                    dist[vizinho] = novaDist;
                    pai[vizinho] = atual;
                    pq.Enqueue(vizinho, novaDist);
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
