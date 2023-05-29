namespace 함수_생성_기초
{
    internal class Program
    {
        // 단순 입력받고 string 값을 출력시키는 함수 , (한정자, 반환형식, 이름 (매개변수) ) 
        static string Print ()
        {
            Console.WriteLine("출력할 문자를 입력하시오 . : " );
            string input = Console.ReadLine();
            Console.WriteLine("문자가 입력되었습니다.");
            Console.WriteLine("잠시 기다리세요.");
            Thread.Sleep(2000);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();



            return input;

        }
        static void Main(string[] args)
        {

            
            Console.WriteLine("======================");
            Thread.Sleep(2000);



            Console.WriteLine(Program.Print()) ;

        }
    }
}