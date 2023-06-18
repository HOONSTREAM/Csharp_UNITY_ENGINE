using System.Collections.Specialized;

namespace Dictionary
{

    class Monster
    {
        private int id;
        public Monster (int id)
        {
            this.id = id;

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Monster mon = null;
            Dictionary<int,Monster> dic = new Dictionary<int,Monster>();

            for(int i = 0; i < 10000; i++)
            {
                dic.Add(i, new Monster(i));

            }

           bool found =  dic.TryGetValue(666, out mon);

            Console.WriteLine(found);

        }
    }
}