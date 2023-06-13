using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*게임 진행에 대한 전반적인 사항을 관리*/

namespace TextRPG_OOP_ver0._1
{
    public enum GameMode
    {

        None = 0,
        Lobby = 1,
        Town = 2,
        Field = 3

    }

    class Game
    {
        private Random rand = new Random();
        private GameMode mode = GameMode.Lobby;
        private Player player = null; //아무것도 가리키고 있지않은 상태
        private Monster monster = null; //아무것도 가리키고 있지않은 상태
        public void Process()
        {
            switch (mode)
            {
                case GameMode.Lobby:
                    ProcessLobby();

                    break;

                case GameMode.Town:
                    ProcessTown();

                    break;
                case GameMode.Field:
                    ProcessField();
                    break;

            }
        }

        private void ProcessLobby()
        {
            Console.WriteLine("직업을 선택하세요.");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    player = new Knight();
                    mode = GameMode.Town; //모드가 변경되므로 스위치문이 종료되면 자연스럽게 ProcessLobby()함수가 종료되면서 다시 메인문 Process 함수를 거쳐 마을로 입장
                    break;
                case "2":
                    player = new Archor();
                    mode = GameMode.Town;

                    break;
                case "3":
                    player = new Mage();
                    mode = GameMode.Town;

                    break;

            }
        }
        private void ProcessTown()
        {
            Console.WriteLine("마을에 입장하였습니다.");
            Console.WriteLine("[1] 필드로 가기");
            Console.WriteLine("[2] 로비로 돌아가기");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    mode = GameMode.Field;
                    Console.WriteLine($"남은체력 :{player.GetHp()} ");

                    break;
                case "2":
                    mode = GameMode.Lobby;

                    break;


            }
        }

        private void ProcessField()
        {
            Console.WriteLine("필드에 입장하였습니다.");
            Console.WriteLine("[1] 전투하기");
            Console.WriteLine("[2] 마을로 돌아가기");

            CreateRandomMonster();

            string input = Console.ReadLine();

            switch (input)
            {

                case "1":
                    ProcessFight();
                    Console.WriteLine($"남은체력 :{player.GetHp()} ");

                    break;
                case "2":
                    mode = GameMode.Town;

                    break;

            }


        }


        private void CreateRandomMonster()
        {
            int RandValue = rand.Next(1, 4);
            switch (RandValue)
            {
                case 1: //슬라임

                    Console.WriteLine("슬라임이 생성 되었습니다.");
                    monster = new Slime();
                    break;
                case 2: //오크

                    Console.WriteLine("오크가 생성되었습니다.");
                    monster = new Orc();

                    break;

                case 3: //스켈레톤
                    Console.WriteLine("스켈레톤이 생성되었습니다.");
                    monster = new Skeleton();

                    break;



            }
        }
        private void ProcessFight()
        {
            int Playerdamage = player.GetAttack();
            int Monsterdamage = monster.GetAttack();
            int PlayerHp = player.GetHp();
            int MonsterHp = monster.GetHp();

            while (true)
            {
                Random rand = new Random();

                int DamageTurn = rand.Next(0, 2);

                switch (DamageTurn)
                {
                    case 0:
                        player.OnDamaged(Monsterdamage);
                        Console.WriteLine("몬스터가 공격합니다.");
                        Console.WriteLine($"플레이어의 체력이 {player.GetHp()}가 되었습니다.");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("==================================================");
                        break;

                    case 1:

                        monster.OnDamaged(Playerdamage);
                        Console.WriteLine("플레이어가 공격합니다.");
                        Console.WriteLine($"몬스터의 체력이 {monster.GetHp()}가 되었습니다.");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("================================================");
                        break;

                }


                if (monster.IsDead())
                {
                    Console.WriteLine("전투에서 승리하였습니다.");
                    break;
                }

                else if (player.IsDead())
                {
                    Console.WriteLine("전투에서 패배하였습니다.");
                    break;
                }
            }

        }

    }
}

