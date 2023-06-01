using System.Collections.Generic;

namespace CustomerProductClasses
{
    public class ProductList
    {
        private List<Product> _products;

        #region Constructors
        public ProductList()
        {
            _products = new List<Product>();
        }
        
        #endregion

        #region Properties
        public int Count
        {
            get
            {
                return _products.Count;
            }
        }
        
        public Product this[int i]
        {
            get
            {
                return _products[i];
            }
            set
            {
                _products[i] = value;
            }
        }
        
        public decimal ShippingCharge
        {
            get
            {
                decimal total = 0;
                foreach (Product p in _products)
                    // this won't work unless ALL classes implement shippingcharge
                    total += p.ShippingCharge;

                return total;

            }
        }

        public Product this[string code]
        {
            get
            {
                foreach (Product p in _products)
                {
                    if (p.Code == code)
                        return p;
                }
                return null;
            }
        }

        

        #endregion

        #region  Methods
        
        public void Fill()
        {
            _products = ProductDb.GetProducts();
        }

        public void Save()
        {
            ProductDb.SaveProducts(_products);
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        // public void Add(int id, string code, string description, decimal price, int quantity)
        // {
        //     Product p = new Product(id, code, description, price, quantity);
        //     _products.Add(p);
        // }

        public void Remove(Product product)
        {
            _products.Remove(product);
        }

        public override string ToString()
        {
            string output = "";
            foreach (Product p in _products)
            {
                output += p.ToString() + "\n";
            }
            return output;
        }

        public static ProductList operator +(ProductList pl, Product p)
        {
            pl.Add(p);
            return pl;
        }

        public static ProductList operator -(ProductList pl, Product p)
        {
            pl.Remove(p);
            return pl;
        }
        
        public static ProductList operator -(ProductList pl, int count)
        {
            for (int i = 0; i <= count; i++)
            {
                pl._products.RemoveAt(0);
            }
            return pl;
        }
        
        #endregion
    }
}