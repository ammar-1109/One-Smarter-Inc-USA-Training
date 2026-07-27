using System;
using System.Collections.Generic;

public class Course{
    public int CourseID{get; set;}
    public string CourseName {get; set;}
    public int Credits {get; set;}

    public void Display()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Course ID   : " + CourseID);
        Console.WriteLine("Course Name : " + CourseName);
        Console.WriteLine("Credits     : " + Credits);
        Console.WriteLine("--------------------------------");
    }
}