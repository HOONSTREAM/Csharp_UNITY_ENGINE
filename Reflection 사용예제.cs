namespace Reflection_리플렉션_예제_
{

    //리플렉션,애트리뷰트 프린트물 : https://blog.hexabrain.net/152
    internal class Program
    {

        public enum MonsterType
        {
            None = 0,
            Orc = 1,
            Skeleton = 2
        }
       class Monster
        {
            public int hp;
            protected int attack;
            private int speed;
            delegate void AttackMethod(); // 공격방식에 따른 여러 함수들을 델리게이트에 정의
            MonsterType type = MonsterType.None;
            public Monster(MonsterType type)
            {
               this.type= type;
            }

           private void Attack(AttackMethod attack) {  }
            private void MethodFunc()
            {
                //공격하는방식을 정의
                Random rand = new Random();
                int randvalue =  rand.Next(1, 4);
                switch (randvalue)
                {
                    case 1:
                        Attack(SwordAttack);
                        break;
                    case 2:
                        Attack(PunchAttack);
                        break;
                    case 3:
                        Attack(SkillAttack);
                        break;

                }

            }
            public int MP { get; set; } = 100; // 프로퍼티 정의 예시

            private void SwordAttack() { } //델리게이트 1
            private void PunchAttack() { } //델리게이트 2
            private void SkillAttack() { } //델리게이트 3

        }


        static void Main(string[] args)
        {
            Monster monster = new Monster(MonsterType.Skeleton);
            var type = monster.GetType();

            var fields = type.GetFields(System.Reflection.BindingFlags.Public|
                System.Reflection.BindingFlags.Instance|
                System.Reflection.BindingFlags.NonPublic|
                System.Reflection.BindingFlags.Static
                );

            foreach ( var field in fields )
            {
                string access = "Protected";
                if (field.IsPublic)
                    access = "public";
                else if (field.IsPrivate)
                    access = "private";

                Console.WriteLine($"{access},{ field.FieldType.Name},{field.Name}");



            }

        }
    }
}