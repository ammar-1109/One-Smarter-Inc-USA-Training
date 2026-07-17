using System.Collections.Generic;
// list and dictionary,

class Collections{

    static void Main(){
        // List<String> names = new List<string>();
        // names.Add("Ammar");
        // names.Add("Ali");
        // names.Add("Ahmed");
        // names.Add("Ayaan");
        // names.Add("Zaid");
        // names.Add("Faizan");
        // names.Add("Imran");
        // names.Add("Rahul");
        // names.Add("Rohan");
        // names.Add("Sahil");

        // foreach (string name in names)
        // {
        //     Console.WriteLine(name);
        // }




        //
        List<Stud> st = new List<Stud>{
            new Stud{ id =1 , sname = "Ruhi"},
            new Stud{ id =2 , sname = "John"},
            new Stud{ id =3 , sname = "aryan"},
            new Stud{ id =4 , sname = "om"},

        };

        List<Teacher> t = new List<Teacher>{
            new Teacher{id = 101, tname = "karti"},
            new Teacher{id = 102, tname = "Rohan"},

        };

        foreach(var stu in st){
            Console.WriteLine("Student id : "+stu.id+"   name : "+stu.sname);
        }
    }
}