using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Events
{
    //With 'sender' as the first argument and 'EventArgs' or 'CustomEventArgs'(child class of 'EventArgs') as the second argument
    //is a standard practice of creating listeners(methods).
    //Define a custom class with all the fields you want to pass and then use this custom class while defining the event.
    public class CustomEventArgs : EventArgs
    {
        public int Hours { get; set; }
        public WorkType WorkType { get; set; }
    }
}
