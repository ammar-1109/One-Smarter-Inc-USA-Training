using _16July2026.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Cache;

namespace _16July2026.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Student> students = new List<Student>(){
            new Student { Id = 101, Name = "Ammar", Age = 21, Course = "Dotnet Training" , Gender='M', fees=983.22, marks=78.87f},
            new Student { Id = 102, Name = "Ayesha", Age = 22, Course = "Java Full Stack" ,Gender='F', fees=993.22, marks=78.87f},
            new Student { Id = 103, Name = "Rahul", Age = 20, Course = "Python Development" , Gender='M', fees=883.22, marks=79.8f},
            new Student { Id = 104, Name = "Sneha", Age = 23, Course = "Data Science", Gender='F', fees=683.22, marks=56.87f }
            };
            return View(students);
        }

       
    }
}
