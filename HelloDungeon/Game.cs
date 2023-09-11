using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Game
    {
        struct Monster
        {
            public string Name;
            public float Health;
            public float Damage;
            public float Defense;
            public float Stamina;
        }

        void PrintStats(Monster monster)
        {
            Console.WriteLine("Name: " + monster.Name);
            Console.WriteLine("Health: " + monster.Health);
            Console.WriteLine("Damage: " + monster.Damage);
            Console.WriteLine("Defense: " + monster.Defense);
            Console.WriteLine("Stamina: " + monster.Stamina);
        }

        float Attack(Monster attacker, Monster defender)
        {
            float totaldamage = attacker.Damage - defender.Defense;
            
            return defender.Health - totaldamage;
        }
        float Heal(Monster monster, float healamount)
        {
            float newhealth = monster.Health * healamount;

            return newhealth;
        }

        void Fight(ref Monster monster1, ref Monster monster2)
        {
            PrintStats(monster1);
            PrintStats(monster2);

            Console.WriteLine(monster1.Name + " Punches " + monster2.Name);
            monster2.Health = Attack(monster1, monster2);
            Console.ReadKey(true);

            PrintStats(monster1);
            PrintStats(monster2);

            Console.WriteLine(monster2.Name + " Punches " + monster1.Name);
            monster1.Health = Attack(monster2, monster1);
            Console.ReadKey(true);

            PrintStats(monster1);
            PrintStats(monster2);
        }
        void Changenumber(int number)
        {
            number = 2;
        }

        public void Run()
        {
            Monster JoePablo;
            JoePablo.Name = "JoePablo";
            JoePablo.Health = 21799f;
            JoePablo.Damage = 69.420f;
            JoePablo.Defense = .9f;
            JoePablo.Stamina = 3f;

            Monster JOHNcena;
            JOHNcena.Name = "JOHN...cena";
            JOHNcena.Health = 21800f;
            JOHNcena.Damage = 69.421f;
            JOHNcena.Defense = 1.9f;
            JOHNcena.Stamina = 4f;

            Monster LJDBiden;
            LJDBiden.Name = "LucyJillDirtbagBiden";
            LJDBiden.Health = 21798f;
            LJDBiden.Damage = 69.419f;
            LJDBiden.Defense = .1f;
            LJDBiden.Stamina = -0f;

            Fight(JoePablo, LJDBiden);

            Console.WriteLine(JoePablo.Name + " Heals 'emself ");
            JoePablo.Health = Heal(JoePablo, 1000);
            Console.ReadKey(true);

            PrintStats(JoePablo);
        }
    }
}
