namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] b = new int[5];

            b[0] = 10;
            b[1] = 20;
            b[2] = 30;
            b[3] = 40;
            b[4] = 50;

            foreach(int bs in b)
            {
                Console.WriteLine(bs);
            }
        }
    }
}