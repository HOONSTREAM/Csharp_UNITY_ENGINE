using System.ComponentModel;

namespace 그래프의_생성
{
    internal class Program
    {
        
        class Graph
        {
            int[,] adj = new int[6, 6] // 가중치 그래프
            {
                { -1, 15, -1, 35, -1, -1 }, 
                { 15, -1, 05, 10, -1, -1 },
                { -1, 05, -1, -1, -1, -1 },
                { 35, 10, -1, -1, 05, -1 },
                { -1, 0, -1, 05, -1 ,05 },
                { -1, -1, -1, -1, 05, -1 },
            };

            public void Dijikstra(int start)
            {
                bool[] visited = new bool[6]; //방문을 했는지 안했는지에 대한 배열에 저장
                int[] distance = new int[6]; //정점을 찾았을 때의 그 최단거리를 저장 
                int[] parent = new int[6];
                Array.Fill(distance, Int32.MaxValue); // distance 배열에 int32에서 사용할수 있는 가장 큰 값을 넣는다. (INF) (초깃값이 0인지, 방문을 못해서0인지 햇갈리기때문)
                distance[start] = 0;
                parent[start] = start;

                while (true)
                {
                    //제일 좋은 저cost의 후보를 찾는다.

                    //가장 유력한 후보와 거리와 번호를 저장한다.
                    int closest = Int32.MaxValue; //거리
                    int now = -1; //번호

                    for(int i  = 0; i < 6; i++)
                    {
                        if (visited[i])
                            continue;

                        //아직 발견된 적(예약된 적)이 없거나, 기존 후보보다 멀리 있으면 스킵
                        if (distance[i] == Int32.MaxValue || distance[i] >= closest)
                            continue;

                        closest = distance[i];
                        now = i;

                    }

                    //다음후보가 하나도 없다. -> 종료
                    if (now == -1)
                        break;
                    //유력한 후보를 찾았으니 방문한다.
                    visited[now] = true;

                    //방문한 정점과 인접한 정점들을 조사해서, 상황에 따라 발견한 최단거리를 갱신한다.

                    for(int next=0 ; next < 6; next++)
                    {
                        //연결되지 않은 정점 스킵
                        if (adj[now, next] == -1)
                            continue;
                        //이미 방문한 정점은 스킵
                        if (visited[next])
                            continue;
                        //새로 조사된 정점의 최단거리를 계산한다.
                        int nextDist = distance[now] + adj[now, next];
                        //만약 기존에 발견한 최단거리가 새로 조사된 최단거리보다 크면 정보 갱신
                        if(nextDist < distance[next])
                        {
                            distance[next] = nextDist;
                            parent[next] = now;
                        }
                    }
                }


            }
     
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