using System;

class UpiPayment : PaymentGateway{
    public void processPayment(decimal amount){
        Console.WriteLine("paid using UPI "+amount);
    }
}