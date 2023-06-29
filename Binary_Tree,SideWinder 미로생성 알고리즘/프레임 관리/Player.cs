using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 프레임_관리
{
    internal class Player
    {
        public int PosY { get; private set; }
        public int PosX { get; private set; } //플레이어 좌표는 플레이어만 고칠수 있도록 함.
        Random rand = new Random();

        Board _board;

        public void initialize (int posy, int posx, int DesY , int DesX, Board board) //이 함수는 예외
        {
            PosY = posy;
            PosX = posx;
            _board = board;
        }

        const int MOVE_TICK = 100; // 100ms , 0.1초의 개념
        int _sumTick = 0;
        public void Update(int deltaTick)
        {
            _sumTick += deltaTick;
            if( _sumTick >= MOVE_TICK )
            {
                _sumTick = 0;

                int randValue = rand.Next(0, 4);
                //0.1초마다 실행될 로직을 넣어준다.

                switch (randValue)
                {
                    case 0: //상
                        if (PosY-1 >= 0 && _board.Tile[PosY - 1, PosX] == Board.TileType.Empty)
                            PosY = PosY - 1;

                        break;
                    case 1: //하
                        if (PosY+1 < _board.Size && _board.Tile[PosY+1, PosX] == Board.TileType.Empty)
                            PosY = PosY + 1;
                        break;
                    case 2: //좌
                        if (PosX-1 >= 0 && _board.Tile[PosY , PosX -1 ] == Board.TileType.Empty)
                            PosX = PosX - 1;
                        break;
                    case 3: //우
                        if (PosX+1 < _board.Size && _board.Tile[PosY , PosX + 1] == Board.TileType.Empty)
                            PosY = PosY + 1;
                        break;
                }


            }

        }
    }
}
