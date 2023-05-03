using System;

namespace CustomerProductClasses
{
    public class Customer
    {
        //instance variables
        private int id;
        private string fName;
        private string lName;
        private string email;
        private string phone;
        
        //constructors
        public Customer()
        {
        }

        public Customer(int customerId, string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            id = customerId;
            fName = firstName;
            lName = lastName;
            email = emailAddress;
            phone = phoneNumber;
        }
        
        //properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public string FirstName
        {
            get { return fName; }
            set { fName = value; }
        }
        
        public string LastName
        {
            get { return lName; }
            set { lName = value; }
        }
        
        public string EmailAddress
        {
            get { return email; }
            set { email = value; }
        }
        
        public string PhoneNumber
        {
            get { return phone; }
            set { phone = value; }
        }

        //methods
        
        public override string ToString()
        {
            return $"ID: {Id}, Name: {FirstName}, Last Name: {LastName}, Email: {EmailAddress}, Phone Number: {PhoneNumber}";
        }

    }
}
