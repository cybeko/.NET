using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw13_AnimalWorld
{
    class AnimalWorld
    {
        private readonly Herbivore _herbivore;
        private readonly Carnivore _carnivore;

        public AnimalWorld(Continent continent)
        {
            _herbivore = continent.CreateHerbivore();
            _carnivore = continent.CreateCarnivore();
        }

        public void FeedAll()
        {
            Console.WriteLine("\nFeeding all:");

            _herbivore.EatGrass();

            _carnivore.Eat(_herbivore);
        }
    }
}
