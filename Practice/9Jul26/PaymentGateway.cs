using System;

public interface PaymentGateway
{
    void processPayment(decimal amount);
}