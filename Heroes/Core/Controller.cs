using Heroes.Core.Contracts;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
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
