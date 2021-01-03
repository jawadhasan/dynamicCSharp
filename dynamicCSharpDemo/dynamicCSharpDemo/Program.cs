using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace dynamicCSharpDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            dynamic customer = new ExpandoObject();
            customer.Id = 42;
            customer.Print = (Action) (() => Console.WriteLine("This was dynamically added"));
            customer.GetBalance = (Func<int>) (() => 12);

            customer.Print();
           var balance = customer.GetBalance();


        }

        static void Example1()
        {
            dynamic printer = new Printer();

            printer.Print("Hello World!");

            printer.Stop(); //Run-time error
        }

        static void Example2()
        {
            var customers = new Dictionary<string, string>();
            customers.Add("Id", "42");

            foreach (var item in customers)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        static void Example3()
        {
            dynamic customer = new ExpandoObject();
            customer.Id = 42;
            customer.sb = new StringBuilder("a string builder");

            //if we want to dynamically add properties to this expando object,
            //we can convert it to a dictionary first and then call Add method.

            var c = (IDictionary<string, object>)customer;
            c.Add("stringPropertyName", "propertyValue");

            foreach (var item in c)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
