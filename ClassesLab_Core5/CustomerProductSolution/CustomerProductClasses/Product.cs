using System;

namespace CustomerProductClasses
{
    public class Product
    {
        //instance variables
        //attributes
        private int id;
        private string code;
        private string description;
        private decimal unitPrice;
        private int quantity;

        public Product()
        {
        }

        public Product(int productId, string productCode, string desc, decimal price, int qty)
        {
            id = productId;
            code = productCode;
            description = desc;
            unitPrice = price;
            quantity = qty;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        public int QuantityOnHand
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public override string ToString()
        {
            return String.Format(
                $"Id: {id} Code: {code} Description: {description} UnitPrice: ${unitPrice} Quantity: {quantity}");
        }
    }
}