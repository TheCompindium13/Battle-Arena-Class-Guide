using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace HelloDungeon
{
    class Character
    {
        private string _name;
        private float _health;
        private float _damage;
        private float _defense;
        private float _defenseboost;
        private float _stamina;
        private WeaponBasics _currentWeapon;

        //Character stats    
        public virtual void PrintStats()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
            Console.WriteLine("Defense: " + _defense);
            Console.WriteLine("Stamina: " + _stamina);
            Console.WriteLine("Current Weapon: " + _currentWeapon.WeaponName);

        }
        public Character()
        {
            _name = "";
            _health = 0f;
            _damage = 0f;
            _defense = 0f;
            _stamina = 0f;
        }
        public Character(string name, float health, float damage, float defense, float stamina, WeaponBasics currentweapon)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _defense = defense;
            _stamina = stamina;
            _currentWeapon = currentweapon;
        }

        public float GetHealth()
        {
            return _health;
        }
        public float GetStamina()
        {
            return _stamina;
        }

        public WeaponBasics GetCurrentWeapon()
        {
            return _currentWeapon;
        }

        public float GetDamage()
        {
            return _damage;
        }
        public float GetDefense()
        {
            return _defense;
        }
        public void BoostDefense()
        {
            _defense += _defenseboost;
        }
        public void LowerDefense()
        {
            _defense -= _defenseboost;
        }
        public string GetName()
        {
            return _name;
        }
        //Attack logic
        public void takedamage(float damage)
        {
            _health -= damage - _defense;
        }



    }

}
