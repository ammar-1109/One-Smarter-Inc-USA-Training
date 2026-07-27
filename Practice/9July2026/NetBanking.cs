using System;

class NetBanking : PaymentGateway{
    public void processPayment(decimal amount){
        Console.WriteLine("paid using net banking "+amount);
    }
}