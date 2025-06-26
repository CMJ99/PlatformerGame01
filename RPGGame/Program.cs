using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGame
{

    class Player
    {
        public string Name { get; set; }
        int nAtk;
        int nHP;
        int nMaxHP;

        int nExp;
        int nMaxExp;

        int nLv;
        
        

        List<Player> listMonster = new List<Player>();

        public void GetMonster(Player target)
        {
            listMonster.Add(target);
        }

        public Player ThrowMonster(string name)
        {
            return listMonster.Find(monster => monster.Name  == name);
        }
        

        public Player(string name, int hp = 100, int atk = 10, int exp = 100)//생성자 : 클래스가 생성시 호출되는 함수.
        {
            Name = name;
            nAtk = atk;
            nHP = hp;
            nExp = exp;
            nMaxExp = 100;
            nMaxHP = hp;
            nLv = 1;
        }

        public void Attack(Player target)
        {
            target.nHP = target.nHP - this.nAtk;
            //target.nHP -= this.nAtk;
        }

        public bool Death()
        {
            if (this.nHP <= 0)
                return true;
            else
                return false;
        }
        //몬스터가 죽으면, 죽은몬스터로 부터 경험치를 가져온다.
        //데이터: 플레이어의 경험치, 몬스터의 경험치, 레벨
        //알고리즘: 몬스터가 사망하면 플레어가 몬스터의 경험치를 가져온다.
        //렙업한다. 만약 경험치가 최대 경험치가되면 
        //데이터: 경험치,레벨,최대 경험치
        //알고리즘: 만약 경험치가 최대경험치보다 크다면, 레벨이 1 오른다.
        public void StillExp(Player target)
        {
            this.nExp += target.nExp;
            if (this.nExp >= this.nMaxExp)// 0 <= 100 -> 1 T // 0 >= 100 -> 1 F
            {
               
            }
        }

        public bool LvUPCheck()
        {
            if (this.nExp >= this.nMaxExp)// 0 <= 100 -> 1 T // 0 >= 100 -> 1 F
            {
                nLv++;
                nAtk += 5;
                nHP += 5;
                nMaxHP += 5;
                nExp = 0;
                Console.WriteLine("LvUp[" + nLv + "]:" + this.nExp + "/" + this.nMaxExp);
                return true;
            }
            return false;

            
        }

        public void Recovery()
        {
            nHP = nMaxHP;
        }

        public void Display()
        {
            
            Console.WriteLine(Name + " Atk/HP:" + this.nAtk + "/" + this.nHP);
            Console.WriteLine(Name + " Lv/Exp:" + this.nLv + "(" + this.nExp+"/" + this.nMaxExp+")");
        }
    }

    internal class Program
    {

        public static void BattleMain(Player player, Player monster)
        {
            //플레이어가 살아있을 때(죽었을 때가 아닐 때) 그리고, 몬스터가 살아있을때 (죽었을 때)가 아닐 때
            //플레이어가 살아있고, 몬스터가 살아있을 때 -> 플레이어도 몬스터도 살아있다.
            //플레이어도 몬스터도 살아 있을 때 반복한다.
            while (!player.Death() && !monster.Death())
            {

                //플레이어가 죽었을 떄가 아닐 때 //플레이어가 살아 있을때
                if (player.Death() == false)
                {
                    Console.WriteLine("=========Player Trun===========");
                    //플레이어가 몬스터를 공격하고 플레이어와 몬스터의 능력치를 확인했다.
                    player.Attack(monster); //플레이어가 몬스터를 공격한다.
                    player.Display(); //플레이어의 능력치를 확인(출력)한다.
                    monster.Display(); //몬스터의 능력치를 확인(출력)한다.
                }
                else //플레이어가 죽었을 때가 아닐때가 아닐 때 //플레이어가 죽었을때
                    Console.WriteLine("Player Death!");

                //몬스터가 죽었을 때가 아닐 때 -> 몬스터가 살아있을 때
                if (monster.Death() == false)
                {
                   
                    Console.WriteLine("=========Monster Trun===========");
                    //몬스터가 플레이어를 공격하고 몬스터와 플레이어의 능력치를 확인했다
                    monster.Attack(player);//몬스터가 플레이어를 공격한다
                    player.Display();//플레이어의 능력치를 확인한다.
                    monster.Display();//몬스터의 능력치를 확인한다.
                    

                }
                else
                {
                    Console.WriteLine("Monster Death!");
                    player.StillExp(monster);
                    player.LvUPCheck();
                    player.GetMonster(monster);
                    
                    
                   
                }
                    

                Console.WriteLine("==============================");
            }
            monster.Recovery();

        }


        public static void MonsterSelectMain()
        {
            int nPlayerAtk;
            int nPlayerHP;
            string strPlayerName;
            Console.WriteLine("플레이어의 이름을 설정하세요");
            strPlayerName = Console.ReadLine();
            Console.WriteLine("플레이어의 공격력을 입력하세요");
            nPlayerAtk = int.Parse(Console.ReadLine());
            Console.WriteLine("플레이어의 체력을 입력하세요");
            nPlayerHP = int.Parse(Console.ReadLine());

            Player player = new Player(strPlayerName, nPlayerHP, nPlayerAtk); //플레이어 생성 : 플레이어의 이름을 "Player"로 생성하고, 체력과 공격력을 각각 20/10으로 설정한다.
            Player monster = null; //싸울몬스터 : 현재는 싸울 몬스터가 없다.

            while (true)
            {


                Console.WriteLine("이동 할 장소를 입력하세요.(평원,무덤,던전,계곡)");

                string strInput = Console.ReadLine();

                int nMonsterAtk = 10;
                int nMonsterHP = 100;
                string strMonster = "none";

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

                Player myMonster = player.ThrowMonster("슬라임");

                monster = new Player(strMonster, nMonsterHP, nMonsterAtk);
                


                if (myMonster != null)
                    BattleMain(myMonster, monster);
                else
                    BattleMain(player, monster);

                if (player.Death())
                {
                    Console.WriteLine("GameOver");
                }
                    
            }
        }

        

        static void Main(string[] args)
        {
            MonsterSelectMain();
        }
    }
}
