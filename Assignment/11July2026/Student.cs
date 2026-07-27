using System;
using System.Collections.Generic;

public abstract class Student
{
    public int StudentID { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public List<Course> EnrolledCourses {get; set;} 
    public Student()
    {
        EnrolledCourses = new List<Course>();
    }

    public virtual void Display()
    {
        Console.WriteLine("========================================");
        Console.WriteLine($"Student ID   : {StudentID}");
        Console.WriteLine($"Name         : {Name}");
        Console.WriteLine($"Department   : {Department}");
        Console.WriteLine($"Student Type : {GetType().Name}");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine("Enrolled Courses:");

        if (EnrolledCourses.Count == 0)
        {
            Console.WriteLine("No courses enrolled.");
        }
        else
        {
            foreach (Course course in EnrolledCourses)
            {
                Console.WriteLine($"{course.CourseID} - {course.CourseName} ({course.Credits} Credits)");
            }
        }

        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"Total Credits : {TotalCredits()}");
        Console.WriteLine($"Total Fee     : ₹{CalculateFee()}");
        Console.WriteLine("========================================");
    }
    public bool RegisterCourse(Course course)
    {
        if (EnrolledCourses.Count >= 5)
        {
            Console.WriteLine("Maximum 5 courses allowed.");
            return false;
        }

        foreach (Course c in EnrolledCourses)
        {
            if (c.CourseID == course.CourseID)
            {
                Console.WriteLine("Course already registered.");
                return false;
            }
        }

        EnrolledCourses.Add(course);
        Console.WriteLine("Course registered successfully.");
        return true;
    }
    public int TotalCredits(){
        int Credits = 0;
        foreach(Course course in EnrolledCourses){
            Credits += course.Credits;
        }
        return Credits;
    }
    public abstract double CalculateFee();
}