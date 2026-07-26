using System;
public class PartTimeStudent: Student
{
    public override double CalculateFee()
    {
        double fee = TotalCredits() * 1000;
        return fee*0.7;
    }
}