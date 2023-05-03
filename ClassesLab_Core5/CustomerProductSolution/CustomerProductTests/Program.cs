using System;
using CustomerProductClasses;

namespace CustomerProductTests
{
    class Program
    {
        static void Main(string[] args)
        {
            // customer test methods
            TestProductConstructors();
            TestToString();
            TestPropertyGetters();
            TestPropertySetters();


        }
        
        //test methods
        static void TestProductConstructors()
        {
            // Product p1 = new Product();
            // Product p2 = new Product(1, "T100", "This is a test product", 100M, 10);
            //
            // Console.WriteLine("Testing both constructors");
            // Console.WriteLine("Default constructor.  Expecting default values. " + p1.ToString());
            // Console.WriteLine("Overloaded constructor.  Expecting 1, T100, 100, This is a test product, 10 " + p2.ToString());
            // Console.WriteLine();

            Customer c1 = new Customer();
            Customer c2 = new Customer(1, "John", "Doe", "John@gmail.com", "5555555555");

            Console.WriteLine("Testing both constructors");
            Console.WriteLine("Default constructor.  Expecting default values. " + c1.ToString());
            Console.WriteLine("Overloaded constructor.  Expecting 1, John, Doe, John@gmail.com, 5555555555" +
                              " -  Actual " + c2.ToString());
            Console.WriteLine();
        }

        static void TestToString()
        {
            // Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);
            //
            // Console.WriteLine("Testing ToString");
            // Console.WriteLine("Expecting 1, T100, 100, This is a test product, 10 " + p1.ToString());
            // Console.WriteLine("Expecting 1, T100, 100, This is a test product, 10 " + p1);
            // Console.WriteLine();

            Customer c1 = new Customer(1, "John", "Doe", "John@gmail.com", "5555555555");

            Console.WriteLine("Testing ToString");
            Console.WriteLine("Expecting 1, John, Doe, John@gmail.com, 5555555555" + " -  Actual " + c1.ToString());
        }

        static void TestPropertyGetters()
        {
            // Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);
            //
            // Console.WriteLine("Testing getters");
            // Console.WriteLine("Id.  Expecting 1. " + p1.Id);
            // Console.WriteLine("Code.  Expecting T100. " + p1.Code);
            // Console.WriteLine("Description.  Expecting This is a test product. " + p1.Description);
            // Console.WriteLine("Price.  Expecting 100. " + p1.UnitPrice);
            // Console.WriteLine("Quantity.  Expecting 10. " + p1.QuantityOnHand);
            // Console.WriteLine();

            Customer c1 = new Customer(1, "John", "Doe", "John@gmail.com", "5555555555");

            Console.WriteLine("Testing getters");
            Console.WriteLine("Id.  Expecting 1. " + c1.Id);
            Console.WriteLine("Name.  Expecting John. " + c1.FirstName);
            Console.WriteLine("Last Name.  Expecting Doe. " + c1.LastName);
            Console.WriteLine("Email. Expecting John@gmail.com. " + c1.EmailAddress);
            Console.WriteLine("Phone Number.  Expecting 5555555555. " + c1.PhoneNumber);
        }

        static void TestPropertySetters()
        {
            // Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);
            //
            // Console.WriteLine("Testing setters");
            // p1.Id = 2;
            // p1.Code = "T000";
            // p1.Description = "First product";
            // p1.UnitPrice = 200;
            // p1.QuantityOnHand = 20;
            // Console.WriteLine("Expecting 2, T000, 200, First product, 20 " + p1);
            // Console.WriteLine();

            Customer c1 = new Customer(1, "John", "Doe", "John@gmail.com", "5555555555");

            Console.WriteLine("Testing setters");

            c1.Id = 2;
            c1.FirstName = "Jane";
            c1.LastName = "Doe";
            c1.EmailAddress = "jane@gmail.com";
            c1.PhoneNumber = "5555555556";

            Console.WriteLine(c1.ToString());
        }
    }
}