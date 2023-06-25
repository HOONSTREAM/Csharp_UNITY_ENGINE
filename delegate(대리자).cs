namespace 대리자_delegate_
{
    internal class Program
    {
        delegate int Oncliked();

        static int TestDelegate()
        {
            Console.WriteLine("Hello delegate");

            return 0;
        }

        static int TestDelegate2()
        {

            Console.WriteLine("Hello Delegate2");

            return 0;
        }

        static void ButtonPressed(Oncliked clikedFunction)
        {
            clikedFunction();
        }
        static void Main(string[] args)
        {
            Oncliked clicked = new Oncliked(TestDelegate);

            clicked += TestDelegate2;

            ButtonPressed(clicked);


  
        }
    }
}