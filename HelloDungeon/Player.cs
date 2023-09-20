using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HelloDungeon
{
    internal class Player : Character
    {
        private int _lives = 3;
        private string _playerchoice;
        public Player()
        {
            _playerchoice = "";
        }
        public Player(string name, float health, float damage, float defense, float stamina, WeaponBasics currentweapon) : base(name, health, damage, defense, stamina, currentweapon)
        {
            _playerchoice = "";
        }
        public override void PrintStats()
        {
            Console.WriteLine("Name: " + GetName);
            Console.WriteLine("Health: " + GetHealth);
            Console.WriteLine("Damage: " + GetDamage);
            Console.WriteLine("Defense: " + GetDefense);
            Console.WriteLine("Stamina: " + GetStamina);
            Console.WriteLine("Current Weapon: " + GetCurrentWeapon);
            Console.WriteLine("Lives: " + _lives);
        }

        //How to create desecions
        public string Getinput(string prompt, string option1, string option2, string option3, string option4)
        {
            _playerchoice = "";

            Console.WriteLine(prompt);
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.WriteLine("3." + option3);
            Console.WriteLine("4." + option4);

            _playerchoice = Console.ReadLine();

            return _playerchoice;

        }

        public string Getinput(string prompt, string option1, string option2, string option3)
        {
            _playerchoice = "";

            Console.WriteLine(prompt);
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.WriteLine("3." + option3);

            _playerchoice = Console.ReadLine();

            return _playerchoice;



        }
        public string Getinput(string prompt, string option1, string option2)
        {
            _playerchoice = "";

            Console.WriteLine(prompt);
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);

            _playerchoice = Console.ReadLine();

            return _playerchoice;
        }
    }
}
