using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw13_AnimalWorld
{
    abstract class Herbivore
    {
        public int Weight { get; set; }
        public bool Life { get; set; } = true;

        public abstract void EatGrass();
    }
    class Wildebeest : Herbivore
    {
        public Wildebeest()
        {
            Weight = 100;
        }

        public override void EatGrass()
        {
            if (Life)
            {
                Weight += 10;
                Console.WriteLine($"Wildebeest had eaten. New weight: {Weight}");
            }
        }
    }

    class Bison : Herbivore
    {
        public Bison()
        {
            Weight = 200;
        }

        public override void EatGrass()
        {
            if (Life)
            {
                Weight += 10;
                Console.WriteLine($"Bsion had eaten. New weight: {Weight}");
            }
        }
    }

}
