using System.Security.Cryptography.X509Certificates;

namespace Property
{

    // property : 프로퍼티 , (get,set 함수를 한군데에다 묶는다.)
    internal class Program
    {
        class Knight
        {
            public int Hp { get; set; } = 100; // 프로퍼티
        }

        class Archor
        {
            public int mp //프로퍼티
            {
                get { return mp; }
                set { mp = value; }
            }
            static void Main(string[] args)
            {


                Knight knight = new Knight();

                Console.WriteLine(knight.Hp);

                Archor archor = new Archor();
                archor.mp=100;
                int Mpvalue = archor.mp;
                Console.WriteLine(Mpvalue);



            }
        }
    }
}