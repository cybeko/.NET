using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw13_AnimalWorld
{
    abstract class Continent
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }
    class Africa : Continent
    {
        public override Herbivore CreateHerbivore() => new Wildebeest();
        public override Carnivore CreateCarnivore() => new Lion();
    }

    class NorthAmerica : Continent
    {
        public override Herbivore CreateHerbivore() => new Bison();
        public override Carnivore CreateCarnivore() => new Wolf();
    }

}
