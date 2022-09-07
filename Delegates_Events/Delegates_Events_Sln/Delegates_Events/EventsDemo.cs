using System;

namespace Delegates_Events
{
    //Events are just "syntatic sugar" for delegates. Underneath every EVENT, there is a DELEGATE.
    //Whenever we say an event has been raised, basically that means a delegate has been invoked.
    public class EventsDemo
    {
        //Events must be defined in conjunction with the associated event handler(DELEGATE)
        public static event WorkPerformedHandler WorkPerformed;

        //Basically EventHandler is syntactic sugar for a delegate 
        //The below code is another way of defining an event.
        //Essentially, behind the scenes, a delegate is spun up as below
        //public delegate void Delegate$(object sender, CustomEventArgs e);
        //This approach is more common while writing code.
        public static event EventHandler<CustomEventArgs> WorkPerformed2;

        //'EventHandler' is a default delegate provided by .NET
        public static event EventHandler WorkCompleted;
        public static void DemoEvents()
        {
            //Attaching listeners to the events below.
            //The listener, essentially a method, must bear the same signature of the delegate associated with the event.
            //Here, DelegatesDemo.WorkPerformed1 and DelegatesDemo.WorkPerformed2 are the "listeners"
            WorkPerformed = new WorkPerformedHandler(DelegatesDemo.WorkPerformed1);
            WorkPerformed = new WorkPerformedHandler(DelegatesDemo.WorkPerformed2);

            WorkCompleted += new EventHandler(DelegatesDemo.WorkCompleted);

            WorkPerformed2 = new EventHandler<CustomEventArgs>((o, e) => { });

            //Note 1: Important
            //Writing code to attach/remove listeners to an event from outside the class containing the event,
            //using '+=' or '-=' operators is mandatory.
            //Example: From another class, say Program, you cannot write the below:
            //EventsDemo.WorkPerformed = new WorkPerformedHandler(DelegatesDemo.WorkPerformed1); (compiler error)
            //i.e. From an outside class you can only attach or remove your listener, not "wipe off" (override)
            //all the other attached listeners.


            //Note 2:
            //Consider the above line of code rewritten below:
            //WorkPerformed += new WorkPerformedHandler(DelegatesDemo.WorkPerformed1);
            //While attaching listeners it seems like an overkill to specify the delegate.
            //Hence, .NET provides an easier way to attach a listener by dropping the delegate
            //while attaching the listener. The .NET will automatically infer the associated delegate
            //and the delegate gets invoked behind the scenes.
            //The above code for attaching listener could also be written as:
            //WorkPerformed += DelegatesDemo.WorkPerformed1;
            //WorkPerformed2 = DelegatesDemo.EventArgsDemoMethod;

            DoWork();
        }


        public static void DoWork()
        {
            int hours = 10;
            for (int i = 0; i < hours; i++)
            {
                OnWorkPerformed(i + 1, WorkType.Code);
            }
            OnWorkCompleted();
        }


        public static void OnWorkPerformed(int hours, WorkType workType)
        {
            //Two ways of raising events.

            //First way:
            //Raise events directly.
            //Behind the scenes, it essentially pulls the associated delegate and then invokes it.
            //Before raising an event or invoking a delegate it is good to check if there are any listeners attached or not
            //in the invocation list of the delegate.
            //That is why the null check below. if(WorkPerformed != null) { }
            if (WorkPerformed != null)
            {
                WorkPerformed(hours, workType);
            }

            //Second way:
            //Cast the event to its associated delegate and then invoke the delegate.
            //Before raising an event or invoking a delegate it is good to check if there are any listeners attached or not
            //in the invocation list of the associated delegate.
            //That is why the null check below. if(del != null) { }
            var del = WorkPerformed as WorkPerformedHandler;
            if (del != null)
            {
                del(hours, workType);
            }
        }

        public static void OnWorkCompleted()
        {
            var del = WorkCompleted as EventHandler;
           
            if (del != null)
            {
                del(null, null);
            }
        }

        
    }
}
