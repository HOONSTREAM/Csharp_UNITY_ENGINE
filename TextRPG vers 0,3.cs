using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace TextRPG_vers_0._3
{
    internal class Program
    {
        enum ClassType
        {
            None = 0,
            Knight = 1,
            Archor = 2,
            mage = 3

        } // 클래스타입에 대한 enum 열거형 정의

        enum MonsterType
        {
            None = 0,
            Suhan = 1,
            JaeYeop = 2,
            ZIZONE = 3
        } //몬스터타입에 대한 enum 열거형 정의
        struct PlayerInfo
        {
            public int hp; //체력
            public int attack; //공격력
            public int Gold; // 골드


        } // 플레이어 정보에 대한 구조체
        struct MonsterInfo
        {
            public int hp; //체력
            public int attack; //공격력

        }

        static ClassType ChooseClass() //직업선택함수
        {
            ClassType ClassChoice = ClassType.None;

            Console.WriteLine("직업을 선택하세요 !");
            Console.WriteLine("[1]검사");
            Console.WriteLine("[2]궁수");
            Console.WriteLine("[3]마법사");
            Console.WriteLine("[4]게임종료");
            string input = Console.ReadLine();

            switch (input) // 직업 선택
            {

                case "1":
                    Console.WriteLine("검사 선택");
                    ClassChoice = ClassType.Knight;
                    break;
                case "2":
                    Console.WriteLine("궁수 선택");
                    ClassChoice = ClassType.Archor;
                    break;
                case "3":
                    Console.WriteLine("마법사 선택");
                    ClassChoice = ClassType.mage;
                    break;

                case "4":
                    Environment.Exit(0);
                    break;


                   






            }

            return ClassChoice;
        }
        static void CreateMonster(out MonsterInfo monster)
        {
            Console.WriteLine("CreateMonster 함수 호출, 몬스터 랜덤 생성");
            Random rand = new Random();
            int randMonster = rand.Next(1, 4);
            switch (randMonster)
            {
                case (int)MonsterType.JaeYeop:
                    monster.hp = 100;
                    monster.attack = 10;
                    Console.WriteLine($"재엽 몬스터 생성 완료, 초기체력{monster.hp}, 공격력{monster.attack} 으로 시작합니다. ");
                    break;
                case (int)MonsterType.Suhan:
                    monster.hp = 75;
                    monster.attack = 12;
                    Console.WriteLine($"수한 몬스터 생성 완료, 초기체력{monster.hp}, 공격력{monster.attack} 으로 시작합니다. ");
                    break;
                case (int)MonsterType.ZIZONE:
                    monster.hp = 50;
                    monster.attack = 15;
                    Console.WriteLine($"지존 몬스터 생성 완료, 초기체력{monster.hp}, 공격력{monster.attack} 으로 시작합니다. ");
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;

            }

        } // 몬스터 생성 함수
        static void CreatePlayer(ClassType TypeNumber, out PlayerInfo player)
        {
            //Console.WriteLine("CreatePlayer 함수 호출");


            switch (TypeNumber)
            {
                case ClassType.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    player.Gold = 0;
                    Console.WriteLine($"전사 생성 완료, 초기체력{player.hp}, 공격력{player.attack} 으로 시작합니다. ");
                    break;
                case ClassType.Archor:
                    player.hp = 75;
                    player.attack = 12;
                    player.Gold = 0;
                    Console.WriteLine($"궁수 생성 완료, 초기체력{player.hp}, 공격력{player.attack} 으로 시작합니다. ");
                    break;
                case ClassType.mage:
                    player.hp = 50;
                    player.attack = 15;
                    player.Gold = 0;
                    Console.WriteLine($"마법사 생성 완료, 초기체력{player.hp}, 공격력{player.attack} 으로 시작합니다. ");
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    player.Gold = 0;
                    break;

            }

        } // 캐릭터 생성 함수
        static void EnterGame(ClassType ClassNumber, ref PlayerInfo player) // 마을로 입장
        {
            while (true)
            {
                Console.WriteLine("Legend of Elancia 에 오신 것을 환영합니다 !");
                Console.WriteLine("초기마을 '로랜시아'에 입장하였습니다.");
                Console.WriteLine("[1] 필드로 가기");
                Console.WriteLine("[2] 체력 회복");
                Console.WriteLine("[3] 로비로 돌아가기");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":

                        EnterField(ref player);
                        break;

                    case "2":
                        Console.WriteLine("체력회복으로 입장합니다.");
                        Console.WriteLine($"현재 체력 조회 : {player.hp}");
                        

                        if ((int)ClassNumber == 1)
                        {
                            Console.WriteLine("검사 직업에 맞춰 100으로 회복합니다.");
                            player.hp = 100;

                        }
                        else if ((int)ClassNumber == 2)
                        {
                            Console.WriteLine("궁수에 직업에 맞춰 75로 회복합니다.");
                            player.hp = 75;

                        }

                        else if ((int)ClassNumber == 3)
                        {
                            Console.WriteLine("마법사 직업에 맞춰 50으로 회복합니다");
                            player.hp = 50;

                        }

                        break;
                

                       

                    case "3":
                        Console.WriteLine("로비로 돌아갑니다.");
                        return; // EnterGame() 함수 전체를 빠져나간다.


                }
            }
        }
        static void EnterField(ref PlayerInfo player)
        {

            Console.WriteLine("필드에 입장합니다.");
            Console.WriteLine($"현재 수집된 골드는 {player.Gold} 골드 입니다. ");
            MonsterInfo monster;
            CreateMonster(out monster);

           
            while (true)
            {
                Console.WriteLine("[1] 전투모드 돌입");
                Console.WriteLine("[2] 50%확률로 마을로 귀환");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Fight(ref player, ref monster);
                        break; //switch를 빠져나가는 break 명령이다. (while) 아님

                    case "2":
                        Random rands = new Random();
                        int RunorNoRun = rands.Next(1, 3); //확률은 50%

                        switch (RunorNoRun)
                        {
                            case 1:
                                Console.WriteLine("도망에 성공합니다. 귀환합니다.");
                                return;
                                break;

                            case 2:
                                Console.WriteLine("도망에 실패합니다. 전투모드로 돌입합니다.");
                                Fight(ref player, ref monster);
                                return;
                                break;

                        }
                        break;


                           

                }
            }


        } // 몬스터 사냥용 필드
        static void Fight(ref PlayerInfo player,ref MonsterInfo monster)
        {
            Console.WriteLine("몬스터와 전투를 시작합니다.");

            while (player.hp >= 0 && monster.hp >=0)
            {

                Random rand = new Random();
                int WhoAttack = rand.Next(1, 3);

                Console.WriteLine($"현재 당신의 체력은 {player.hp} 이고,몬스터의 체력은 {monster.hp} 입니다.  ");
                switch (WhoAttack)
                {
                    case 1:
                        player.hp -= monster.attack;
                        Console.WriteLine($"몬스터가 공격합니다. 당신의 체력이 {player.hp}가 되었습니다!");
                        break;
                    case 2:
                        monster.hp -= player.attack;
                        Console.WriteLine($"당신이 공격합니다. 몬스터의 남은 체력은 {monster.hp}가 되었습니다.");
                        break;

                }
            }

                if(player.hp >= 0&& monster.hp <=0)
                {
                    Console.WriteLine("당신이 전투에서 승리하였습니다 ! ");
                Random rand = new Random();
                int GoldRandom = rand.Next(1, 100);
                Console.WriteLine($"{GoldRandom} 골드 획득 !");
                player.Gold = GoldRandom;

                }
                else if (monster.hp >= 0 && player.hp <=0)
                    Console.WriteLine("당신이 전투에서 패배하였습니다 ! ");
     
            
        }



        static void Main(string[] args)
        {
            ClassType ClassNumber = ClassType.None; // 초기값, 직업 미선택
            MonsterType MonsterNumber = MonsterType.None; //초기값, 몬스터 미선택
            /*=========================================================================================*/
            while (true)
            {
                ClassNumber = ChooseClass(); // 직업선택함수에서 리턴되는 값을 ClassNumber에 저장하여 while문 탈출검사

                if (ClassNumber != ClassType.None)
                {
                    PlayerInfo player; //전투 시 실제 플레이어의 체력을 깎아야 하기 때문에 ref로 넘긴다. 
                    CreatePlayer(ClassNumber, out player);
                    Console.WriteLine("최종적인 캐릭터 생성 완료");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("==========================");
                    EnterGame(ClassNumber,ref player);

                   

                }
            }

        }

    }
}