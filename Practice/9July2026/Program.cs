using System;
class Program{
    static void Main(){
        // Employee e = new Employee();
        // e.empName = "ammar";
        // e.salary = "15000";

        // Console.WriteLine("Name : "+e.empName+"   salary : "+e.salary);

        // CompiletimePoly c = new CompiletimePoly();
        // c.search(123);
        // c.search("john", "kresinski");
        // c.search(19898298982981.0);

        RuntimePoly p = new RuntimePoly();
        p.checkout(new UpiPayment(), 13022);
        p.checkout(new NetBanking(), 34388);
        p.checkout(new CreditPayment(), 8233);
    }

    


}