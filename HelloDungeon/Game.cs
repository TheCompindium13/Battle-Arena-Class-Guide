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
        string _Playerchoice = "";

        
        //Monsters
        Character JoePablo;
        Character JOHNcena;
        Character LJDBiden;
        Character Traveler;
        Character[] Enemies;
        int currentenemyindex = 0;

        //PlayerCharacter
        Player PlayerCharacter;


        
        
        //Character selection scene 
        void Characterselectionscene()
        {
            PlayerCharacter = new Player();

            string characterchoice = PlayerCharacter.Getinput("Choose your character", JoePablo.GetName(), JOHNcena.GetName(), LJDBiden.GetName(), Traveler.GetName());
            {

                if (characterchoice == "1")
                {
                    PlayerCharacter = new Player(JoePablo.GetName(), JoePablo.GetHealth(), JoePablo.GetDamage(), JoePablo.GetDefense(), JoePablo.GetStamina(), JoePablo.GetCurrentWeapon());
                }
                else if (characterchoice == "2")
                {
                    PlayerCharacter = new Player(JOHNcena.GetName(), JOHNcena.GetHealth(), JOHNcena.GetDamage(), JOHNcena.GetDefense(), JOHNcena.GetStamina(), JOHNcena.GetCurrentWeapon());
                }
                else if (characterchoice == "3")
                {
                    PlayerCharacter = new Player(LJDBiden.GetName(), LJDBiden.GetHealth(), LJDBiden.GetDamage(), LJDBiden.GetDefense(), LJDBiden.GetStamina(), LJDBiden.GetCurrentWeapon());
                }
                else if (characterchoice == "4")
                {
                    PlayerCharacter = new Player(Traveler.GetName(), Traveler.GetHealth(), Traveler.GetDamage(), Traveler.GetDefense(), Traveler.GetStamina(), Traveler.GetCurrentWeapon());
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey(true);
                    Console.Clear();
                    return;
                }
                PlayerCharacter.PrintStats();
                Console.ReadKey(true);
                Console.Clear();
                Currentscene = 1;
            }
            
           
        }



        //How the healing works
        float Heal(float healamount)
        {
            float newhealth = PlayerCharacter.GetHealth() * healamount;

            return newhealth;
        }

        //The healing scene starts here
        void Healscene()
        {
            Heal(1000);
        }



        //Fighting logic for fight
        void Fight(ref Character monster2)
        {
            
            PlayerCharacter.PrintStats();
            monster2.PrintStats();
            bool Isdefending = false;

            string Battlechoice = PlayerCharacter.Getinput("Choose action", " Attack", " Defend", " Run");
            if (Battlechoice == "1")
            {
                monster2.takedamage(PlayerCharacter.GetDamage());
                Console.WriteLine("You hit the monster");


                if (monster2.GetHealth() <= 0)
                {
                    return;
                }
            }
            else if (Battlechoice == "2")
            {
                Isdefending = true;
                PlayerCharacter.BoostDefense();
                Console.WriteLine("You brace for impact");
            }
            else if (Battlechoice == "3")
            {
                Console.WriteLine("You ran... coward");
                Currentscene = 3;
                return;
            }
            PlayerCharacter.PrintStats();
            monster2.PrintStats();

            Console.WriteLine(monster2.GetName() + " Punches " + PlayerCharacter.GetName());
            PlayerCharacter.takedamage(monster2.GetDamage());
            Console.ReadKey(true);

            PlayerCharacter.PrintStats();
            monster2.PrintStats();
            if (Isdefending = true)
            {
                PlayerCharacter.LowerDefense();
            }
        }

        //The battle logic
        void Battlescene()
        {
            Fight(ref Enemies [currentenemyindex]);

            if (Enemies[currentenemyindex].GetHealth() <= 0 || PlayerCharacter.GetHealth() <= 0)
            {
                Currentscene = 3;
            }

        }
        
        //See this screen when you win
        void Winresultscene()
        {
            if (PlayerCharacter.GetHealth() > 0 && Enemies[currentenemyindex].GetHealth() <= 0)
            {
                Console.WriteLine("The Winner Is: " + PlayerCharacter.GetName());
                Currentscene = 1;
                currentenemyindex++;
                if (currentenemyindex >= Enemies.Length)
                {
                    GameOver = true;
                }
            }
            else if (Enemies[currentenemyindex].GetHealth() > 0 && PlayerCharacter.GetHealth() <= 0)
            {
                Console.WriteLine("The Winner Is: " + Enemies[currentenemyindex].GetName());
                Currentscene = 4;
            }
            Console.ReadKey(true);
            Console.Clear();
        }

        void Endgamescene()
        {
            string Playerchoice = PlayerCharacter.Getinput("You are dead", " Yes", " No");

            if (Playerchoice == "1")
            {
                Currentscene = 0;
            }
            else if (Playerchoice == "2")
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
            
            JOHNcena = new Character("JOHN... cena", 21800f, 69.421f, 1.9f, 4f, TheseHands);

            LJDBiden = new Character("LucyJillDirtbagBiden", 21798f, 69.419f, .1f, -0f, MagicBall);

            Traveler = new Character("The Traveler", 450324f, 461.99f, 5f, 80f, TheseHands);

            Enemies = new Character[4] {JoePablo, JOHNcena, LJDBiden, Traveler};

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

        //Void run begins here
        public void Run()
        {

            start();

            //Gameloop Starts
            while (GameOver == false)
            {
                update();
            } 
            end();
        }
    }
}
