using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable_IComparable
{
    public class My_IComparable : IComparable<My_IComparable>
    {
        public int Weight { get; set; }
        public string Name { get; set; }
        Random random = new Random();
        public My_IComparable(string name)
        {
            Weight = random.Next(1,101);
            Name = name;
        }

        public int CompareTo(My_IComparable other)
        {
            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return this.Name;
        }
        internal static void Demo()
        { 
            var list = new List<My_IComparable>();
            list.Add(new My_IComparable("Sabya"));
            list.Add(new My_IComparable("Sanjay"));
            list.Add(new My_IComparable("Amit"));
            list.Add(new My_IComparable("Mukesh"));
            list.Sort(new My_Comparer());
            //list.ForEach(item => Console.WriteLine($"{item.Name}, {item.Weight}"));
            list.ForEach(item => Console.WriteLine($"{item.ToString()}"));
        }
    }

    internal class My_Comparer : IComparer<My_IComparable>
    {
        public int Compare(My_IComparable x, My_IComparable y)
        {
            return x.Weight - y.Weight;
        }
    }
}
