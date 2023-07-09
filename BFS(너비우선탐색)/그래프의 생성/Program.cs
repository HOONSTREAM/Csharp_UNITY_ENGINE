namespace 그래프의_생성
{
    internal class Program
    {
        /* BFS는 최단거리 알고리즘에 사용된다 */
        class Graph
        {
            int[,] adj = new int[6, 6]
            {
                { 0, 1, 0, 1, 0, 0 }, // (0,0) (0,1) 순으로 나타낸것, 0,1 같은 경우엔 0에서 1으로 가는 경로, 1,0은 1에서 0으로 가는 경로, 무방향그래프이므로 좌우 대칭이다
                { 1, 0, 1, 1, 0, 0 },
                { 0, 1, 0, 0, 0, 0 },
                { 1, 1, 0, 0, 1, 0 },
                { 0, 0, 0, 1, 0, 1 },
                { 0, 0, 0, 0, 1, 0 },
            };

            List<int>[] adj2 = new List<int>[6]
            {
                new List<int> {1,3}, //0번 정점같은경우에는 1번과 3번을 갈 수있다.
                new List<int> {0,2,3},
                new List<int> {1},
                new List<int> {0,1,4},
                new List<int> {3,5},
                new List<int> {4},
            };

            public void BFS(int start) //int 2차원 배열을 활용
            {
                bool[] found = new bool[6];
                int[] parent = new int[6];
                int[] distance = new int[6];

                Queue<int> q = new Queue<int>(); // 예약목록 관리, 선입선출
                q.Enqueue(start);
                found[start] = true;
                parent[start] = start;
                distance[start] = 0;

                while (q.Count > 0) // 예약 대기열에 하나라도 있으면 무한대로 while
                {
                    int now = q.Dequeue();
                    Console.WriteLine(now);

                    for (int next = 0; next < 6; next++)
                    {
                        if (adj[now, next] == 0) // 인접하지 않았으면 스킵    
                            continue;
                        if (found[next]) //이미 방문한 정점이라면 스킵
                            continue;

                        q.Enqueue(next);
                        found[next] = true;
                        parent[next] = now;
                        distance[next] = distance[now] + 1;

                    }
                }

            }

            public void BFS2(int start) //List 배열을 활용
            {
                bool[] found = new bool[6];
                int[] parent = new int[6];
                int[] distance = new int[6];

                Queue<int> q = new Queue<int>(); // 예약목록 관리, 선입선출
                q.Enqueue(start);
                found[start] = true;
                parent[start] = start;
                distance[start] = 0;

                while (q.Count > 0) // 예약 대기열에 하나라도 있으면 무한대로 while
                {
                    int now = q.Dequeue();
                    Console.WriteLine(now);

                    foreach (int next in adj2[now])
                    {
                        
                        if (found[next]) //이미 방문한 정점이라면 스킵
                            continue;

                        q.Enqueue(next);
                        found[next] = true;
                        parent[next] = now;
                        distance[next] = distance[now] + 1;

                    }
                }

            }


            static void Main(string[] args)
            {
                Graph graph = new Graph();

                graph.BFS2(3);


            }
        }
    }
}