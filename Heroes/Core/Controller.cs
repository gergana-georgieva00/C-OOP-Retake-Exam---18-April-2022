using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            throw new NotImplementedException();
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (this.heroes.Models.Any(h => h.Name == name))
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }
            if (type != "Knight" && type != "Barbarian")
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            IHero hero;
            string message = "";
            if (type == "Knight")
            {
                hero = new Knight(name, health, armour);
                message = $"Successfully added Sir {name} to the collection.";
            }
            else
            {
                hero = new Barbarian(name, health, armour);
                message = $"Successfully added Barbarian {name} to the collection.";
            }

            heroes.Add(hero);
            return message;
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            throw new NotImplementedException();
        }

        public string HeroReport()
        {
            throw new NotImplementedException();
        }

        public string StartBattle()
        {
            throw new NotImplementedException();
        }
    }
}
