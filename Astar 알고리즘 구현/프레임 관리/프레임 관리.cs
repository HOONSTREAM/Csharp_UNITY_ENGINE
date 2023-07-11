namespace 프레임_관리
{
    internal class Program
    {
        static int lasttick = 0;
        const int Wait_TIck = 1000 / 30;


        static void Main(string[] args)
        {
            Board board = new Board();
            Player player = new Player();
            board.initialize(25,player);
            player.initialize(1, 1, board);

            /*=========================================================*/

            Console.CursorVisible = false;

            while (true)
            {
                #region 프레임 관리

                int currentTick = System.Environment.TickCount;
                int elapsedTick = currentTick - lasttick;

                if (elapsedTick < Wait_TIck)
                    continue;

                int deltaTick = currentTick - lasttick;
              lasttick = currentTick;

                #endregion

                player.Update(deltaTick);
                board.Rander();

                Console.SetCursorPosition(0, 0);

               

            }

          
            
        }
    }
}