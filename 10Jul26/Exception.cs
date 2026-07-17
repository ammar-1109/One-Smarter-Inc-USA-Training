using System;
// try - risky code
//catch(Exception e) handle exception 
// finally - always execute

class Exceptioneg{
    static void checkAge(int age){
        if(age<20){
            // throw new Exception("Not Eligible for placement");
            throw new InvalidAgeException("Age is invalid");
        }
        Console.WriteLine("Eligible for placement");
    }
    public static void Main(){
        /* try{
            int a = 10;
            int b = 0;
            int c = a/b;
            Console.WriteLine(c);
        }
        catch(DivideByZeroException e){
            Console.WriteLine(e.Message);
        }
        finally{
            Console.WriteLine("Exited Program");
        } */
        try{
            Console.WriteLine("Enter the age");
            int age = Convert.ToInt32(Console.ReadLine());
            checkAge(age);
        }
        catch(InvalidAgeException e){
            Console.WriteLine(e.Message);
        }
        catch(FormatException e){
            Console.WriteLine(e.Message);
        }
        
    }
}