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

        #region constructors   
        
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
        #endregion

        #region properties

        

        
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
        
        #endregion

        #region methods
        
        //methods
        
        public override string ToString()
        {
            return $"ID: {Id}, Name: {FirstName}, Last Name: {LastName}, Email: {EmailAddress}, Phone Number: {PhoneNumber}";
        }

        public override bool Equals(object obj)
        {
           if (obj == null || this.GetType() != obj.GetType())
                return false;
           else
           {
               Customer c = (Customer)obj;
               return (this.Id == c.Id
                       && this.FirstName == c.FirstName
                       && this.LastName == c.LastName
                       && this.EmailAddress == c.EmailAddress
                       && this.PhoneNumber == c.PhoneNumber);
           }
        }
        
        public override int GetHashCode()
        {
            return 13 + 7 * id.GetHashCode() +
                7 * fName.GetHashCode() +
                7 * lName.GetHashCode() +
                7 * email.GetHashCode() +
                7 * phone.GetHashCode();
        }
        
        public static bool operator ==(Customer c1, Customer c2)
        {
            return c1.Equals(c2);
        }
        
        public static bool operator !=(Customer c1, Customer c2)
        {
            return !c1.Equals(c2);
        }

        #endregion

    }
}
