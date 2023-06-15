namespace r
{
    internal class Program
    {

        class Map
        {
            int[,] map =
            {
                {1,1,1,1,1 },
                {1,0,0,0,1 },
                {1,0,0,0,1 },
                {1,0,0,0,1 },
                {1,1,1,1,1 }

            };

            public void Rander()
            {
                var Color = Console.ForegroundColor;

                for(int y = 0; y < map.GetLength(0); y++)
                {
                    for(int x = 0; x < map.GetLength(1); x++)
                    {
                        if (map[y, x] == 1)
                            Console.ForegroundColor = ConsoleColor.Red;
                        else
                            Console.ForegroundColor = ConsoleColor.Green;

                        Console.Write("\u25cf");

                    }
                   Console.WriteLine();

                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void Main(string[] args)
        {
            Map map = new Map();

            map.Rander();


        }
    }
}