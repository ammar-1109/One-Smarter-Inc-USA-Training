// Scenario list coln

// A library stores the names of available books in a List. Display all books, add one new book, remove one old book, and display the updated list along with the total number of books.

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> books = new List<string>()
        {
            "Harry Potter",
            "The Alchemist",
            "Wings of Fire",
            "Rich Dad Poor Dad"
        };

        Console.WriteLine("Available Books:");
        foreach (string book in books)
        {
            Console.WriteLine(book);
        }

        books.Add("Atomic Habits");

        books.Remove("The Alchemist");

        Console.WriteLine("\nUpdated Book List:");
        foreach (string book in books)
        {
            Console.WriteLine(book);
        }

        Console.WriteLine("\nTotal Number of Books: " + books.Count);
    }
}