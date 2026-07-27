using Microsoft.AspNetCore.Mvc;
using _27July.Models;

namespace _27July.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = 101,
                Name = "Mohammad",
                LastName = "Ammar",
                Dept = "IT",
                PhoneNum = "9881848251"
            },

            new Employee()
            {
                Id = 102,
                Name = "Katik",
                LastName = "Hande",
                Dept = "HR",
                PhoneNum = "9876543211"
            },

            new Employee()
            {
                Id = 103,
                Name = "Priya",
                LastName = "Patil",
                Dept = "Finance",
                PhoneNum = "9876543212"
            }
        };

        // GET : api/Employee
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(employees);
        }

        // GET : api/Employee/101
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = employees.FirstOrDefault(x => x.Id == id);

            if (employee == null)
            {
                return NotFound("Employee not found.");
            }

            return Ok(employee);
        }

        // POST : api/Employee
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            employees.Add(employee);

            return Ok(employee);
        }

        // PUT : api/Employee/101
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            var emp = employees.FirstOrDefault(x => x.Id == id);

            if (emp == null)
            {
                return NotFound("Employee not found.");
            }

            emp.Name = employee.Name;
            emp.LastName = employee.LastName;
            emp.Dept = employee.Dept;
            emp.PhoneNum = employee.PhoneNum;

            return Ok(emp);
        }

        // DELETE : api/Employee/101
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var emp = employees.FirstOrDefault(x => x.Id == id);

            if (emp == null)
            {
                return NotFound("Employee not found.");
            }

            employees.Remove(emp);

            return Ok("Employee deleted successfully.");
        }
    }
}