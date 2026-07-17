using System;

public abstract class Employee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; }

    public string Department { get; set; }

    public int LeaveBalance { get; set; }

    public void DisplayDetails(){
        Console.WriteLine($"Employee Id : {EmployeeId}");
        Console.WriteLine($"Name        : {Name}");
        Console.WriteLine($"Department  : {Department}");
        Console.WriteLine($"Leave Days  : {LeaveBalance}");
    }
    public abstract void SetLeaveBalance();
}

public class PermanentEmployee : Employee{
    public override void SetLeaveBalance()
    {
        LeaveBalance = 24;
    }
}
 public class ContractEmployee : Employee{
    public override void SetLeaveBalance(){
        LeaveBalance = 12;
    }
 }

 public class LeaveRequest{
    public int LeaveId {get;set;}
    public int EmployeeId{get; set;}
    public int NumberOfDays{get; set;}
    public String Reason{get;set;}

    public void DisplayLeave(){
        Console.WriteLine($"Leave ID        : {LeaveId}");
        Console.WriteLine($"Employee ID     : {EmployeeId}");
        Console.WriteLine($"Number Of Days  : {NumberOfDays}");
        Console.WriteLine($"Reason          : {Reason}");
    }
 }
