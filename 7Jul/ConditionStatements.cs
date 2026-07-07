/// Conditional Statements

using System;

bool pass = true;
if(pass == true){
    Console.WriteLine("Student passed the test");
}
else{
    Console.WriteLine("Student failed the test.");
}

int marks = 30;
if (marks >= 90){
    Console.WriteLine("Grade : A");
}
else if ( marks >=80){
    Console.WriteLine("Grade : B");
}
else if ( marks >=70){
    Console.WriteLine("Grade : C");
}
else if ( marks >=60){
    Console.WriteLine("Grade : D");
}
else if ( marks >=50){
    Console.WriteLine("Grade : E");
}
else if ( marks >=40){
    Console.WriteLine("Grade : F");
}
else{
    Console.WriteLine("Failed");
}