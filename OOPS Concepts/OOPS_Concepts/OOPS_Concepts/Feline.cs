using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Concepts
{
    public class Feline : Animal
    {
        public sealed override string Name { get; set; } = "Feline";
        public int Weight = 200;
        public virtual void Eat()
        {
            Console.WriteLine("Feline eats");
        }

    }
}
