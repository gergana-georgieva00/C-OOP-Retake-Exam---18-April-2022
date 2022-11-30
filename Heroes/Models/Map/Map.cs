using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
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

            while (knights.Any(k => k.IsAlive) && barbarians.Any(b => b.IsAlive))
            {
                foreach (var knight in knights.Where(k => k.IsAlive))
                {
                    foreach (var barbarian in barbarians.Where(b => b.IsAlive))
                    {
                        barbarian.TakeDamage(knight.Weapon.DoDamage());
                        if (!barbarian.IsAlive)
                        {
                            barbariansDead++;
                        }
                    }
                }
                foreach (var barbarian in barbarians.Where(b => b.IsAlive))
                {
                    foreach (var knight in knights.Where(k => k.IsAlive))
                    {
                        knight.TakeDamage(barbarian.Weapon.DoDamage());
                        if (!knight.IsAlive)
                        {
                            knightsDead++;
                        }
                    }
                }
            }

            if (!knights.Any(k => k.IsAlive))
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
