using System.Collections;
using System;

class Program{
    public static void Main(){
        List<Employee> employees = new List<Employee>();
        PermanentEmployee emp1 = new PermanentEmployee
        {
            EmployeeId = 101,
            Name = "Ammar Khan",
            Department = "IT"
        };
        emp1.SetLeaveBalance();
        employees.Add(emp1);

        ContractEmployee emp2 = new ContractEmployee
        {
            EmployeeId = 102,
            Name = "Priya Sharma",
            Department = "HR"
        };
        emp2.SetLeaveBalance();
        employees.Add(emp2);

        PermanentEmployee emp3 = new PermanentEmployee
        {
            EmployeeId = 103,
            Name = "Rahul Patil",
            Department = "Finance"
        };
        emp3.SetLeaveBalance();
        employees.Add(emp3);

        ContractEmployee emp4 = new ContractEmployee
        {
            EmployeeId = 104,
            Name = "Sneha Joshi",
            Department = "Marketing"
        };
        emp4.SetLeaveBalance();
        employees.Add(emp4);

        PermanentEmployee emp5 = new PermanentEmployee
        {
            EmployeeId = 105,
            Name = "Arjun Mehta",
            Department = "IT"
        };
        emp5.SetLeaveBalance();
        employees.Add(emp5);

        ContractEmployee emp6 = new ContractEmployee
        {
            EmployeeId = 106,
            Name = "Fatima Sheikh",
            Department = "Sales"
        };
        emp6.SetLeaveBalance();
        employees.Add(emp6);

        List<LeaveRequest> leaveRequests = new List<LeaveRequest>()

        {
            new LeaveRequest
            {
                LeaveId = 1,
                EmployeeId = 101,
                NumberOfDays = 2,
                Reason = "Fever"
            },
            new LeaveRequest
            {
                LeaveId = 2,
                EmployeeId = 103,
                NumberOfDays = 5,
                Reason = "Family Function"
            },
            new LeaveRequest
            {
                LeaveId = 3,
                EmployeeId = 102,
                NumberOfDays = 1,
                Reason = "Personal Work"
            },
            new LeaveRequest
            {
                LeaveId = 4,
                EmployeeId = 105,
                NumberOfDays = 3,
                Reason = "Vacation"
            },
            new LeaveRequest
            {
                LeaveId = 5,
                EmployeeId = 104,
                NumberOfDays = 2,
                Reason = "Medical Checkup"
            },
            new LeaveRequest
            {
                LeaveId = 6,
                EmployeeId = 106,
                NumberOfDays = 4,
                Reason = "Wedding"
            }
        };

        Console.WriteLine("Employee details ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        foreach(var emp in employees){
            emp.DisplayDetails();
            Console.WriteLine("_______________________________");
        }
        Console.WriteLine("Leave Application ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        foreach(var leave in leaveRequests){
            leave.DisplayLeave();
            Console.WriteLine("_______________________________");
        }
        Console.WriteLine("Permanent Employees ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        foreach(var emp in employees){
            if(emp is PermanentEmployee){
                emp.DisplayDetails();
                Console.WriteLine("_______________________________");
            }
        }
        Console.WriteLine("Search for employee id 103 ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        foreach(var emp in employees){
            if(emp.EmployeeId == 103 ){
                emp.DisplayDetails();
            }
        }
        Console.WriteLine($"Total Employees      : {employees.Count}");
            Console.WriteLine($"Leaver Request Count : {leaveRequests.Count}");
    }

    
}