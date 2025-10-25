using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DelegateHW
{
    //  ----   5   ----
    public class classUsesGeneric <T1,T2>
    {
        private T1 firstValue;
        private T2 secondValue;

        public classUsesGeneric(T1 first , T2 second)
        {
            firstValue = first;
            secondValue = second;
        }

        public void setFirst(T1 value)
        {
            firstValue = value;
        }
        public T1 getFirst()
        {
            return firstValue;
        }
        public void setSecond (T2 second)
        {
            secondValue = second;
        }
        public T2 getSecond()
        {
            return secondValue;
        }

        public void display()
        {
            Console.WriteLine($"First value : {firstValue} , Second value : {secondValue}");
        }
    }

    //  ----   7   ----

    public class Operation<T>
    {
        public T PerformOperation(T a,T b,Func<T,T,T> operation)
        {
            return operation(a, b);
        }
    }

    //  ----   8   ----

    public delegate void clickdelegate(object sender, EventArgs e);

    public class ClickButtonDelegate
    {
        public clickdelegate Click;
        public void OnClick()
        {
            if (Click != null)
            {
                Click?.Invoke(null, null);
            }
        }
    }
    class TextBox
    {
        public void textchange(object sender, EventArgs e)
        {
            MessageBox.Show("inserting .... in textbox");
        }
    }
    delegate void Write(string s);
    delegate string Read();
    public class Program
    {
        //  ----   1   -----
        public static void printMessage()
        {
            Console.WriteLine("Delegate in C#");
        }
        public static void printText(string text)
        {
            Console.WriteLine(text);
        }
        public static int Factorial (int number)
        {
            int result = 2;
            for (int i = 3; i <= number; i++)
                result *= i;
            return result;
        }

        public delegate void printMessageDelegate();
        public delegate void printTextDelegate(string text);
        public delegate int FactorialDelegate(int n);

        static void resevDelegate(printTextDelegate del)
        {
            del("Delegate from Function .");
        }
        //--------------------------------------------------------------

        //  ----   2   ----

        public delegate void CustomDelegate(string message);

        //-------------------------------------------------

        //  ----   3   ----

        public delegate bool numberConditionDelegate(int number);

        public static int countNumbers(int []numbers,numberConditionDelegate condition)
        {
            int count = 0;
            foreach (var number in numbers)
            {
                if (condition(number))
                    count++;
            }
            return count;
        }

        //-----------------------------------------

        //  ----   4   ----

        public static void firstMethod()
        {
            Console.WriteLine("First Method Executed ");
        }

        public static void secondMethod()
        {
            Console.WriteLine("Second Method Executed ");
        }

        public static void ThirdMethod()
        {
            Console.WriteLine("Third Method Executed ");
        }

        public static int fourthMethod() => 10;
        public static int fifthMethod() => 20;

        public delegate void multiMethodDelegate();
        public delegate int multiMethodDelegateReturn();


        //  ----   5   ----

        static T genericFunction<T>(T value)
        {
            return value;
        }

        //  ----   6   ----

        public delegate void myAction<T>(T param);
        public delegate TResult myFunc<T, TResult>(TResult param);
        public delegate bool myPredicat<T>(T param);

        public static void Print(string message) => Console.WriteLine(message);

        //  Function Factorial is in 1


     
        
        static void Main(string[] args)
        {
            //  ----   1   ----
            //printMessageDelegate messageDelegate = new printMessageDelegate(printMessage);
            //printTextDelegate textDelegate = printText;
            //FactorialDelegate factorialDelegate = (Factorial);

            //Console.WriteLine("Result for function : ");
            //printMessage();
            //Console.WriteLine("Result for Delegate : ");
            //messageDelegate();
            //textDelegate("Hello , Delegate ");

            //Console.Write("Enter number to get the Factorial = ");
            //int x = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Factorial for " + x +" = " + factorialDelegate(x));

            //resevDelegate(printText);
            //resevDelegate(textDelegate);

            //---------------------------------------------------------------

            //  ----   2   ----

            //CustomDelegate delegateMethod = delegate (string message)
            //{
            //    Console.WriteLine("Anonymous method executed : " + message);
            //};

            //delegateMethod("Hello From delegate ! ");


            //CustomDelegate delegateMethod2 = (message) =>
            //{
            //    Console.WriteLine("Anonymous method executed : " + message);
            //};

            //delegateMethod2("Hello from Delegate ! ");

            //CustomDelegate lambdaMethod = message => Console.WriteLine("Lambda executed : " + message);
            //lambdaMethod("Hello form lambda !");

            //------------------------------------------

            //  ----   3   ----

            //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 17 };
            //numberConditionDelegate isEven = (int n) => { return n % 2 == 0; };

            //Console.WriteLine("Even number = " + countNumbers(numbers, isEven));

            //Console.WriteLine("Odd number = " + countNumbers(numbers, n => n % 2 != 0));

            //Console.WriteLine("Prime number = "+countNumbers(numbers, n=>
            //{
            //    if (n <= 1) return false;
            //    for (int i=2;i<n;i++)
            //    {
            //        if (n % i == 0)
            //            return false;
            //    }
            //    return true;
            //}));

            //  ----   4   ----

            //multiMethodDelegate multiDelegate = firstMethod;
            //multiDelegate += secondMethod;
            //multiDelegate += ThirdMethod;

            //Console.WriteLine("Executing all Methods : ");
            //multiDelegate();

            //multiDelegate -= secondMethod;

            //Console.WriteLine("Executing after removing Second Method : ");
            //multiDelegate();

            //Console.WriteLine("-------------------Multi delegate with return type function----------------------- ");
            //multiMethodDelegateReturn multiDelegateReturn = fourthMethod;
            //multiDelegateReturn += fifthMethod;
            //Console.WriteLine("Multi Delegate Return = " + multiDelegateReturn());
            //Console.WriteLine("---------------------------------------------------");

            //  ----   5   ----

            //classUsesGeneric<string, string> textPair = new classUsesGeneric<string, string>("Hello", "Delegate");
            //textPair.display();
            //Console.WriteLine("First value : " + textPair.getFirst());
            //Console.WriteLine("Second value : " + textPair.getSecond());

            //classUsesGeneric<int, int> numberPair = new classUsesGeneric<int, int>(10, 20);
            //numberPair.display();
            //Console.WriteLine("First value : " + numberPair.getFirst());
            //Console.WriteLine("Second value : " + numberPair.getSecond());
            //Console.WriteLine($"Use Generic Function (int) {genericFunction<int>(100)}");
            //Console.WriteLine($"Use Generic Function (string) {genericFunction<string>("Advanced Programming")}");
            //Console.WriteLine("------------------------------------------------------");

            //  ----   6   ----

            //myAction<string> myPrint = Print;
            //myPrint("Using myAction delegate");

            //myFunc<int, int> myFactorial = Factorial;
            //Console.WriteLine("Factorial of 5 using MyFunc : " + myFactorial(5));

            //myPredicat<string> myLength = s => s.Length > 10;
            //Console.WriteLine("Using my predicate delegate : " + myLength("Advanced Programming"));

            //Action<string> actionDelegate = Print;
            //actionDelegate("Using Action Delegate");

            //Func<int, int> funDelegate = Factorial;
            //Console.WriteLine("Factorial of 5 using Func : " + funDelegate(5));

            //Predicate<string> predDelegate = s => s.Length > 10;
            //Console.WriteLine("Using Predicate delegate : " + predDelegate("Advanced Programming"));

            //Func<int, int, int> add = (a, b) => a + b;
            //Console.WriteLine("Sum is : " + add(5, 10));

            //Func<int> getNumber = () => 42;
            //Console.WriteLine(getNumber());

            //Action<string> pr = message => Console.WriteLine(message);
            //pr("Hello , Action");

            //Action printHello = () => Console.WriteLine("Hello World");
            //printHello();

            //Predicate<int> isEven = num => num % 2 == 0;
            //Console.WriteLine(isEven(4));
            //Console.WriteLine(isEven(5));
            //Console.WriteLine("----------------------------");
            //-------------------------------------------------

            //  ----   7   ----

            //var intOperation = new Operation<int>();
            //Console.WriteLine("Addition : " + intOperation.PerformOperation(5, 10, (x, y) => x + y));

            //var stringOperation = new Operation<string>();
            //Console.WriteLine("Concatenation : " + stringOperation.PerformOperation("Hello ", "World", (x, y) => x + y));

            ClickButtonDelegate button = new ClickButtonDelegate();
            button.Click += (s, e) =>
              {
                  MessageBox.Show("Button Click");
              };
            button.OnClick();
            TextBox t = new TextBox();
            button.Click += t.textchange;
            button.OnClick();

            Write cout = Console.WriteLine;
            cout("simple");
            Read cin = Console.ReadLine;
            cout(cin());

            Console.ReadKey();
        }
    }
  
}


