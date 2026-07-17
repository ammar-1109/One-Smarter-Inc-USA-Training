using _16Jul26.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;

namespace _16Jul26.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee()
                {
                    Id = 101,
                    Name = "Ammar",
                    Department = "IT",
                    Salary = 65000,
                    Email = "ammar@example.com"
                },

                new Employee()
                {
                    Id = 102,
                    Name = "Rahul",
                    Department = "HR",
                    Salary = 48000,
                    Email = "rahul@example.com"
                },

                new Employee()
                {
                    Id = 103,
                    Name = "Sneha",
                    Department = "Finance",
                    Salary = 72000,
                    Email = "sneha@example.com"
                },

                new Employee()
                {
                    Id = 104,
                    Name = "Priya",
                    Department = "Marketing",
                    Salary = 55000,
                    Email = "priya@example.com"
                },
                new Employee()
                {
                    Id = 101,
                    Name = "Ammar",
                    Department = "IT",
                    Salary = 65000,
                    Email = "ammar@example.com"
                },

                new Employee()
                {
                    Id = 102,
                    Name = "Rahul",
                    Department = "HR",
                    Salary = 48000,
                    Email = "rahul@example.com"
                },

                new Employee()
                {
                    Id = 103,
                    Name = "Sneha",
                    Department = "Finance",
                    Salary = 72000,
                    Email = "sneha@example.com"
                },

                new Employee()
                {
                    Id = 104,
                    Name = "Priya",
                    Department = "Marketing",
                    Salary = 55000,
                    Email = "priya@example.com"
                },

                new Employee()
                {
                    Id = 105,
                    Name = "Arjun",
                    Department = "Sales",
                    Salary = 60000,
                    Email = "arjun@example.com"
                },

                new Employee()
                {
                    Id = 106,
                    Name = "Neha",
                    Department = "IT",
                    Salary = 70000,
                    Email = "neha@example.com"
                },

                new Employee()
                {
                    Id = 107,
                    Name = "Vikram",
                    Department = "Finance",
                    Salary = 68000,
                    Email = "vikram@example.com"
                },

                new Employee()
                {
                    Id = 108,
                    Name = "Pooja",
                    Department = "HR",
                    Salary = 50000,
                    Email = "pooja@example.com"
                },

                new Employee()
                {
                    Id = 109,
                    Name = "Karan",
                    Department = "Marketing",
                    Salary = 58000,
                    Email = "karan@example.com"
                },

                new Employee()
                {
                    Id = 110,
                    Name = "Meera",
                    Department = "Sales",
                    Salary = 62000,
                    Email = "meera@example.com"
                },

                new Employee()
                {
                    Id = 111,
                    Name = "Rohan",
                    Department = "IT",
                    Salary = 75000,
                    Email = "rohan@example.com"
                },

                new Employee()
                {
                    Id = 112,
                    Name = "Ananya",
                    Department = "Finance",
                    Salary = 71000,
                    Email = "ananya@example.com"
                },

                new Employee()
                {
                    Id = 113,
                    Name = "Saurabh",
                    Department = "Sales",
                    Salary = 59000,
                    Email = "saurabh@example.com"
                },

                new Employee()
                {
                    Id = 114,
                    Name = "Kavya",
                    Department = "HR",
                    Salary = 53000,
                    Email = "kavya@example.com"
                }
                        };
            return View(employees);
        }
        
        public IActionResult Department()
        {
            List<Department> departments = new List<Department>()
            {
                new Department()
                {
                    Name = "IT",
                    Head = "Rohit Sharma",
                    Contact = 9876543210,
                    Email = "it@company.com"
                },

                new Department()
                {
                    Name = "HR",
                    Head = "Anjali Verma",
                    Contact = 9876543211,
                    Email = "hr@company.com"
                },

                new Department()
                {
                    Name = "Finance",
                    Head = "Vikram Patel",
                    Contact = 9876543212,
                    Email = "finance@company.com"
                },

                new Department()
                {
                    Name = "Marketing",
                    Head = "Neha Singh",
                    Contact = 9876543213,
                    Email = "marketing@company.com"
                },

                new Department()
                {
                    Name = "Sales",
                    Head = "Arjun Mehta",
                    Contact = 9876543214,
                    Email = "sales@company.com"
                } };

            return View(departments);
        }

      
    }
}
