using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> heroes)
        {
            var knights = new List<IHero>();
            var barbarians = new List<IHero>();

            foreach (var hero in heroes)
            {
                if (hero.GetType().Name == "Knight")
                {
                    knights.Add(hero);
                }
                else
                {
                    barbarians.Add(hero);
                }
            }

            int knightsDead = 0;
            int barbariansDead = 0;

            foreach (var knight in knights)
            {
                foreach (var barbarian in barbarians)
                {
                    if (knight.IsAlive && barbarian.IsAlive)
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                        barbariansDead++;
                    }
                }
            }
            foreach (var barbarian in barbarians)
            {
                foreach (var knight in knights)
                {
                    if (knight.IsAlive && barbarian.IsAlive)
                    {
                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                        knightsDead++;
                    }
                }
            }

            if (knights.Count == 0)
            {
                return $"The barbarians took {barbariansDead} casualties but won the battle.";
            }
            else
            {
                return $"The knights took {knightsDead} casualties but won the battle.";
            }
        }
    }
}
