namespace 그래프의_생성
{
    internal class Program
    {

        class Graph
        {
            int[,] adj = new int[6, 6]
            {
                { 0, 1, 0, 1, 0, 0 }, // (0,0) (0,1) 순으로 나타낸것, 0,1 같은 경우엔 0에서 1으로 가는 경로, 1,0은 1에서 0으로 가는 경로, 무방향그래프이므로 좌우 대칭이다
                { 1, 0, 1, 1, 0, 0 },
                { 0, 1, 0, 0, 0, 0 },
                { 1, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1 },
                { 0, 0, 0, 0, 1, 0 },
            };

            List<int>[] adj2 = new List<int>[6]
            {
                new List<int> {1,3}, //0번 정점같은경우에는 1번과 3번을 갈 수있다.
                new List<int> {0,2,3},
                new List<int> {1},
                new List<int> {0,1},
                new List<int> {5},
                new List<int> {4},
            };

            bool[] visited = new bool[6]; //방문했는지 안했는지에 관한 불리언
            // 1) 우선 now부터 방문하고, now와 연결된 정점을 하나씩 확인하여 <아직 미방문상태라면> 방문한다.

            public void DFS(int now) {

                Console.WriteLine(now);
                visited[now]= true;

                //int 배열로 사용할때의 구현
                for(int next = 0; next < adj.GetLength(0); next++)
                {
                    if (adj[now, next] == 0) // 연결되어있지 않으면 스킵
                        continue;
                    if (visited[next]) // 이미 방문했으면 스킵
                        continue;
                    DFS(next); // 재귀함수

                }

            }
            public void DFS2(int now)
            {
                Console.WriteLine(now);
                visited[now] = true;

                foreach(int next in adj2[now])
                {
                    if (visited[next]) // 이미 방문했으면 스킵
                        continue;
                    DFS2(next);
                }

            }
            public void SearchAll()
            {
                visited = new bool[6];
                for(int now = 0; now<6; now++)
                {
                    if (visited[now] == false)
                        DFS(now);

                }
            } // 만약에 그래프 중, 간선이 끊긴 그래프가 있는지 탐색하고 그것도 전부 탐색시키는 함수





        }
        static void Main(string[] args)
        {
           
           Graph graph = new Graph();
            graph.SearchAll();
           
        }
    }
}