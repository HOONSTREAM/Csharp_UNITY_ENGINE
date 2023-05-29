using System;

namespace Csharp

{
    class Program
    {
       
        static void Main(string[] args)
        {
            int num;
            bool isPrime = true;

            Console.WriteLine("소수인지 판별 할 숫자를 입력하시오 : ");
            num = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine(num);

            for(int i = 2; i<num; i++)
            {

                if(num%i ==0)
                    isPrime = false;
                break;

              
             

            }
            if (isPrime)
                Console.WriteLine("소수 입니다.!");
            else
                Console.WriteLine("소수가 아닙니다!");




        }
    }
}