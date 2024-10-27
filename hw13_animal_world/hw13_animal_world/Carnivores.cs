using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw13_AnimalWorld
{
    abstract class Carnivore
    {
        public int Power { get; protected set; }
        public abstract void Eat(Herbivore herbivore);
    }
    class Lion : Carnivore
    {
        public Lion()
        {
            Power = 150;
        }

        public override void Eat(Herbivore herbivore)
        {
            if (herbivore.Life)
            {
                if (Power > herbivore.Weight)
                {
                    herbivore.Life = false;
                    Power += 10;
                    Console.WriteLine($"Lion had eaten. Power: {Power}");
                    Console.WriteLine("Wildebeest has died.");
                }
                else
                {
                    Power -= 10;
                    Console.WriteLine($"Lion failed to eat. Power: {Power}");

                }
            }
        }
    }
    class Wolf : Carnivore
    {
        public Wolf()
        {
            Power = 100;
        }

        public override void Eat(Herbivore herbivore)
        {
            if (herbivore.Life)
            {
                if (Power > herbivore.Weight)
                {
                    herbivore.Life = false;
                    Power += 10;
                    Console.WriteLine($"Wolf had eaten. Power: {Power}");
                    Console.WriteLine("Bison has died.");
                }
                else
                {
                    Power -= 10;
                    Console.WriteLine($"Wolf failed to eat. Power: {Power}");
                }
            }
        }
    }

}
