using System.Collections;
using System.Collections.Generic;
using System.Numerics;


namespace CustomerProductClasses
{
    public class CustomerList : IEnumerable<Customer>
    {
        private List<Customer> _customers;

        #region Constructors

        public CustomerList() => _customers = new List<Customer>();


        #endregion

        #region Properties

        public int Count => _customers.Count;

        public Customer this[int i]
        {
            get => _customers[i];
            set => _customers[i] = value;
        }

        public Customer this[string email]
        {
            get
            {
                foreach (Customer c in _customers)
                {
                    if (c.EmailAddress == email)
                        return c;
                }

                return null;
            }
        }





        #endregion

        #region methods

        public void Add(Customer customer) => _customers.Add(customer);

        public void Add(int customerId, string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            Customer c = new Customer(customerId, firstName, lastName, emailAddress, phoneNumber);
            _customers.Add(c);
        }

        public void Fill() => _customers = CustomerDb.GetCustomers();
        
        public void Save() => CustomerDb.SaveCustomers(_customers);

        public void Remove(Customer customer) => _customers.Remove(customer);

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

        public static CustomerList operator +(CustomerList cl, Customer c)
        {
            cl.Add(c);
            return cl;
        }

        public static CustomerList operator -(CustomerList cl, Customer c)
        {
            cl.Remove(c);
            return (cl);
        }

        public static CustomerList operator -(CustomerList cl, int count)
        {
            for (int i = 0; i < count; i++)
            {
             cl._customers.RemoveAt(0);   
            }
            return cl;
        }

        #endregion
        
        #region Interfaces   

        public IEnumerator<Customer> GetEnumerator()
        {
            foreach (Customer c in _customers)
            {
                yield return c;
            }
        }
        

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

    }
}