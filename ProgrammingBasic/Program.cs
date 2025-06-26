namespace ProgrammingBasic
{

    internal class RPGPlayer
    {
        public static void BattleMain(Player player, Player monster)
        {
            while (!player.Death() && !monster.Death())
            {
                if (player.Death() == false)
                {
                    Console.WriteLine("=========Player Trun===========");
                    player.Attack(monster);
                    player.Display();
                    monster.Display();
                }
                else
                    Console.WriteLine("Player Death!");

                if (monster.Death() == false)
                {
                    Console.WriteLine("=========Monster Trun===========");
                    monster.Attack(player);
                    player.Display();
                    monster.Display();

                }
                else
                    Console.WriteLine("Monster Death!");

                Console.WriteLine("==============================");
            }
        }
        public static void MonsterSelectMain()
        {
            
            Console.WriteLine("이동 할 장소를 입력하세요.(평원,무덤,던전,계곡)");

            string strInput = Console.ReadLine();

            int nMonsterAtk = 10;
            int nMonsterHP = 100;
            string strMonster = "none";

            while (true)
            {

                
                switch (strInput)
                {

                    case "평원":
                        Console.WriteLine("슬라임이 출연합니다.");
                        strMonster = "슬라임";
                        nMonsterAtk = 5;
                        nMonsterHP = 20;
                        break;
                    case "무덤":
                        Console.WriteLine("스켈레톤 출연합니다.");
                        strMonster = "스켈레톤";
                        nMonsterAtk = 10;
                        nMonsterHP = 30;
                        break;
                    case "던전":
                        Console.WriteLine("좀비 출연 합니다.");
                        strMonster = "좀비";
                        nMonsterAtk = 20;
                        nMonsterHP = 50;
                        break;
                    case "계곡":
                        strMonster = "드래곤";
                        Console.WriteLine("드래곤이 출연 합니다.");
                        nMonsterAtk = 50;
                        nMonsterHP = 200;
                        break;
                    default:
                        Console.WriteLine("장소를 잘못입력했습니다.");
                        break;
                }
            }

            Player player = new Player("Player", 20, 10, 10, 1);
            Player monster = new Player(strMonster, nMonsterAtk, nMonsterHP);

            BattleMain(player, monster);
        }

        public static void SelectFieldBattleMain()
        {
            
            List<Player> listMoster = new List<Player>();
            listMoster.Add(new Player("slime", 5, 20, 30));
            listMoster.Add(new Player("skeleton", 10, 30, 30));
            listMoster.Add(new Player("zombie", 20, 50, 30));
            listMoster.Add(new Player("dragon", 50, 200, 90));
            Player player = new Player("Player", 20, 10, 10, 1);

            while (true)
            {
                int nSeletIdx = -1;
                Console.WriteLine("이동 할 장소를 입력하세요.(평원,무덤,던전,계곡)");

                string strInput = Console.ReadLine();

                
                switch (strInput)
                {
                    case "평원":
                        Console.WriteLine("슬라임이 출연합니다.");
                        nSeletIdx = 0;
                        break;
                    case "무덤":
                        Console.WriteLine("스켈레톤 출연합니다.");
                        nSeletIdx = 1;
                        break;
                    case "던전":
                        Console.WriteLine("좀비 출연 합니다.");
                        nSeletIdx = 2;
                        break;
                    case "계곡":
                        nSeletIdx = 3;
                        break;
                    default:
                        Console.WriteLine("장소를 잘못입력했습니다.");
                        break;
                }

                
                Player monster = listMoster[nSeletIdx];

                BattleMain(player, monster);


                if (player.Death())
                {
                    Console.WriteLine("Game Over!");
                    break;
                }

               
                    if (monster.Death())
                    {
                        Console.WriteLine("몬스터 처치");
                        player.StillExp(monster); //경험치 흭득
                        player.LevelUp(player); //레벨업 확인
                    

                    }

                
                    if (listMoster[3].Death())
                    {
                        Console.WriteLine("몬스터 처치");

                        Console.WriteLine("The End!");
                        break;

                    }
                
            }
        }


        public static void ClassPlayerBattleMain()
        {   //몬스터를 처치했을 때 플레이어의 경험치가 일정이상 넘어가면 레벨업을 한다
            //데이터: 플레이어 경험치, 플레이어의 레벨, 몬스터가 주는 경험치
            //알고리즘: 몬스터를 처치하면 플레이어는 경험치는 얻는다. 몬스터를 죽이면 몬스터의 경험치를 가져와서 플레이어는 경험치가 지정된 수치를 넘으면 레벨업을 한다

            Player Player = new Player("Player", 20, 10, 20, 1);
            Player monster = new Player("Monster", 20, 10, 20, 1);

            while (!Player.Death() && !monster.Death())
            {
                if (Player.Death() == false)
                {
                    Console.WriteLine("=========Player Trun===========");
                    Player.Attack(monster);
                    Player.Display();
                    monster.Display();
                }
                else
                    Console.WriteLine("Player Death!");


                if (monster.Death() == false)
                {
                    Console.WriteLine("=========Monster Trun===========");
                    monster.Attack(Player);
                    monster.Display();
                    Player.Display();



                }
                else
                {
                    Console.WriteLine("Monster Death!");
                    Player.StillExp(monster);
                    Player.LevelUp(Player);
                    break;

                }

                Console.WriteLine("==============================");
            }
        }
    }
    class Player
    {
        public string Name { get; set; }
        int nAtk;
        int nHP;
        int nExp;
        int nLevel;
        

        public Player(string name, int hp = 100, int atk = 10, int Exp = 10, int Level = 1)
        {
            Name = name;
            nAtk = atk;
            nHP = hp;
            nExp = Exp;
            nLevel = Level;

        }

        public void Attack(Player target)
        {
            target.nHP = target.nHP - this.nAtk;
            //target.nHP -= this.nAtk; 위와 같은 의미
        }


        public bool Death()
        {
            if (this.nHP <= 0)
                return true;
            else
                return false;
        }

        //몬스터가 죽으면, 죽은몬스터로 부터 경험치를 가져온다.
        //데이터: 플레이어의 경험치, 몬스터의 경험치
        //알고리즘: 몬스터가 사망하면 플레어가 몬스터의 경험치를 가져온다.
        //렙업한다. 만약 경험치가 최대 경험치가되면 
        //데이터: 경험치,렙업,최대 경험치
        //알고리즘: 만약 경험치가 최대경험치보다 크다면, 레벨이 1 오른다.

        public void Display(string msg = "")
        {
            Console.WriteLine(msg);
            Console.WriteLine(Name + " Atk:" + this.nAtk + "/" + "HP: " + this.nHP + "/" + "Exp" + +this.nExp + "/" + "LV" + this.nLevel);
        }
        public void StillExp(Player Target)//몬스터의 경험치 가져오기
        {
            this.nExp = this.nExp + Target.nExp;
            Console.WriteLine("경험치흭득");
            
        }
        public void LevelUp(Player Target)
        {
            while(this.nExp >= 30)
            {
                this.nExp -= 30;// 초과된 경험치는 남기도록
                this.nLevel += 1;//레벨증가
                Console.WriteLine("Player 레벨업 현재 레벨 : " + nLevel);
                this.nAtk += 10;//플레이어 공격력 증가
                Console.WriteLine("Player 현재 공격력 " + nAtk);
                this.nHP += 30;//hp증가
                Console.WriteLine("Player 현재 체력증가: " + nHP);
               
            }
     
        }
        
        
        internal class Program
        {
            static void Main(string[] args)
            {
                //Console.WriteLine("Hello, World! 최민재");
                //Console.WriteLine("Add:" + Add(10, 20));//세미콜론
                //ValMain();
                //CritcalAttackMain();
                //StageMain();
                //AttackWile();
                //MonserListMain();//함수의 호출(사용)
                //PlayerAttackMain();
                //AttackCriticalWhile();
                //PlayerBattleMain();
                //MonsterSelectMain();
                //ClassPlayerBattleMain();
                RPGPlayer.SelectFieldBattleMain();





                static void ClassPlayerBattleMain()
                {

                    Player player = new Player("Player", 20, 10);
                    Player monster = new Player("Monster", 20, 10);
                    while (!player.Death() && !monster.Death())
                    {

                        if (player.Death() == false)
                        {

                            player.Attack(monster);
                            player.Display("[Player Turn]");
                            monster.Display("[Player Turn]");
                        }
                        monster.Attack(player);
                        player.Display("[Monster Turn]");
                        monster.Display("[Monster Turn]");
                    }
                }
            }
            //몬스터를 처치했을 때 플레이어의 경험치가 일정이상 넘어가면 레벨업을 한다
            //데이터: 플레이어 경험치, 플레이어의 레벨, 몬스터가 주는 경험치
            //알고리즘: 몬스터를 처치하면 플레이어는 경험치는 얻는다. 몬스터를 죽이면 몬스터의 경험치를 가져와서 플레이어는 경험치량이 일정이상 넘으면 레벨업을 한다
            static void Exp()
            {
                int nPlayerAtk = 10;
                int nMonsterAtk = 5;
                int nPlayerHP = 20;
                int nMonsterHP = 10;
                int nPlayerLv = 1;

                Console.WriteLine("플레이어의 레벨" + nPlayerLv);
                int nPlayerExp = 10;
                Console.WriteLine("플레이어의 경험치" + nPlayerExp);
                int nMonsterExp = 20;
                Console.WriteLine("몬스터의 경험치" + nMonsterExp);

                while (nMonsterHP>=0)
                {
                    Console.WriteLine("플레이어의 공격력:" + nPlayerAtk + "남은 몬스터의 hp" + nMonsterHP);
                    if (nMonsterHP <= 0) break;

                    nMonsterHP = nMonsterHP - nPlayerAtk;


                }
                Console.WriteLine("몬스터처치");

                nPlayerExp = nPlayerExp + nMonsterExp;
                Console.WriteLine("몬스터의 경험치 흭득: " + nMonsterExp +" 현재 플레이어의 경험치 :" + nPlayerExp);
                if (nPlayerExp <= 30)
                {
                    Console.WriteLine("플레이어 레벨업 현재 레벨: " + (nPlayerLv + 1));
                }
                else
                    nPlayerExp = nPlayerExp + nMonsterExp;

            }
            

            static int Add(int a, int b)//매개변수(10,20)
            {
                int c = a + b; //10 + 20 = 30
                return c; //30
            }



            static void ValMain()
            {
                int nScore = 0;
                float fRat = 1.0f / 4.0f;
                Console.WriteLine("Score:" + nScore);
                Console.WriteLine("Rat:" + fRat);

            }

            //몬스터가 플레이어를 공격한다 ->몬스터가 공격했을 때 (플레이어의 피)가 깍인다.
            //몬스터는 공격력 < 플레이어는 체력 제공, 공격: 공격력으로 피를 깍는 행위
            //데이터: 바뀌는 것. (체력). (몬스터공격력)
            //알고리즘: 몬스터의 공격력으로 플레이어의 체력을 깍는다. 체력 - 공격력
            //값을 설정하지않아서 작동하지않는다. 각 값 공격력을 10, 체력 100으로 설정한다
            static void PlayerAttackMain()
            {
                int nMonsterAtk = 10;
                int nPlayerHP = 100;
                Console.WriteLine("몬스터의 공격력: " + nMonsterAtk + "남은 hp:" + nPlayerHP);
                nPlayerHP = nPlayerHP - nMonsterAtk;
                Console.WriteLine("몬스터의 공격력: " + nMonsterAtk + "남은 hp:" + nPlayerHP);
            }
            //플레이어가 (몬스터를) 공격을 할 때 일정확률로 크리티컬이 터진다.
            //플레이어가 공격 -> 플레이어의 공격력. 몬스터의 체력이 필요하다.
            //데이터 : 플레이어의 공격력, 몬스터의 체력
            //알고리즘: 플레이어가 몬스터를 공격하는데 일정확률로 크리티컬이 발생한다. 
            //일정확률? -> 플레이어가 몬스터를 공격한다.-> 때릴 때 일정확률로 크리티컬발생하고. 데미지가 1.5배가 된다.
            static void CritcalAttackMain()
            {
                Console.WriteLine("CriticalAttackMain");
                int nPlayerAtk = 10;
                int nMonsterHP = 100;
                Random cRandom = new Random();
                int nRandom = cRandom.Next(1, 3);//1~2의 값이 나온다. 1/2
                                                 //int nRandom = cRandom.Next(0, 3);//0, 1 ,2의 값이 나온다 1/3
                Console.WriteLine("몬스터의 공격력: " + nPlayerAtk + "남은 hp:" + nMonsterHP);//공격하기전에 데미지를 1.5배 증가시킨다
                if (nRandom == 1)
                {
                    Console.WriteLine("CriticalAttack!");
                    nMonsterHP = nMonsterHP - (int)(nPlayerAtk * 1.5f);//몬스터를 때린다.
                }
                else
                    nMonsterHP = nMonsterHP - nPlayerAtk;//몬스터를 때린다.
                Console.WriteLine("몬스터의 공격력: " + nPlayerAtk + "남은 hp:" + nMonsterHP);
                Console.WriteLine("Random:" + nRandom);
            }
            //마을,필드,상점 중에서 이동장소를 입력하면 그 장소의 이름이 나오는 프로그램작성.
            //데이터: 마을,필드,상점 입력값
            //알고리즘: 입려값이 마을이면 마을입니다 라고 출력하고 필드면.. 상점..
            static void StageMain()
            {
                Console.WriteLine("StageMain");
                string strTown = "마을";
                string strField = "사낭터";
                string strStore = "상점";

                Console.WriteLine("이동 할 장소를 입력하세요.(마을,사냥터,상점)");
                string strInput = Console.ReadLine();

                switch (strInput)
                {
                    case "마을":
                        Console.WriteLine("마을 입니다");
                        break;
                    case "사냥터":
                        Console.WriteLine("사냥터 입니다");
                        break;
                    case "상점":
                        Console.WriteLine("상점 입니다");
                        break;
                    default:
                        Console.WriteLine("장소를 잘못입력했습니다");
                        break;



                }
                Console.WriteLine("StageMain");

            }
            //몬스터가 플레이어를 (죽을 때 까지:플레이어의 hp가 0이 될때) 공격한다.
            //

            static void AttackWile()
            {
                Console.WriteLine("AttackWile");
                int nMonsterAtk = 10;
                int nPlayerHP = 100;
                Random qRandom = new Random();
                while (true)
                {

                    int bRandom = qRandom.Next(1, 3);
                    if (bRandom == 1)

                    {
                        nMonsterAtk = (int)(nMonsterAtk * 1.5);
                        nPlayerHP = nPlayerHP - nMonsterAtk;
                        Console.WriteLine("크리티컬!:" + nMonsterAtk);
                    }


                    Console.WriteLine("공격전,몬스터의 공격력: " + nMonsterAtk + "남은 hp:" + nPlayerHP);
                    if (nPlayerHP <= 0)//죽었을 때 공격을 중단한다
                    {


                        //Console.WhireLine("플레이어 사망 return") retuen;
                        Console.WriteLine("플레이어 사망 break");
                        break;
                    }
                    else
                        nPlayerHP = nPlayerHP - nMonsterAtk;
                    Console.WriteLine("공격후,몬스터의 공격력:" + nMonsterAtk + "남은 hp" + nPlayerHP);
                }

                //몬스터가 플레이어를 죽을 때 까지 (일정확률로 크리티컬)이 발생하여 추가 데미지만큼 공격한다.

                //몬스터가 플레이어를 공격한다.
                //몬스터가 플레이어를 죽을 때 가지 공격할 때 공격하기전에 확률을 계산하여 크리티컬데미지를 추가하여 공격하고, 크리티컬이 터지지않으면,데미지가 증가되지 않는다.

                //A.먼저 반복문을 돌리는 경우
                //1.몬스터가 플레이어를 일단 계속 공격한다 
                //2.플레이어가 언제 죽었는지를 확인하고 조건문을 설정한다.
                //B.언제 플레이어가 살아있는지 확인한다.
                //1.몬스터가 살아 있을때만 공격해야한다.-> while문의 조건을 설정한다
                //몬스터가 플레이어를 공격할 때 크리티컬이 발생하면 데미지가 1.5배 일시적으로 증가한다.
            }
            static void AttackCriticalWhile()
            {
                Console.WriteLine("AttackCriticalWile");
                int nMonsterAtk = 11;
                int nPlayerHP = 100;
                Random cRandom = new Random();//랜덤을 생성한다. //랜덤을 계산해주는 물건을 만든다
                                              //살아있을 때 공격을 한다.//코드가 쉽다->코드가 짧다.//햇갈리지않는다-> 이 조건을 그대로 생각한다.
                while (nPlayerHP > 0)
                {
                    Console.WriteLine("공격전. 몬스터의 공격력:" + nMonsterAtk + "남은 hp" + nPlayerHP);
                    //일정확률로 공격하기전에 데미지를 1.5배 증가시킨다.
                    //Random cRandom = new Random(); //랜덤을 하기 전에 생성한다.
                    int nRandom = cRandom.Next(1, 3);// 랜덤값을 생성한다. //랜덤기를 이용해서 숫자를 생선한다

                    if (nRandom == 1)
                    {

                        int nCriticalAttack = (int)(nMonsterAtk * 1.5); //크리티컬데미지를 미리저장해서 알기쉽게 계산해둔다.
                        nPlayerHP = nPlayerHP - nCriticalAttack; //공격을 할 때 1회성으로 계산된 데미지를 사용한다.
                        Console.WriteLine("크리티컬" + nCriticalAttack);
                    }
                    else
                        nPlayerHP = nPlayerHP - nMonsterAtk;
                    Console.WriteLine("공격후, 몬스터의 공격력:" + nMonsterAtk + "남은 hp" + nPlayerHP);
                    //랜덤을 끝나면 삭제한다

                }
            }

            //생성된 랜덤기를 삭제한다.

            //플레이어가 (공격:데미지)하면 몬스터는 (반격:맞고나서 공격(한 대상에게 데미지)를 준다.)하고, 둘 중 하나가 죽을 때(플레이어나 몬스터의 hp가 0보다 작을 때)까지 전투가 끝나지않고 한 쪽이 죽으면 끝남.
            //데이터 : 플레이어의 공격력, 플레이어의 체력, 몬스터의 공격력, 몬스터의 체력
            //알고리즘 : 플레이어가 먼저 공격하고, 몬스터가 맞고나서 공격 한다. 한 쪽이 죽을 때 까지.
            static void PlayerBattleMain()
            {
                Console.WriteLine("PlayerBattleMain");

                int nPlayerHP = 20;
                int nPlayerAtk = 10;

                int nMonsterHP = 30;
                int nMonsterAtk = 10;

                //while(true) //프로그래밍 문법에서 이러한 사용은 금기시되므로 추후, 아래와 같이 브레이킁문의 반대조건을 추가하거나 조건응ㄹ 모두 넣어 만일에 사태를 대비한다.
                while (nPlayerHP > 0 == nMonsterHP > 0)
                {

                    //플레이어는 몬스터를 언제 공격하지않는가? //플레이어가 언제 공격을 멈추는가? //이 모든 조건이 일반적인 인간에게는 당연한것이다.

                    if (nPlayerHP <= 0)
                    {
                        Console.WriteLine("플레이어가 사망했다");
                        break;
                    }
                    Console.WriteLine("플레이어가 몬스터를 공격한다");
                    nMonsterHP = nMonsterHP - nPlayerAtk; //플레이어가 몬스터를 공격한다.
                    Console.WriteLine("Player atk/HP:" + nPlayerAtk + "/" + nPlayerHP);
                    Console.WriteLine("Monster Atk/HP:" + nMonsterAtk + "/" + nMonsterHP);

                    //몬스터가 죽었을 때는 몬스터가 공격 할 수 없다.
                    if (nMonsterHP <= 0)
                    {
                        Console.WriteLine("몬스터가 사망했다!");
                        break;
                    }
                    Console.WriteLine("몬스터가 플레이어를 공격한다");
                    nPlayerHP = nPlayerHP - nMonsterAtk;//몬스터가 플레이어를 공격한다.
                    Console.WriteLine("Player atk/HP:" + nPlayerAtk + "/" + nPlayerHP);
                    Console.WriteLine("Monster Atk/HP:" + nMonsterAtk + "/" + nMonsterHP);
                }

            }
            





            static void MonserListMain()
            {
                Console.WriteLine("MonsterListMain");

                List<string> listMonster = new List<string>();

                listMonster.Add("슬라임");
                listMonster.Add("스켈레톤");
                listMonster.Add("좀비");
                listMonster.Add("드래곤");
                //첫번째값은 [0]으로 접근하고.마지막값은 몬스터수 -1이 마지막 값이다.
                Console.WriteLine(listMonster[0]);
                Console.WriteLine(listMonster[3]);
                //Console.WriteLine(listMonster[4]); //잘못된 접근을 하면 프로그램이 죽는다.

                //for문을 이용해 반복해서 출력한다.
                for (int i = 0; i < listMonster.Count; i++)
                    Console.WriteLine(string.Format("monster[{0}]: {1}", i, listMonster[i]));



            }

            static void MonsterSelectMain()
            {
                Console.WriteLine("이동 할 장소를 입력하세요.(평원, 무덤, 던전, 계곡)");
                string strInput = Console.ReadLine();

                int nPlayerHP = 20;
                int nPlayerAtk = 10;
                int nMonsterAtk = 10;
                int nMonsterHP = 100;


                switch (strInput)
                {
                    case "평원":
                        Console.WriteLine("슬라임이 출연합니다");
                        nMonsterAtk = 5;
                        nMonsterHP = 20;
                        break;
                    case "무덤":
                        Console.WriteLine("스켈레톤이 출연합니다");
                        nMonsterAtk = 10;
                        nMonsterHP = 30;
                        break;
                    case "던전":
                        Console.WriteLine("드래곤이 출연 합니다");
                        nMonsterAtk = 20;
                        nMonsterHP = 50;
                        break;
                    case "계곡":
                        Console.WriteLine("드래곤이 출연합니다");
                        nMonsterAtk = 50;
                        nMonsterHP = 200;
                        break;
                    default:
                        Console.WriteLine("장소를 잘못입력했습니다");
                        break;
                }

                //여기에 전투코드를 삽입하면 작동한다
                while (nPlayerHP > 0 == nMonsterHP > 0)
                {

                    //플레이어는 몬스터를 언제 공격하지않는가? //플레이어가 언제 공격을 멈추는가? //이 모든 조건이 일반적인 인간에게는 당연한것이다.

                    if (nPlayerHP <= 0)
                    {
                        Console.WriteLine("플레이어가 사망했다");
                        break;
                    }
                    Console.WriteLine("플레이어가 몬스터를 공격한다");
                    nMonsterHP = nMonsterHP - nPlayerAtk; //플레이어가 몬스터를 공격한다.
                    Console.WriteLine("Player atk/HP:" + nPlayerAtk + "/" + nPlayerHP);
                    Console.WriteLine("Monster Atk/HP:" + nMonsterAtk + "/" + nMonsterHP);

                    //몬스터가 죽었을 때는 몬스터가 공격 할 수 없다.
                    if (nMonsterHP <= 0)
                    {
                        Console.WriteLine("몬스터가 사망했다!");
                        break;
                    }
                    Console.WriteLine("몬스터가 플레이어를 공격한다");
                    nPlayerHP = nPlayerHP - nMonsterAtk;//몬스터가 플레이어를 공격한다.
                    Console.WriteLine("Player atk/HP:" + nPlayerAtk + "/" + nPlayerHP);
                    Console.WriteLine("Monster Atk/HP:" + nMonsterAtk + "/" + nMonsterHP);

                }
            }
        }


    }
}





