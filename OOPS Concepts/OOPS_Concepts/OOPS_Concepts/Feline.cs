using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Concepts
{
    public class Feline : Animal
    {
        public override string Name { get; set; } = "Feline";
        public override int Weight { get; set; } = 200;
        public override void Eat()
        {
            Console.WriteLine("Feline eats");
        }

    }
}
