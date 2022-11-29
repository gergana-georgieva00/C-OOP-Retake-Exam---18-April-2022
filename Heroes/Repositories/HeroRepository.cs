using Heroes.Models.Heroes;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository<IHero> : IRepository<IHero>
    {
        private List<IHero> models;

        public HeroRepository()
        {
            this.models = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => this.models.AsReadOnly();

        public void Add(IHero model)
        {
            this.models.Add(model);
        }

        public IHero FindByName(string name)
        {
            return (IHero)(this.models.GetProperty(name).GetValue(models));
        }

        public bool Remove(IHero model)
        {
            return this.models.Remove(model);
        }
    }
}
