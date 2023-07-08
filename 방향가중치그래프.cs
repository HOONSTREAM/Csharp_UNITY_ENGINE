namespace 방향가중치그래프
{
    internal class Program
    {
        //방향가중치그래프의 표현
        class Edge
        {
            public int vertex;
            public int weight;

            public Edge(int v, int w)
            {
              vertex = v;
              weight = w;
            }
        }

        List<Edge>[] adjacent = new List<Edge>[6]
        {
            new List<Edge>() {new Edge(1,15), new Edge(3,35)},
            new List<Edge>() {new Edge(0,15), new Edge(2,5), new Edge(3,10)},
            new List<Edge>() { },
            new List<Edge>() {new Edge(4,5)},
            new List<Edge>() {},
            new List<Edge>() {new Edge(4,5) },
        };

        
        static void Main(string[] args)
        {
            
        }
    }
}