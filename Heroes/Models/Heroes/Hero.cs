using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private bool isAlive;
        private IWeapon weapon;

        public Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }

        public string Name 
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }

                this.name = value;
            } 
        }
        public int Health
        {
            get { return this.health; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }

                this.health = value;
            }
        }
        public int Armour
        {
            get { return this.armour; }
            private set
            {
                this.armour = value;
            }
        }
        public bool IsAlive
        {
            get
            {
                if (this.Health > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public IWeapon Weapon
        {
            get { return this.weapon; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }

                this.weapon = value;
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            if (this.Weapon == null)
            {
                this.Weapon = weapon;
            }
        }

        public void TakeDamage(int points)
        {
            int transferPoints = points - this.Armour;
            this.Armour -= points;

            if (Armour <= 0)
            {
                Armour = 0;
                
                if (this.Health - transferPoints <= 0)
                {
                    this.Health = 0;
                }
                else
                {
                    this.Health -= transferPoints;
                }
            }
        }
    }
}
