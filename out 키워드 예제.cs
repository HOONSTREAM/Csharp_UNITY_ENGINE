namespace outs {
internal class Program
{

    static void Divide(int a, int b, out int result1, out int result2)
    {
        result1 = a % b;
        result2 = a / b;

    }
    static void Main(string[] args)
    {
        int num1 = 10;
        int num2 = 3;
        int re1;
        int re2;

        Divide(num1, num2, out re1, out re2);

        Console.WriteLine(re1);
        Console.WriteLine(re2);

    }
}
}

