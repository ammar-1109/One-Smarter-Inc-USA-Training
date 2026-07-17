using System;

class CreditPayment : PaymentGateway{
    public void processPayment(decimal amount){
        Console.WriteLine("paid using credit card "+amount);
    }
}