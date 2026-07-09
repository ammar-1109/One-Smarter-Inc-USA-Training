// Scenario array

// A company stores the monthly sales (in ₹) of 6 employees in an array. Display all sales, calculate the total sales, average sales, highest sales, and lowest sales.



using System;
class Program{
    static void Main(){
        int[] sales= {23000,21140,14598,16598,24250,15190};
        Program.display(sales);
        int total = Program.total(sales);
        Console.WriteLine("Total Sales : "+total);
        Console.WriteLine("Average Sales : "+(total/6));
        Program.highest_lowest(sales);



    }
    static void display(int[] arr){
        int idx =1;
        Console.WriteLine("=== Sales by each employee ===");
        foreach(int a in arr){
            Console.WriteLine((idx++)+" : "+ a);
        }
    }
    static int total(int[] arr){
        int total=0;
        foreach(int a in arr){
            total += a;
        }
        return total;
    }
    static void highest_lowest(int[] arr){
        int high=0;
        int low = arr[0];
        foreach(int a in arr){
            if(a > high){
                high = a;
            }
            if(a < low){
                low = a;
            }
        }
        Console.WriteLine("Highest Sales : "+high);
        Console.WriteLine("Lowest Sales : "+low);
    }
}