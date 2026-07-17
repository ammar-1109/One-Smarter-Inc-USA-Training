using System;

class Employee
{
    private string _empName;
    private double _salary;

    public string empName
    {
        get
        {
            return _empName;
        }
        set
        {
            _empName = value;
        }
    }

    public double salary
    {
        get
        {
            return _salary;
        }
        set
        {
            if (value >= 100)
            {
                _salary = value;
            }
        }
    }
}