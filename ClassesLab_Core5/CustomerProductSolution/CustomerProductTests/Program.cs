using System;
using CustomerProductClasses;


namespace CustomerProductTests
{
    class Program
    {
        static void Main(string[] args)
        {
            // customer test methods
            // TestCustomerConstructors();
            // TestToString();
            // TestPropertyGetters();
            // TestPropertySetters();
            // TestCustomerEquals();
            // TestCustomerEqualityOperators();
            // GetCLCount();
            // TestChangeCustomerByPosition();
            // TestGetCustomerByEmail();
            // TestRemoveCustomers();
            // TestCustomerListToString();
            // TestCustomerFill();
            TestCustomerSave();


        }

        #region Customer Test Methods
        //test methods
        static void TestCustomerConstructors()
        {
            Customer c1 = new Customer();
            Customer c2 = new Customer(1, "John", "Doe", "John@gmail.com", "5555555555");

            Console.WriteLine("Testing both constructors");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("(Default constructor)  Expecting default values: " + c1.ToString());
            Console.WriteLine("(Overloaded constructor)  Expecting 1, John, Doe, John@gmail.com, 5555555555 - " + c2.ToString());
            Console.WriteLine();
        }

        static void TestToString()
        {

            Customer c1 = new Customer(1, "John", "Doe", "John@gmail.com", "5555555555");

            Console.WriteLine("Testing ToString");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Expecting 1, John, Doe, John@gmail.com, 5555555555 - " + c1.ToString());
            Console.WriteLine();
        }

        static void TestPropertyGetters()
        {

            Customer c1 = new Customer(1, "John", "Doe", "John@gmail.com", "5555555555");

            Console.WriteLine("Testing getters");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Id-  (Expecting 1): " + c1.Id);
            Console.WriteLine("Name-  (Expecting John): " + c1.FirstName);
            Console.WriteLine("Last Name-  (Expecting Doe): " + c1.LastName);
            Console.WriteLine("Email- (Expecting John@gmail.com): " + c1.EmailAddress);
            Console.WriteLine("Phone Number-  (Expecting 5555555555): " + c1.PhoneNumber);
            Console.WriteLine();
        }

        static void TestPropertySetters()
        {

            Customer c1 = new Customer(1, "John", "Doe", "John@gmail.com", "5555555555");

            Console.WriteLine("Testing setters");
            Console.WriteLine("------------------------------------------------------------");

            c1.Id = 2;
            c1.FirstName = "Jane";
            c1.LastName = "Doe";
            c1.EmailAddress = "jane@gmail.com";
            c1.PhoneNumber = "5555555556";

            Console.WriteLine(c1.ToString());
        }

        static void TestCustomerEquals()
        {
            Customer c1 = new Customer(1, "John", "Doe", "John@gmail.com", "5555555555");
            Customer c1Reference = c1;
            Customer c2 = new Customer(1, "John", "Doe", "John@gmail.com", "5555555555");
            Customer c3 = new Customer();

            Console.WriteLine("Expecting True:");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine(c1.Equals(c1Reference));
            Console.WriteLine(c1.Equals(c2));
            Console.WriteLine("Expecting False:");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine(c1.Equals(c3));
            
        }

        static void TestCustomerEqualityOperators()
        {
            Customer c1 = new Customer(1, "John", "Doe", "john@gmail.com", "5555555555");
            Customer c2 = new Customer(1, "John", "Doe", "john@gmail.com", "5555555555");
            Customer c3 = new Customer();

            Console.WriteLine("Expecting True:");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine(c1 == c2);
            Console.WriteLine("Expecting False:");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine(c1 == c3);
            Console.WriteLine(c1 != c2);
        }
        #endregion

        #region CustomerList Test Methods

        static void GetCLCount()
        {
            CustomerList cl = new CustomerList();
            cl.Add(1, "John", "Doe", "John@gmail.com", "5555555555");
            cl.Add(2, "Jane", "Doe", "jane@gmail.com", "5555555556");

            Console.WriteLine("Testing Count");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Expecting 2: " + cl.Count);
        }

        static void TestGetCustomerByIndex()
        {
            CustomerList cl = new CustomerList();
            cl.Add(1, "John", "Doe", "John@gmail.com", "5555555555");
            cl.Add(2, "Jane", "Doe", "jane@gmail.com", "5555555556");
            cl.Add(3, "Jonny", "Doe", "Jonny@gmail.com", "5555555557");

            Console.WriteLine("Testing GetCustomerByIndex");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Expecting 1, John, Doe, John@gmail.com, 5555555555: ");
            Console.WriteLine(cl[0].ToString());
        }

