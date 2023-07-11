using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 참고 : https://velog.io/@lucky-korma/DFS-BFS%EC%9D%98-%EC%84%A4%EB%AA%85-%EC%B0%A8%EC%9D%B4%EC%A0%90


namespace 프레임_관리
{

    class Pos
    {
        public int X;
        public int Y;
        public Pos(int y , int x )
        {
              Y=y; X=x;
        }

    }
    internal class Player
    {
        public int PosY { get; private set; }
        public int PosX { get; private set; } //플레이어 좌표는 플레이어만 고칠수 있도록 함.
        Random rand = new Random();

        Board _board;

        private enum Dir
        {
            Up =0,
            Left =1,
            Down =2,
            Right =3
        }

        int _Dir = (int)Dir.Up;
        List<Pos> _points = new List<Pos>();


        public void initialize(int posy, int posx, Board board) //이 함수는 예외
        {
            PosY = posy;
            PosX = posx;
            _board = board;
            //BFS();
            Astar();


        }

        struct PriorityQueueNode : IComparable<PriorityQueueNode>
        {
            public int F;
            public int G;
            public int Y;
            public int X;
        
            public int CompareTo(PriorityQueueNode other)
            {
                if (F == other.F)
                    return 0;
                return F < other.F ? 1 : -1; // 작을수록 좋은 것이기 때문 ! 
            }
        }
        private void Astar()
        {
            // U L D R UL DL DR UR
            int[] deltaY = new int[] { -1, 0, 1, 0 , -1 , 1 , 1 , -1 }; // 위를 가고싶다면 -1, 좌측 0, 아래 1, 우측 0
            int[] deltaX = new int[] { 0, -1, 0, 1, -1, -1 ,1 , 1 };
            int[] cost = new int[] { 10, 10, 10, 10 , 14,14,14,14  }; // 거리 이동 비용을 배열로 관리 , 대각선은 루트2, 1.4 의 10배 
            /*-----------------------------------------------------------------------------------*/

            //점수 매기기
            //F = G + H
            //F = 최종 점수 (작을수록 좋음, 경로에 따라 달라짐)
            //G = 시작점에서 해당 좌표까지 이동하는데 드는 비용 (작을수록 좋음. 경로에따라 달라짐)
            //H = 목적지에서 얼마나 가까운지 (작을수록 좋음 , 고정 , 벽 고려안함, 근사적으로 얼마나 목적지까지 가까워졌는지)

            //(y,x) 이미 방문 했는지의 여부 (방문 = closed 상태)
            bool[,] closed = new bool[_board.Size, _board.Size]; //CloseList

            //(y,x) 가는 길을 한번이라도 발견했는지
            // 발견 X -> Int32.MaxValue
            // 발견 O -> F = G + H 점수 대입
            int[,] open = new int[_board.Size, _board.Size]; //OpenList
            for (int y = 0; y < _board.Size; y++)
                for (int x = 0; x < _board.Size; x++)
                    open[y, x] = Int32.MaxValue; // 발견X의 초기값 지정

            Pos[,] parent = new Pos[_board.Size, _board.Size];


            //최고값을 뽑는데 가장 최적화 된 자료구조 (우선순위 큐) , Openlist 에 있는 정보들 중에서, 가장 좋은 후보를 빠르게 뽑아오기 위한 도구
            PriorityQueue<PriorityQueueNode> pq = new PriorityQueue<PriorityQueueNode>();
            //시작점 발견 (예약진행)
            open[PosY,PosX] = 10*(Math.Abs(_board.DesY - PosY) + Math.Abs(_board.DesX - PosX)); // G는 없음. 시작점이므로 0 , H만 계산
            pq.Push(new PriorityQueueNode() { F = 10 *( Math.Abs(_board.DesY - PosY) + Math.Abs(_board.DesX - PosX)) , G = 0 , Y = PosY , X = PosX });
            parent[PosY, PosX] = new Pos(PosY, PosX);

            while (pq.count>0)
            {
                // 제일 좋은 후보를 찾는다.
                PriorityQueueNode node = pq.Pop();
                // 동일한 좌표를 여러 경로로 찾아서, 더 빠른 경로로 인해서 이미 방문(closed)한 경우 스킵
                if (closed[node.Y, node.X])
                    continue;

                //방문한다.
                closed[node.Y,node.X] = true;

                if (node.Y == _board.DesY && node.X == _board.DesX)
                    break;

                //상하좌우 등 이동할 수 있는 좌표인지 확인해서 , 예약(open)한다.
                for(int i = 0; i<deltaY.Length; i++)
                {
                    int nextY = node.Y + deltaY[i];
                    int nextX = node.X + deltaX[i];

                    if (nextY < 0 || nextY >= _board.Size || nextX < 0 || nextX >= _board.Size) // 유효범위를 벗어났으면 스킵
                        continue;
                    //벽으로 막혀서 갈수 없으면 스킵
                    if (_board.Tile[nextY, nextX] == Board.TileType.Wall)
                        continue;

                    // 이미 방문한 곳이면 스킵
                    if (closed[nextY, nextX])
                        continue;

                    //비용 계산
                    int g = node.G + cost[i];
                    int h = 10 *( Math.Abs(_board.DesY - nextY) + Math.Abs(_board.DesX - nextX));
                    //다른 경로에서 더 빠른 길을 이미 찾았으면 스킵

                    if (open[nextY, nextX] < g + h)
                        continue;

                    // 예약 진행
                    open[nextY,nextX] = g + h;
                    pq.Push(new PriorityQueueNode() {F=g+h,G=g,Y=nextY,X=nextX});
                    parent[nextY, nextX] = new Pos(node.Y, node.X);


                }
            }

            CalcPathFromParent(parent);

        }
        private void BFS()
        {

            int[] deltaY = new int[] {-1,0,1,0}; // 위를 가고싶다면 -1, 좌측 0, 아래 1, 우측 0
            int[] deltaX = new int[] {0,-1,0,1}; 
            bool[,] found = new bool[_board.Size, _board.Size];
            Pos[,] parent = new Pos[_board.Size, _board.Size];

            Queue<Pos> q = new Queue<Pos>();
            q.Enqueue(new Pos(PosY, PosX));
            found[PosY, PosX] = true;


            while (q.Count > 0)
            {
                Pos pos = q.Dequeue();
                int nowY = pos.Y;
                int nowX = pos.X;
                parent[PosY, PosX] = new Pos(PosX, PosY);

                for (int i = 0; i < 4; i++)
                {
                    int nextY = nowY + deltaY[i];
                    int nextX = nowX + deltaX[i];

                    if (nextY < 0 || nextY >= _board.Size || nextX < 0 || nextX >= _board.Size) // 좌표 사용할때는 항상 out of index crash 조심
                        continue;

                    if (_board.Tile[nextY, nextX] == Board.TileType.Wall)
                        continue;
                    if (found[nextY, nextX])
                        continue;

                    q.Enqueue(new Pos(nextY, nextX));
                    found[nextY, nextX]= true;
                    parent[nextY, nextX] = new Pos(nowY, nowX);


                }

            }

            CalcPathFromParent(parent);

        }

