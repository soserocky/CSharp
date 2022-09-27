using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Concepts
{
    public class Animal
    {
        public virtual string Name { get; set; } = "Animal";

        public virtual int Weight { get; set; } = 400;
        public virtual void Eat()
        {
            Console.WriteLine("Animal eats");
        }
    }
}
