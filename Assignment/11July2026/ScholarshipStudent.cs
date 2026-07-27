using System;
public class ScholarshipStudent: Student
{
    public override double CalculateFee()
    {
        double fee = TotalCredits() * 1000;
        return fee*0.5;
    }
}