        private void CalcPathFromParent(Pos[,] parent)
        {
            int y = _board.DesY;
            int x = _board.DesX;

            while (parent[y, x].Y != y || parent[y, x].X != x) // 시작점 (부모와 내가 같아지는시점) 까지 역추적
            {
                _points.Add(new Pos(y, x));
                Pos pos = parent[y, x];
                y = pos.Y;
                x = pos.X;

            }
            _points.Add(new Pos(y, x)); // 시작점 Add 하기. (while 탈출조건에 의해 시작점은 add가 되지않음)
            _points.Reverse(); //(리스트의 뒤집기)

        }
        private void RightHand()
        {

            int[] FrontY = new int[] { -1, 0, 1, 0 }; // Y 기준으로 위로 갈때는 -1, 아래로 갈때는 + 1 좌우는 Y좌표 변화없음 0
            int[] FrontX = new int[] { 0, -1, 0, 1 }; // X기준으로 왼쪽으로 갈때는 -1 , 오른쪽 +1 위아래는 X좌표 변화없음 0
            int[] RightY = new int[] { 0, -1, 0, 1 };
            int[] RightX = new int[] { 1, 0, -1, 0 };

            _points.Add(new Pos(PosY, PosX));  //초기값
            while (PosY != _board.DesY || PosX != _board.DesX) // 목적지에 도달할때 까지 루프, 계산이 완료된 후에 update 함수에서 꺼내쓴다.
            {
                //1. 현재 바라보는 방향을 기준으로 오른쪽으로 갈 수 있는지 확인.
                if (_board.Tile[PosY + RightY[_Dir], PosX + RightX[_Dir]] == Board.TileType.Empty)
                {
                    _Dir = (_Dir - 1 + 4) % 4; //int _Dir = (int)Dir.Up; 식으로 enum 을 int로 형변환하여 int로 갖고 있고,
                    // 나머지 연산을 통하여 오른쪽으로 회전할수 있게끔 스위치문으로 복잡하게 연산하는것이 아닌 한줄로 간단하게 연산하는 것.
                    PosY = PosY + FrontY[_Dir];
                    PosX = PosX + FrontX[_Dir];
                    _points.Add(new Pos(PosY, PosX)); //좌표변화를 LIST에 저장

                }
                //2. 현재 바라보는 방향으로 전진할수 있는지 확인
                else if (_board.Tile[PosY + FrontY[_Dir], PosX + FrontX[_Dir]] == Board.TileType.Empty)
                {
                    PosY = PosY + FrontY[_Dir];
                    PosX = PosX + FrontX[_Dir];
                    _points.Add(new Pos(PosY, PosX)); //좌표 변화를 LIST에 저장
                    // 앞으로 1보 전진
                }

                else
                {
                    //왼쪽방향으로 90도 회전
                    _Dir = (_Dir + 1 + 4) % 4;

                }
            }

        } // 우수법으로 길찾기 (오른손법칙)


        const int MOVE_TICK = 50; // 100ms , 0.1초의 개념
        int _sumTick = 0;
        int _lastindex = 0;

        public void Update(int deltaTick)
        {
            if(_lastindex >= _points.Count)
            
                return;
            
            _sumTick += deltaTick;
            if (_sumTick >= MOVE_TICK)
            {
                _sumTick = 0;

                //0.1초마다 실행될 로직을 넣어준다.

                PosY = _points[_lastindex].Y;
                PosX = _points[_lastindex].X;
                _lastindex++;

            }

        }
    }
}


