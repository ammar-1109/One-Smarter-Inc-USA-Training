using System;
using System.Collections.Generic;

class Program
{
    static List<Student> students = new List<Student>();
    static List<Course> courses = new List<Course>();

    static void Main(string[] args)
    {
        int choice = 0;

        do
        {
            try
            {
                Console.WriteLine("\n==================================");
                Console.WriteLine("     Student Management System");
                Console.WriteLine("==================================");
                Console.WriteLine("1. Register Student");
                Console.WriteLine("2. View Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Add Course");
                Console.WriteLine("5. View Courses");
                Console.WriteLine("6. Register Course");
                Console.WriteLine("7. Display Student Details");
                Console.WriteLine("8. Calculate Fee");
                Console.WriteLine("9. Exit");
                Console.WriteLine("==================================");

                Console.Write("Enter Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RegisterStudent();
                        break;

                    case 2:
                        ViewStudents();
                        break;

                    case 3:
                        SearchStudent();
                        break;

                    case 4:
                        AddCourse();
                        break;

                    case 5:
                        ViewCourses();
                        break;

                    case 6:
                        RegisterCourse();
                        break;

                    case 7:
                        DisplayStudentDetails();
                        break;

                    case 8:
                        CalculateFee();
                        break;

                    case 9:
                        Console.WriteLine("Thank You!");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter numbers only.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: Number is too large.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }

            if (choice != 9)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

        } while (choice != 9);
    }

    static void RegisterStudent()
    {
        Console.WriteLine("\n--- Register Student ---");
        Console.WriteLine("1. Regular Student");
        Console.WriteLine("2. Part-Time Student");
        Console.WriteLine("3. Scholarship Student");
        Console.Write("Select Student Type: ");
        int type = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Student ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        foreach (Student s in students)
        {
            if (s.StudentID == id)
            {
                Console.WriteLine("Student ID already exists.");
                return;
            }
        }

        Console.Write("Enter Name: ");
        string name = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter Department: ");
        string department = Console.ReadLine() ?? string.Empty;

        Student? student = type switch
        {
            1 => new RegularStudent(),
            2 => new PartTimeStudent(),
            3 => new ScholarshipStudent(),
            _ => null
        };

        if (student is null)
        {
            Console.WriteLine("Invalid student type.");
            return;
        }

        student.StudentID = id;
        student.Name = name;
        student.Department = department;
        students.Add(student);
        Console.WriteLine("Student registered successfully.");
    }

    static void ViewStudents()
    {
        Console.WriteLine("\n--- All Students ---");
        if (students.Count == 0)
        {
            Console.WriteLine("No students registered.");
            return;
        }

        foreach (Student student in students)
        {
            student.Display();
        }
    }

    static void SearchStudent()
    {
        Console.Write("\nEnter Student ID to search: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Student? found = FindStudent(id);
        if (found == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        found.Display();
    }

    static void AddCourse()
    {
        Console.WriteLine("\n--- Add Course ---");
        Console.Write("Enter Course ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        foreach (Course c in courses)
        {
            if (c.CourseID == id)
            {
                Console.WriteLine("Course ID already exists.");
                return;
            }
        }

        Console.Write("Enter Course Name: ");
        string name = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter Credits: ");
        int credits = Convert.ToInt32(Console.ReadLine());

        courses.Add(new Course
        {
            CourseID = id,
            CourseName = name,
            Credits = credits
        });

        Console.WriteLine("Course added successfully.");
    }

    static void ViewCourses()
    {
        Console.WriteLine("\n--- All Courses ---");
        if (courses.Count == 0)
        {
            Console.WriteLine("No courses available.");
            return;
        }

        foreach (Course course in courses)
        {
            course.Display();
        }
    }

    static void RegisterCourse()
    {
        Console.Write("\nEnter Student ID: ");
        int studentId = Convert.ToInt32(Console.ReadLine());

        Student? student = FindStudent(studentId);
        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.Write("Enter Course ID: ");
        int courseId = Convert.ToInt32(Console.ReadLine());

        Course? course = FindCourse(courseId);
        if (course == null)
        {
            Console.WriteLine("Course not found.");
            return;
        }

        student.RegisterCourse(course);
    }

    static void DisplayStudentDetails()
    {
        Console.Write("\nEnter Student ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Student? student = FindStudent(id);
        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        student.Display();
    }

    static void CalculateFee()
    {
        Console.Write("\nEnter Student ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Student? student = FindStudent(id);
        if (student == null)
        {
            Console.WriteLine("Student not found.");
            return;
        }

        Console.WriteLine($"Total Fee for {student.Name}: ₹{student.CalculateFee()}");
    }

    static Student? FindStudent(int id)
    {
        foreach (Student student in students)
        {
            if (student.StudentID == id)
            {
                return student;
            }
        }

        return null;
    }

    static Course? FindCourse(int id)
    {
        foreach (Course course in courses)
        {
            if (course.CourseID == id)
            {
                return course;
            }
        }

        return null;
    }
}
