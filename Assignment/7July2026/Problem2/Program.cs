// Problem 2
// A smart city has 30 street lights numbered 1 to 30. The power consumption (in watts) for each light is calculated using the formula:

// Power = 80 + (Light Number × 5)

// For each street light:

// If power consumption is greater than 180 W, display "Maintenance Required".
// Else if power consumption is between 140 W and 180 W, display "Normal Operation".
// Otherwise, display "Energy Efficient".
// Also calculate and display:

// Total power consumed by all street lights
// Average power consumption
// Number of lights in each category


class Program{
    static void Main(String[] args){
        int total_consumption = 0;
        int Maintenance_required = 0;
        int normal_operation = 0;
        int energy_efficient = 0;
        for(int i = 1; i <= 30; i++){
            int power = 80 + i * 5;
            total_consumption += power;
            Console.WriteLine("=== City lights analysis ===");
            if(power > 180){
                Console.WriteLine("Light "+i+": "+power+"w (Maintenance Required)");
                Maintenance_required++;
            }
            else if(power > 140){
                Console.WriteLine("Light "+i+": "+power+"w (Normal Operation)");
                normal_operation++;
            }
            else{
                Console.WriteLine("Light "+i+": "+power+"w (Energy Efficient)");
                energy_efficient++;
            }
        }
        Console.WriteLine("===== Summary =====");
        Console.WriteLine("Total power consumption : "+ total_consumption+"w");
        Console.WriteLine("Average power consumption : "+ (total_consumption/30)+"w");
        Console.WriteLine("Number of Lights in each category : ");
        Console.WriteLine("     Maintenance Required : "+ Maintenance_required);
        Console.WriteLine("     Normal Operation     : "+ normal_operation);
        Console.WriteLine("     Energy Efficient     : "+ energy_efficient);
    }
}