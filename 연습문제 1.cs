namespace 연습문제
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int NumStart = 2; // 구구단은 2단부터 시작

            for (int i = 0; i < 8; i++)
            {

                for (int j = 1; j < 10; j++)
                {

                    Console.WriteLine($"{NumStart}*{j}={NumStart * j}");
                    

                }
                Console.WriteLine("=================================");
                NumStart++;

                

            }
                


        }
    }
}