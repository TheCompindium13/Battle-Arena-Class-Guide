using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Game
    {

        //Character structure
        struct Character
        {
            public string Name;
            public float Health;
            public float Damage;
            public float Defense;
            public float Stamina;
            public WeaponBasics CurrentWeapon;
        }

        //Basic weapon structure
        struct WeaponBasics
        {
            public string WeaponName;
            public float WeaponDamage;
            public bool WeaponTalks;

        }

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
                PrintStats(Player);
                Console.ReadKey(true);
                Console.Clear();
                Currentscene = 1;
            }
            
           
        }

    //Character stats    
    void PrintStats(Character monster)
        {
            Console.WriteLine("Name: " + monster.Name);
            Console.WriteLine("Health: " + monster.Health);
            Console.WriteLine("Damage: " + monster.Damage);
            Console.WriteLine("Defense: " + monster.Defense);
            Console.WriteLine("Stamina: " + monster.Stamina);
            Console.WriteLine("Current Weapon: " + monster.CurrentWeapon.WeaponName);
        }

        //How the healing works
        float Heal(Character monster, float healamount)
        {
            float newhealth = monster.Health * healamount;

            return newhealth;
        }

        //The healing scene starts here
        void Healscene()
        {
            Heal(Player, 1000);
        }

        //Attack logic
        float Attack(Character attacker, Character defender)
        {
            float totaldamage = attacker.CurrentWeapon.WeaponDamage + attacker.Damage - defender.Defense ;
            
            return defender.Health - totaldamage;
        }

        //Fighting logic for fight
        void Fight(ref Character monster2)
        {
            
            PrintStats(Player);
            PrintStats(monster2);
            bool Isdefending = false;

            string Battlechoice = Getinput("Choose action", " Attack", " Defend", " Run");
            if (Battlechoice == "1")
            {
                monster2.Health = Attack(Player, monster2);
                Console.WriteLine("You hit the monster");


                if (monster2.Health <= 0)
                {
                    return;
                }
            }
            else if (Battlechoice == "2")
            {
                Isdefending = true;
                Player.Defense *= 5;
                Console.WriteLine("You brace for impact");
            }
            else if(Battlechoice == "3")
            {
                Console.WriteLine("You ran... coward");
                Currentscene = 3;
                return;
            }

            PrintStats(Player);
            PrintStats(monster2);

            Console.WriteLine(monster2.Name + " Punches " + Player.Name);
            Player.Health = Attack(monster2, Player);
            Console.ReadKey(true);

            PrintStats(Player);
            PrintStats(monster2);
            if (Isdefending = true)
            {
                Player.Defense /= 5;
            }
        }

        //The battle logic
        void Battlescene()
        {
            Fight(ref Enemies [currentenemyindex]);

            if (Enemies[currentenemyindex].Health <= 0 || Player.Health <= 0)
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
            if (Player.Health > 0 && Enemies[currentenemyindex].Health <= 0)
            {
                Console.WriteLine("The Winner Is: " + Player.Name);
                Currentscene = 1;
                currentenemyindex++;
                if (currentenemyindex >= Enemies.Length)
                {
                    GameOver = true;
                }
            }
            else if (Enemies[currentenemyindex].Health > 0 && Player.Health <= 0)
            {
                Console.WriteLine("The Winner Is: " + Enemies[currentenemyindex].Name);
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

            //Monster Stats
            JoePablo.Name = "JoePablo";
            JoePablo.Health = 21799f;
            JoePablo.Damage = 69.420f;
            JoePablo.Defense = .9f;
            JoePablo.Stamina = 3f;
            JoePablo.CurrentWeapon = TheseHands;


            JOHNcena.Name = "JOHN... cena";
            JOHNcena.Health = 21800f;
            JOHNcena.Damage = 69.421f;
            JOHNcena.Defense = 1.9f;
            JOHNcena.Stamina = 4f;
            JOHNcena.CurrentWeapon = TheseHands;


            LJDBiden.Name = "LucyJillDirtbagBiden";
            LJDBiden.Health = 21798f;
            LJDBiden.Damage = 69.419f;
            LJDBiden.Defense = .1f;
            LJDBiden.Stamina = -0f;
            LJDBiden.CurrentWeapon = MagicBall;

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
        void Printlargest(int[] numbers)
        {
            int biggestnumber = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > biggestnumber)
                {
                    biggestnumber = numbers[i];
                }
            }
        }

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
