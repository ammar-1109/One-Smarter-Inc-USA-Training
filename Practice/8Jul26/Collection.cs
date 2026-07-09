using System.Collections.Generic;
// list and dictionary,

class Collections{

    static void Main(){
        List<String> names = new List<string>();
        names.Add("Ammar");
        names.Add("Ali");
        names.Add("Ahmed");
        names.Add("Ayaan");
        names.Add("Zaid");
        names.Add("Faizan");
        names.Add("Imran");
        names.Add("Rahul");
        names.Add("Rohan");
        names.Add("Sahil");

        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }
}