using System;
using CustomerProductClasses;
using System.Collections.Generic;



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
            // TestCustomerSave();
            
            // inheritance test methods - these are incomplete
            //TestClothingConstructor();
            //TestGearConstructor();
            //TestProductListSaveWithInheritance();
            //TestProductEqualsWithInheritance();
            //TestProductGetHashCodeWithInheritance();


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

        #region Inheritance Test Methods

         static void TestClothingConstructor()
        {
            Clothing c1 = new Clothing(3, "C100", "Running tights", 69.99M, 3, "pants", "womens", "large", "blue", "Lucy");

            Console.WriteLine("Testing clothing constructors");
            Console.WriteLine("Overloaded constructor.  Expecting 3, c100 etc \n" + c1.ToString());
            Console.WriteLine();
        }

        static void TestGearConstructor()
        {
            Gear g1 = new Gear(5, "G100", "Sky 10 Kayak", 1049M, 2, "paddle", "Eddyline", "plastic laminate", 32);

            Console.WriteLine("Testing clothing constructors");
            Console.WriteLine("Overloaded constructor.  Expecting 5, G100 etc \n" + g1.ToString());
            Console.WriteLine();
        }

        static void TestProductEqualsWithInheritance()
        {
            // these 2 objects should be equal.  They reference the same object.
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);
            Product p2 = new Product(1, "T100", "This is a test product", 100M, 10);
            Clothing c1 = new Clothing(3, "C100", "Running tights", 69.99M, 3, "pants", "womens", "large", "blue", "Lucy");
            Clothing c2 = new Clothing(3, "C100", "Running tights", 69.99M, 3, "pants", "womens", "large", "blue", "Lucy");
            Clothing c3 = new Clothing(3, "C100", "Running tights", 69.99M, 3, "not pants", "womens", "large", "blue", "Lucy");
            Gear g1 = new Gear(5, "G100", "Sky 10 Kayak", 1049M, 2, "paddle", "Eddyline", "plastic laminate", 32);
            Gear g2 = new Gear(5, "G100", "Sky 10 Kayak", 1049M, 2, "paddle", "Eddyline", "plastic laminate", 32);
            Gear g3 = new Gear(1, "T100", "This is a test product", 100M, 10, "paddle", "Eddyline", "plastic laminate", 32);

            Console.WriteLine("Testing product equals.");
            Console.WriteLine("2 products that have the same properties should be equal.  Expecting true. " + p1.Equals(p2));
            Console.WriteLine("2 clothing that have the same properties should be equal.  Expecting true. " + c1.Equals(c2));
            Console.WriteLine("2 gear that have the same properties should be equal.  Expecting true. " + g1.Equals(g2));
            Console.WriteLine("Product and Gear should not be equal.  Expecting false. " + p1.Equals(g3));

            Console.WriteLine("Testing product ==.");
            Console.WriteLine("2 products that have the same properties should be equal.  Expecting true. " + (p1 == p2));
            Console.WriteLine("2 clothing that have the same properties should be equal.  Expecting true. " + (c1 == c2));
            Console.WriteLine("2 gear that have the same properties should be equal.  Expecting true. " + (g1 == g2));
            Console.WriteLine("Product and Gear should not be equal.  Expecting false. " + (p1 == g3));
            Console.WriteLine("2 clothing that have the same product attributes should not be equal.  Expecting false. " + (c1 == c3));
            Console.WriteLine();

        }

        static void TestProductGetHashCodeWithInheritance()
        {
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);
            // these 2 objects should have the same hashcode.  The attribute values are all equal.
            Product p2 = new Product(1, "T100", "This is a test product", 100M, 10);
            // this one should have a unique hashcode
            Product p3 = new Product(3, "T300", "This is a test product 3", 300M, 30);
            Clothing c1 = new Clothing(3, "C100", "Running tights", 69.99M, 3, "pants", "womens", "large", "blue", "Lucy");
            Clothing c2 = new Clothing(3, "C100", "Running tights", 69.99M, 3, "pants", "womens", "large", "blue", "Lucy");
            Clothing c3 = new Clothing(3, "C100", "Running tights", 69.99M, 3, "not pants", "womens", "large", "blue", "Lucy");
            Gear g1 = new Gear(5, "G100", "Sky 10 Kayak", 1049M, 2, "paddle", "Eddyline", "plastic laminate", 32);
            Gear g2 = new Gear(5, "G100", "Sky 10 Kayak", 1049M, 2, "paddle", "Eddyline", "plastic laminate", 32);
            Gear g3 = new Gear(1, "T100", "This is a test product", 100M, 10, "paddle", "Eddyline", "plastic laminate", 32);

            Console.WriteLine("Testing product GetHashCode");
            Console.WriteLine("2 products that have the same properties should have the same hashcode.  Expecting true. " + (p1.GetHashCode() == p2.GetHashCode()));
            Console.WriteLine("2 products that have different properties should have different hashcodes.  Expecting false. " + (p1.GetHashCode() == p3.GetHashCode()));
            Console.WriteLine("2 clothing that have the same properties should have the same hashcode.  Expecting true. " + (c1.GetHashCode() == c2.GetHashCode()));
            Console.WriteLine("2 clothing that have different properties should have different hashcodes.  Expecting false. " + (c1.GetHashCode() == c3.GetHashCode()));
            Console.WriteLine("2 gear that have the same properties should have the same hashcode.  Expecting true. " + (g1.GetHashCode() == g2.GetHashCode()));
            Console.WriteLine("2 gear that have different properties should have different hashcodes.  Expecting false. " + (g1.GetHashCode() == g3.GetHashCode()));
            Console.WriteLine("product and gear that have same properties should have different hashcodes.  Expecting false. " + (p1.GetHashCode() == g3.GetHashCode()));
            Console.WriteLine();

            // this will fail before overriding GetHashCode
            HashSet<Product> set = new HashSet<Product>();
            set.Add(p1);
            set.Add(p3);
            set.Add(c1);
            set.Add(c3);
            set.Add(g1);
            set.Add(g3);
            Console.WriteLine("Testing product GetHashCode by using a hash set");
            Console.WriteLine("The hash set should be able to find a product with the same attributes.  Expecting true. " + set.Contains(p2));
            Console.WriteLine("The hash set should be able to find a clothing with the same attributes.  Expecting true. " + set.Contains(c2));
            Console.WriteLine("The hash set should be able to find a gear with the same attributes.  Expecting true. " + set.Contains(g2));

            Console.WriteLine();
        }

        static void TestProductListSaveWithInheritance()
        {
            ProductList list = new ProductList();
            Product p1 = new Product(1, "T100", "This is a test product", 100M, 10);
            Product p2 = new Product(2, "T200", "This is a test product 2", 200M, 20);
            Clothing c1 = new Clothing(3, "C100", "Running tights", 69.99M, 3, "pants", "womens", "large", "blue", "Lucy");
            Clothing c2 = new Clothing(4, "C200", "Running tights", 69.99M, 4, "pants", "womens", "medium", "black", "Nike");
            Gear g1 = new Gear(5, "G100", "Sky 10 Kayak", 1049M, 2, "paddle", "Eddyline", "plastic laminate", 32);
            Gear g2 = new Gear(6, "G200", "Sting Ray Posi-Lok kayak paddle", 149.95m, 5, "paddle", "Aqua-Bound", "carbon shaft", 1.75);

            list.Add(p1);
            list += p2;
            list += c1;
            list += c2;
            list += g1;
            list += g2;
            list.Save();

            list = new ProductList();
            list.Fill();
            Console.WriteLine("Testing product list save and fill.");
            Console.WriteLine("After Fill Count.  Expecting 6. " + list.Count);
            Console.WriteLine("ToString.  Expect six products total, 2 clothing and 2 gear \n" + list.ToString());
            
            Console.WriteLine();
        }
        

        #endregion

    }
}