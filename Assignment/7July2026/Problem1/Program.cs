//Problem 1 
// An automated conveyor belt processes 20 packages. Package IDs are generated from 1001 to 1020 using a loop.

// For each package:

// If the package ID is divisible by 4, it is marked as Quality Check Required.
// Else if the package ID is divisible by 5, it is marked as Priority Shipment.
// Otherwise, it is marked as Normal Processing.
// At the end of the program, display:

// Total packages processed
// Number of packages requiring quality check
// Number of priority shipments
// Number of normal packages





class Program{
    static void Main(String[] args){
        Console.WriteLine("---------- Conveyor started ---------");
        int total_package = 0;
        int quality_check = 0;
        int priority = 0;
        int normal = 0;

        for(int i = 1001 ; i <= 1020 ; i++){
            total_package++;
            if(i%4==0){
                quality_check++;
                Console.WriteLine("Processed package id :" + i + "( Quality Check Needed )");
            }
            else if(i%5==0){
                priority++;
                Console.WriteLine("Processed package id :" + i + "( Priority Shipment )");
            }
            else{
                normal++;
                Console.WriteLine("Processed package id :" + i + "( Normal Package )");
            }
        }
        Console.WriteLine("========== Summary ==========");
        Console.WriteLine("Total Packages Processed : "+ total_package);
        Console.WriteLine("Packages Required Quality Check : "+ quality_check);
        Console.WriteLine("Number of priority shipment : "+ priority);
        Console.WriteLine("Number of normal packages : "+ normal);
    }
}