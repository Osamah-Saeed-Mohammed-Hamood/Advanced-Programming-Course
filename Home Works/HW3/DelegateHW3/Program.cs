using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateHW3
{
    public delegate void Notify();
    
    public class Publisher
    {
        public event Notify OnNotify;
        public void TriggerEvent()
        {
            Console.WriteLine("Trigger event...");
            OnNotify?.Invoke();
        }
    }

    public class Subscriber
    {
        public void Respond()
        {
            Console.WriteLine("Event Recived");
        }
    }

    public delegate void StaticDelegate();
    public class MyClass
    {
        public static void StaticMethod()
        {
            Console.WriteLine("Static Method Call");
        }
    }

    public delegate void SimpleDelegate();

    public class MyClass2
    {
        public void SimpleMethod()
        {
            Console.WriteLine("Simple Method Call");
        }
    }

    public delegate int MathOperation(int a, int b);

    public class Math
    {
        public int Add(int a, int b) => a + b;
        public int Multiply(int a, int b) => a * b;
    }

    public delegate void MessageDelegate(string message);

    public class Messenger
    {
        public void SendEmail (string message)
        {
            Console.WriteLine($"Email sent : {message}");
        }
        public void SendSMS(string message)
        {
            Console.WriteLine($"SMS sent : {message}");
        }
    }

    internal class Program
    {
        public static void Execute(SimpleDelegate del)
        {
            del.Invoke();
        }

        public static void ExecuteOperation(MathOperation operation , int a,int b)
        {
            Console.WriteLine($"Result : {operation(a, b)}");
        }

        public static void Notify(MessageDelegate messagedelegate , string message)
        {
            messagedelegate(message);
        }
        static void Main(string[] args)
        {
            //      ----- 1 -----

            //var publisher = new Publisher();
            //var subscriber = new Subscriber();
            //publisher.OnNotify += subscriber.Respond;
            //publisher.TriggerEvent();

            //      ----- 2 -----

            //StaticDelegate del = new StaticDelegate(MyClass.StaticMethod);
            //del.Invoke();

            //      ----- 3 ------

            //MyClass2 myclass = new MyClass2();
            //Execute(myclass.SimpleMethod);

            //Math math = new Math();
            //ExecuteOperation(math.Add, 5, 3);
            //ExecuteOperation(math.Multiply, 5, 3);

            Messenger messenger = new Messenger();
            Notify(messenger.SendEmail, "Hello via Email");
            Notify(messenger.SendSMS, "Hello via SMS");

            Console.ReadKey();
        }
    }
}
