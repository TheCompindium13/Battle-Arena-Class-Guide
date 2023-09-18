using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    //Basic weapon structure
    struct WeaponBasics
    {
        public string WeaponName;
        public float WeaponDamage;
        public bool WeaponTalks;

    }
    class Game
    { 

        //Character structure




        //Basic variables
        bool GameOver;
        int Currentscene = 0;
        string Playerchoice = "";
        
        //Monsters
        Character JoePablo;
        Character JOHNcena;
        Character LJDBiden;
        Character[] Enemies;
        int currentenemyindex = 0;

        //Player
        Character Player;

        //How to create desecions
        string Getinput(string prompt, string option1, string option2, string option3)
        {
            Console.WriteLine(prompt);
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.WriteLine("3." + option3);

            Playerchoice = Console.ReadLine();

            return Playerchoice;

        }
        
        
        //Character selection scene 
        void Characterselectionscene()
        {
            string characterchoice = Getinput("Choose your character", " JoePablo", " JOHN... cena", " LucyJillDirtbagBiden");
            {
                if (Playerchoice == "1")
                {
                    Player = JoePablo;
                }
                else if (Playerchoice == "2")
                {
                    Player = JOHNcena;
                }
                else if (Playerchoice == "3")
                {
                    Player = LJDBiden;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey(true);
                    Console.Clear();
                    return;
                }
                Player.PrintStats();
                Console.ReadKey(true);
                Console.Clear();
                Currentscene = 1;
            }
            
           
        }



        //How the healing works
        float Heal(Character monster, float healamount)
        {
            float newhealth = monster.GetHealth() * healamount;

            return newhealth;
        }

        //The healing scene starts here
        void Healscene()
        {
            Heal(Player, 1000);
        }



        //Fighting logic for fight
        void Fight(ref Character monster2)
        {
            
            Player.PrintStats();
            monster2.PrintStats();
            bool Isdefending = false;

            string Battlechoice = Getinput("Choose action", " Attack", " Defend", " Run");
            if (Battlechoice == "1")
            {
                monster2.takedamage(Player.GetDamage());
                Console.WriteLine("You hit the monster");


                if (monster2.GetHealth() <= 0)
                {
                    return;
                }
            }
            else if (Battlechoice == "2")
            {
                Isdefending = true;
                Player.BoostDefense();
                Console.WriteLine("You brace for impact");
            }
            else if(Battlechoice == "3")
            {
                Console.WriteLine("You ran... coward");
                Currentscene = 3;
                return;
            }

            Player.PrintStats();
            monster2.PrintStats();

            Console.WriteLine(monster2.GetName() + " Punches " + Player.GetName());
            Player.takedamage(monster2.GetDamage());
            Console.ReadKey(true);

            Player.PrintStats();
            monster2.PrintStats();
            if (Isdefending = true)
            {
                Player.LowerDefense();
            }
        }

        //The battle logic
        void Battlescene()
        {
            Fight(ref Enemies [currentenemyindex]);

            if (Enemies[currentenemyindex].GetHealth() <= 0 || Player.GetHealth() <= 0)
            {
                Currentscene = 3;
            }

        }
        

        void Arraytest(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < sum)
                {

                }
                else
                {
                    sum = numbers[i];
                }
            }
            Console.WriteLine(sum);
            Console.ReadLine();

            return;
        }
        //See this screen when you win
        void Winresultscene()
        {
            if (Player.GetHealth() > 0 && Enemies[currentenemyindex].GetHealth() <= 0)
            {
                Console.WriteLine("The Winner Is: " + Player.GetName());
                Currentscene = 1;
                currentenemyindex++;
                if (currentenemyindex >= Enemies.Length)
                {
                    GameOver = true;
                }
            }
            else if (Enemies[currentenemyindex].GetHealth() > 0 && Player.GetHealth() <= 0)
            {
                Console.WriteLine("The Winner Is: " + Enemies[currentenemyindex].GetName());
                Currentscene = 4;
            }
            Console.ReadKey(true);
            Console.Clear();
        }

        void Endgamescene()
        {
            string Playerchoice = Getinput("You are dead", "Yes", "No", "Nope");

            if (Playerchoice == "1")
            {
                Currentscene = 0;
            }
            else if (Playerchoice == "2")
            {
                GameOver = true;
            }
            else if (Playerchoice == "3")
            {
                GameOver = true;
            }
        }

        //Start non-visable elements
        void start()
        {



            //Weapons Stats
            WeaponBasics MagicBall;
            MagicBall.WeaponName = "'Magic' 9 Ball";
            MagicBall.WeaponTalks = true;
            MagicBall.WeaponDamage = 0;

            WeaponBasics TheseHands;
            TheseHands.WeaponName = "These Hands";
            TheseHands.WeaponTalks = false;
            TheseHands.WeaponDamage = 500;

            JoePablo = new Character("JoePablo", 21799f, 69.420f, .9f, 3f, TheseHands);
            
            JoePablo = new Character("JOHN... cena", 21800f, 69.421f, 1.9f, 4f, TheseHands);
            
            JoePablo = new Character("LucyJillDirtbagBiden", 21798f, 69.419f, .1f, -0f, MagicBall);

            Enemies = new Character[3] {JoePablo, JOHNcena, LJDBiden};

        }

        //The logic for update
        void update()
        {
            if (Currentscene == 0)
            {
                Characterselectionscene();
            }
            else if (Currentscene == 1)
            {
                Battlescene();
            }
            else if (Currentscene == 2)
            {
                Healscene();
            }
            else if (Currentscene == 3)
            {
                Winresultscene();
            }
            else if (Currentscene == 4)
            {
                Endgamescene();
            }
        }

        //End logic
        void end()
        {
            Console.WriteLine("Thanks for playing");
        }
        //void Printlargest(int[] numbers)
        //{
        //    int biggestnumber = numbers[0];

        //    for (int i = 1; i < numbers.Length; i++)
        //    {
        //        if (numbers[i] > biggestnumber)
        //        {
        //            biggestnumber = numbers[i];
        //        }
        //    }
        //}

        //Void run begins here
        public void Run()
        {

            start();

            //Gameloop Starts
            while (GameOver == false)
            {
                
                //int[] grades = new int[5] {23, 43, 56, 7, 260};
                //Arraytest(grades);



                update();
            } 
            end();
        }
    }
}
