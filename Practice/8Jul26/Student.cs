// class - logical entity, it defines the properties (data) and the methods the object will have.
// Stores value of similar data

using System;


class Student
{
    public string name;
    public int roll_number;
    public char gender;
    public int dob;
    public float height;
    public string college;
    public Student(String name, int roll_number, char gender, int dob, float height, String college){
        this.name = name;
        this.roll_number = roll_number;
        this.gender = gender;
        this.dob = dob;
        this.height = height;
        this.college = college;
    }
    public void Display()
    {
        Console.WriteLine("Student Details :");
        Console.WriteLine("Name        : " + name);
        Console.WriteLine("Roll Number : " + roll_number);
        Console.WriteLine("Gender      : " + gender);
        Console.WriteLine("DOB         : " + dob);
        Console.WriteLine("Height      : " + height);
        Console.WriteLine("College     : " + college);
    }
}