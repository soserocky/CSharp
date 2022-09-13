using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscellaneous
{
    internal delegate void MyDelegate(string name, WorkType w);

    internal class EventDemo
    {
        internal static event MyDelegate myEvent;
        internal static event EventHandler<MyEventArgs> myEventHandler;
        internal static void Start()
        {
            myEventHandler = MyWork2;

            if (myEventHandler != null)
                myEventHandler.Invoke("Sabya", new MyEventArgs(1, "sabya"));
        }

        internal static void MyWork(string name, WorkType w)
        {
            Console.WriteLine($"name: {name}, WorkType: {w}");
        }
        
        internal static void MyWork2(object sender, MyEventArgs e)
        {
            Console.WriteLine($"sender: {sender}, EventArgs: {e.ID}, {e.Name}");
        }
    }


    public class MyEventArgs : EventArgs
    {
        public MyEventArgs(int iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public int ID { get; set; }
        public string Name { get; set; }
    }
}
