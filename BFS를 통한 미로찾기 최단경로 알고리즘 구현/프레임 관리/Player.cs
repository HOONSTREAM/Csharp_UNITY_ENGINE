using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            BFS();

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

            int y = _board.DesY;
            int x = _board.DesX;

            while (parent[y,x].Y != y || parent[y,x].X !=x) // 시작점 (부모와 내가 같아지는시점) 까지 역추적
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


