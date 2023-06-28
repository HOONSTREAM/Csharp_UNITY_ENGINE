namespace 프레임_관리
{
    internal class Program
    {
        static int lasttick = 0;
        const int Wait_TIck = 1000 / 30;


        static void Main(string[] args)
        {
            Board board = new Board();
            board.initialize();

            /*=========================================================*/

            Console.CursorVisible = false;

            while (true)
            {
                #region 프레임 관리

                int currentTick = System.Environment.TickCount;
                int elapsedTick = currentTick - lasttick;

                if (elapsedTick < Wait_TIck)
                    continue;
                
              lasttick = currentTick;

                #endregion


                Console.SetCursorPosition(0, 0);

                for (int i = 0; i < 25; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        Console.Write('\u25cf');
                        Console.ForegroundColor = ConsoleColor.Yellow;


                    }
                    Console.WriteLine();
                }

            }

          
            
        }
    }
}