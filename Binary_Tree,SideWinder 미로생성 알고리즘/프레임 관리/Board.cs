 using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace 프레임_관리
{
    // Convention : 클래스 내부에서만 활용하는 변수 _xxx 여러 객체가 협력하는 변수 대문자이름
    internal class Board
    {
        const char CIRCLE = '\u25cf';
        public enum TileType
        {
            Empty,
            Wall
        }

        Player _player;

        public TileType[,] Tile { get; private set; }
        public int Size {get; private set;} //get만 열어주고 set은 클래스내부에서만 할수 있도록 막아둠.

        public void initialize(int size,Player player)
        {
            _player = player;

            if (size % 2 == 0)
            {
                Console.WriteLine("사이즈는 무조건 홀수여야 합니다.");
                return;
            }


            Tile = new TileType[size, size];
            Size = size;
            // GenerateByBinaryTree();
            GenerateSideWinder();

        }
        public void Rander()
        {
            ConsoleColor prevcolor = Console.ForegroundColor;

            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if(x==_player.PosX && y == _player.PosY)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    Console.ForegroundColor = GetTileColor(Tile[y, x]);
                    Console.Write(CIRCLE);

                }
                Console.WriteLine();
            }
            Console.ForegroundColor = prevcolor;
        }

        private void GenerateByBinaryTree()
        {
            // 모든 길을 막아버리는 작업
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        Tile[y, x] = TileType.Wall;
                    else
                        Tile[y, x] = TileType.Empty;

                }
            }
            //랜덤으로 우측 혹은 아래로 길을 뚫는 작업
            Random rand = new Random();

            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;
                    if (y == Size - 2 && x == Size - 2)
                    {
                        continue;
                    }

                    if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }
                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }


                    if (rand.Next(0, 2) == 0)
                    {
                        Tile[y, x + 1] = TileType.Empty; // 우측으로 길뚫기
                    }
                    else
                        Tile[y + 1, x] = TileType.Empty; // 아래로 길뚫기




                }
            }

        }
        private void GenerateSideWinder()
        {
            // 모든 길을 막아버리는 작업
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        Tile[y, x] = TileType.Wall;
                    else
                        Tile[y, x] = TileType.Empty;

                }
            }
            //랜덤으로 우측 혹은 아래로 길을 뚫는 작업
            Random rand = new Random();
             // 우측으로 가는 길 카운트
            for (int y = 0; y < Size; y++)
            {
                int count = 1;
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    if (y == Size - 2 && x == Size - 2)
                    {
                        continue;
                    }

                    if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }
                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }


                    if (rand.Next(0, 2) == 0)
                    {
                        Tile[y, x + 1] = TileType.Empty; // 우측으로 길뚫기
                        count++;
                    }
                    else
                    {
                        int randomindex = rand.Next(0, count);
                        Tile[y + 1, x-randomindex*2] = TileType.Empty; // 아래로 길뚫기
                        count = 1;
                    }



                }
            }
        }
        private ConsoleColor GetTileColor(TileType tileType)
        {
            switch (tileType)
            {
                case TileType.Empty:
                    return Console.ForegroundColor = ConsoleColor.Green;

                case TileType.Wall:
                    return Console.ForegroundColor = ConsoleColor.Red;

                default:
                    return Console.ForegroundColor = ConsoleColor.Green;


            }
        }
 


    }
}
