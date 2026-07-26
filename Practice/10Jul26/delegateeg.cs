/* using System;

delegate void MessageDelegate(string msg);

class DelegateExample
{
    static Func<int, int, int> add = (a, b) => a + b;

    static void Display1(string message)
    {
        Console.WriteLine("method 1 : "+message);
    }
    static void Display2(string message){
        Console.WriteLine("method 2 : "+ message);
    }
    static void Display3(string message){
        Console.WriteLine("method 3 : "+ message);
    }

            static void Main()
            {
                // Using custom delegate
                MessageDelegate m = Display1;
                
                m += Display2;
                m += Display3;

                m("Hello, this is from delegate.");
                // Using built-in Func delegate
                int result = add(10, 20);
                Console.WriteLine("Sum = " + result);
                Button bt = new Button();
                bt.click +=() => Console.WriteLine("click event");
                bt.press();
            }
} */