        static void TestChangeCustomerByPosition()
        {
            CustomerList cl = new CustomerList();
            cl.Add(1, "John", "Doe", "John@gmail.com", "5555555555");
            cl.Add(2, "Jane", "Doe", "jane@gmail.com", "5555555556");
            cl.Add(3, "Jonny", "Doe", "Jonny@gmail.com", "5555555557");

            cl[1] = new Customer(4, "Jill", "Doe", "jill@gmail.com", "5555555558");

            Console.WriteLine("Testing ChangeCustomerByPosition");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Expecting: 4, Jill, Doe, jill@gmail.com, 5555555558");
            Console.WriteLine(cl[1].ToString());
        }

        static void TestGetCustomerByEmail()
        {
            CustomerList cl = new CustomerList();
            cl.Add(1, "John", "Doe", "John@gmail.com", "5555555555");
            cl.Add(2, "Jane", "Doe", "jane@gmail.com", "5555555556");
            cl.Add(3, "Jonny", "Doe", "jonny@gmail.com", "5555555557");

            Console.WriteLine("Testing GetCustomerByEmail");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Expecting 3, Jonny, Doe, jonny@gmail.com, 5555555557: ");
            try
            {
                Console.WriteLine(cl["jonny@gmail.com"].ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't find customer with that email.");
            }
            
        }

        static void TestAddCustomers()
        {
            CustomerList cl = new CustomerList();
            Customer c = new Customer(2, "Jane", "Doe", "jane@gmail.com", "5555555556");
            Customer c2 = new Customer(3, "Jonny", "Doe", "jonny@gmail.com", "5555555557");
            cl.Add(1, "John", "Doe", "John@gmail.com", "5555555555");
            cl.Add(c);
            cl += c2;
            

            Console.WriteLine("Testing Add");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Expecting three customers: with ID 1, 2, and 3: ");
            foreach (Customer customer in cl)
            {
                Console.WriteLine(customer.ToString());
            }
        }

        static void TestRemoveCustomers()
        {
            CustomerList cl = new CustomerList();
            cl.Add(1, "John", "Doe", "John@gmail.com", "5555555555");
            cl.Add(2, "Jane", "Doe", "jane@gmail.com", "5555555556");
            cl.Add(3, "Jonny", "Doe", "jonny@gmail.com", "5555555557");

            cl.Remove(cl[0]);
            cl -= cl[0];
            cl = cl - 1;
            

            Console.WriteLine("Testing Remove");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Expecting zero customers: ");
            foreach (Customer customer in cl)
            {
                Console.WriteLine(customer.ToString());
            }

        }

        static void TestCustomerListToString()
        {
            CustomerList cl = new CustomerList();
            cl.Add(1, "John", "Doe", "John@gmail.com", "5555555555");
            cl.Add(2, "Jane", "Doe", "jane@gmail.com", "5555555556");
            cl.Add(3, "Jonny", "Doe", "jonny@gmail.com", "5555555557");

            Console.WriteLine("Testing ToString");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Expecting three customers with ID's 1, 2, and 3.");
            foreach (Customer customer in cl)
            {
                Console.WriteLine(customer.ToString());
            }
        }

        static void TestCustomerFill()
        {
            CustomerList cl = new CustomerList();
            cl.Fill();

            Console.WriteLine("Testing Fill");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Expecting 2 customers: ");
            foreach (Customer customer in cl)
            {
                Console.WriteLine(customer.ToString());
            }
        }

        static void TestCustomerSave()
        {
            CustomerList cl = new CustomerList();
            cl.Add(1, "John", "Doe", "John@gmail.com", "5555555555");
            cl.Add(2, "Jane", "Doe", "jane@gmail.com", "5555555556");
            cl.Add(3, "Jonny", "Doe", "jonny@gmail.com", "5555555557");
            
            cl.Save();

            cl = cl - 3;

            Console.WriteLine("Testing Save");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Expecting 0 customers: ");
            
            foreach (Customer customer in cl)
            {
                Console.WriteLine(customer.ToString());
            }
            
            cl.Fill();

            Console.WriteLine("Expecting 3 customers: ");
            
            foreach (Customer customer in cl)
            {
                Console.WriteLine(customer.ToString());
            }
        }




        #endregion

    }
}