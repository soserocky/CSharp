using System;


namespace Delegates_Events
{
    //DELEGATES are "EVENT HANDLERS". They are the "WIRES" that carry the data emitted by the "EVENT RAISER" and then dump the same
    //into the "LISTENER(S)" - which are basically METHODS(in programming context) and which are attached to those "wires" (delegates).  
    //The below line of code is the BLUEPRINT of the "wire" that is going to carry and transmit data between the event raiser and the event listener.
    //By default, the delegate name is suffixed with "handler". May choose to omit the suffix.
    //Essential and absolutely vital that the blueprint mimicks the SIGNATURE of the receiving event listener(which is basically a method)
    //that it is targetting and supposed to dump data into. Argument names and parameter names need not necessarily match.
    //We can not create 2 instances of the same blueprint and use them to target 2 methods with different signatures. Not possible.
    //Must create 2 different blueprints that mimick the respective event listeners'(methods) signatures.
    public delegate void WorkPerformedHandler(int i, WorkType wt);
    public delegate void WorkPerformedHandler2(int i, WorkType wt);
    public delegate void WorkPerformedHandler3(string name, ref int i);
    public class DelegatesDemo
    {
        public static void DemoDelegates()
        {
            //Setting up "wires" to point to the destination methods (event listeners). This step is also called attaching listeners.
            //Creating 2 instances of the 'WorkPerformedHandler' "wire"
            //to tie it to 2 of the event listeners (WorkPerformed1 and WorkPerformed2).
            //Delegates not yet invoked. Till now, only setting up the "wiring" has happened. No data flows, no call happens.
            WorkPerformedHandler del1 = new WorkPerformedHandler(DelegatesDemo.WorkPerformed1);
            WorkPerformedHandler del2 = new WorkPerformedHandler(DelegatesDemo.WorkPerformed2);
            WorkPerformedHandler2 del3 = new WorkPerformedHandler2(DelegatesDemo.WorkPerformed2);

            //Now, the delegates are invoked.
            //Data(the information supposed to be passed on to the listeners) is supposed to be fed at this stage
            //when delegates are invoked.
            del1(5, WorkType.Code);
            del2(2, WorkType.Golf);


            //Multicast delegates
            //The below code basically joins "wire 1" with "wire 2".
            //This means after "wire 1" finishes, "wire 2" should be invoked.
            //Does the same piece of work as the codes written above
            //del1(5, WorkPerformed.Code);
            //del2(2, WorkPerformed.Golf);
            //ABSOLUTELY vital that the joining "wires" belong to the same "blueprint" (delegate).
            //Essentially, the joining delegates have to be instances of a SINGLE delegate.
            //Example: del1 and del2 must be instances of the SAME delegate. Even if there are 2 delegates, and, del1 and del2 are their respective instances
            //that have the same signature, we CAN'T join them to create a multicast delegate.
            //Example: del1 and del3 CAN'T be joined even though they are instances of delegates that have the same signature.
            del1 += del2;

            //Note:
            //While joining 2 or more delegates, if an unhandled exception occurs at any stage,
            //then the subsequent delegates in the combination do not fire.
            //If we want to pass data between the listeners of the delegates, then use one or more
            //parameter of 'ref' type in the listeners.

            int i = 0;
            WorkPerformedHandler3 wp1 = RefMethod1;
            WorkPerformedHandler3 wp2 = RefMethod2;
            wp1 = wp1 + wp2;
            wp1("sabya", ref i);

        }

        //The below code is event listener 1, essentially a method, into which
        //data would be dumped when an APPROPRIATE delegate("wire") is invoked.
        //And then the listener processes/forwards/interprets or does nothing with the received data
        //and may choose to return a value or not.
        public static void WorkPerformed1(int i, WorkType wt)
        {
            Console.WriteLine($"WorkPerformed1 called with i as {i} and wp as {wt}");
        }

        //The below code is event listener 2, essentially a method, into which
        //data would be dumped when an APPROPRIATE delegate("wire") is invoked.
        //And then the listener processes/forwards/interprets the received data
        //and may choose to return a value or not.
        public static void WorkPerformed2(int i, WorkType wt)
        {
            Console.WriteLine($"WorkPerformed2 called with i as {i} and wp as {wt}");
        }

        public static void WorkCompleted(object sender, EventArgs args)
        {
            Console.WriteLine($"WorkCompleted called");
        }

        public static void EventArgsDemoMethod(object sender, CustomEventArgs e)
        {
            Console.WriteLine($"EventArgsDemoMethod called");
        }


        //Method to demonstrate how data can be passed from one attached listener to another
        //when we use combined delegates.
        //Also for the below code, since a "try-catch" block is used, during an exception occurrence,
        //we are handling the exception instead of throwing it and hence the next attached listener gets called.
        //Had we not handled the exception(say, we use "throw" in the catch block of 'RefMethod1') the next listener
        //would NOT have been called.
        public static void RefMethod1(string name, ref int i)
        {
            try
            {
                int j = 10 / i;
                Console.WriteLine($"RefMethod1 called with i as {i}");
                i++;
            }
            catch (Exception)
            {
            }
            
        }

        //Method to demonstrate how data can be passed from one attached listener to another
        //while using combined delegates.
        public static void RefMethod2(string name, ref int i)
        {
            try
            {
                Console.WriteLine($"RefMethod2 called with i as {i}");
                i++;
            }
            catch (Exception)
            {

            }
        }


    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        Sleep,
        Code
    }
}
