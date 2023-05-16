using System.Collections;
using System.Collections.Generic;
using System.Numerics;


namespace CustomerProductClasses
{
    public class CustomerList : IEnumerable<Customer>
    {
        private List<Customer> _customers;

        #region Constructors

        //constructor to instantiate the list
        public CustomerList() => _customers = new List<Customer>();


        #endregion

        #region Properties

        //read only property to return the number of customers in the list
        public int Count => _customers.Count;

        //property to return/set customer at a specified index
        public Customer this[int i]
        {
            get => _customers[i];
            set => _customers[i] = value;
        }

        //property to return a customer by an email address
        public Customer this[string email]
        {
            get
            {
                //loop through the list of customers
                foreach (Customer c in _customers)
                {
                    //if the email address matches return the customer
                    if (c.EmailAddress == email)
                        return c;
                }
                //if no match return null
                return null;
            }
        }





        #endregion

        #region methods

        //add a customer to the list must pass in a customer object
        public void Add(Customer customer) => _customers.Add(customer);

        //add a customer to the list must specify all the customer properties
        public void Add(int customerId, string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            Customer c = new Customer(customerId, firstName, lastName, emailAddress, phoneNumber);
            _customers.Add(c);
        }

        //fill the list with customers from xml file
        public void Fill() => _customers = CustomerDb.GetCustomers();
        
        //save the list to the xml file
        public void Save() => CustomerDb.SaveCustomers(_customers);
    
        //remove a customer from the list must pass in a customer object
        public void Remove(Customer customer) => _customers.Remove(customer);

        // override the ToString method to return a string of all the customers in the list
        public override string ToString()
        {
            string output = "";
            foreach (Customer c in _customers)
            {
                output += _customers.ToString() + "\n";
            }

            return output;
        }

        #endregion

        #region Operators

        //add functionality to the + operator
        public static CustomerList operator +(CustomerList cl, Customer c)
        {
            //allow user to use + to add customers to the list
            cl.Add(c);
            //return the list
            return cl;
        }

        //add functionality to the - operator
        public static CustomerList operator -(CustomerList cl, Customer c)
        {
            //allow user to use - to remove customers to the list
            cl.Remove(c);
            //return the list
            return (cl);
        }

        //add functionality to the - operator
        public static CustomerList operator -(CustomerList cl, int count)
        {
            //allow user to use - to remove a specified number of customers to the list
            // for loop to iterate through the list removing customers at index 0
            for (int i = 0; i < count; i++)
            {
                cl._customers.RemoveAt(0);   
            }
            //return the list
            return cl;
        }

        #endregion
        
        #region Interfaces   

        //initial IEnumerable to allow the use of a foreach loop in testing
        public IEnumerator<Customer> GetEnumerator()
        {
            //for each customer in the list
            foreach (Customer c in _customers)
            {
                //yield return them, so they can be returned one by one
                yield return c;
            }
        }
        
        // method to create/return GetEnumerator
        IEnumerator IEnumerable.GetEnumerator()
        {
            //return GetEnumerator to call allow allow iteration over the list
            return GetEnumerator();
        }

        #endregion

    }
}