namespace delegate_사용예제_II
{

     //델리게이트와 이벤트 차이점 : https://grayt.tistory.com/109
     
    class Program
    {
        public enum MarketType
        {

            None = 0,
            SAMPOO = 1,
            FOOD = 2

        }
        delegate int Mydelegate(); // 나이에 따른 함수를 저장할수있는 대리자 생성

        class OpenMarket
        {
            private MarketType type = MarketType.None;
            public OpenMarket(MarketType type)
            {
                this.type = type;
                Console.WriteLine("국적을 선택하세요. 1 : Korea 2 : JAPAN");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowMenu(GetAge_Korea);
                        break;
                    case "2":
                        ShowMenu(GetAge_JAPAN);
                        break;

                }

            }
            public void ShowMenu(Mydelegate getAge)
            {
                int age = getAge();

                if (age >= 20)
                    Console.WriteLine("성인용품 메뉴를 엽니다.");

                else
                    Console.WriteLine("일반용품 메뉴를 엽니다.");

            }


            private int GetAge_Korea()
            {

                Console.WriteLine("나이를 입력하세요.");
                int number = int.Parse(Console.ReadLine());

                return number + 1;
            } //한국식 나이 계산방법

            private int GetAge_JAPAN()
            {
                Console.WriteLine("나이를 입력하세요.");
                int number = int.Parse(Console.ReadLine());

                return number;
            } //일본식 나이 계산방법



        }

        class Process //쇼핑에 관한 전반적인 사항을 관리
        {

            public void shoppingProcess()
            {
                Console.WriteLine("쇼핑할 품목을 선택하세요. ");
                Console.WriteLine("[1] 음식");
                Console.WriteLine("[2] 생활용품");
                Console.WriteLine("[3] 쇼핑종료");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        OpenMarket markets = new OpenMarket(MarketType.FOOD);
                        Console.WriteLine("음식 카테고리를 선택하셨습니다.");
                        break;

                    case "2":
                        OpenMarket market = new OpenMarket(MarketType.SAMPOO);
                        Console.WriteLine("생활용품 카테고리를 선택하셨습니다.");
                        break;

                }
            }
        }


        static void Main(string[] args)
        {
            while (true)
            {
                Process process1 = new Process();

                process1.shoppingProcess();

            }

        }
    }
}
