using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Heroes
{
    public abstract class Hero 
    {
        private string name;
        private int health;
        private int armour;
        private bool isAlive;
        private IWeapon weapon;

        public Hero()
        {

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
                if (this.Health <= 0)
                {
                    return false;
                }

                return true;
            }
        }
        public string Name
        {
            get;
            set;
        }
    }
}
