namespace 연습문제_3
{
    internal class Program
    {

        static int Factorial(int n)
        {
            int refs = 1;
           
            for(int num=1; num<=n; num++)
            {
                refs = (refs * num);

            }

            return refs;
        }
        static void Main(string[] args)
        {

            int n;

            n = Program.Factorial(5);

            Console.WriteLine(n);

        }
    }
}