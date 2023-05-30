namespace ref_out
{
    internal class Program
    {

        static void Swap (ref int x, ref int y)
        {
            int temp;
            temp = x;
            x = y;
            y = temp;

        }
        static void Main(string[] args)

            
        {
            int num1 = 10; int num2 = 20;

            Console.WriteLine("초기값의 num1 은 {0} 이고, num2는 {1}입니다.",num1,num2);
            

            Program.Swap (ref num1, ref num2);

            Console.WriteLine($"num 1의 값은 {num1}이며, num2의 값은 {num2} 입니다. ");
        }
    }
}