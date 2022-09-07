using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Concepts
{
    public class Tiger : Feline
    {
        public string Name { get; set; } = "Tiger";
        public override void Eat()
        {
            Console.WriteLine("Tiger eats");
        }

    }
}
