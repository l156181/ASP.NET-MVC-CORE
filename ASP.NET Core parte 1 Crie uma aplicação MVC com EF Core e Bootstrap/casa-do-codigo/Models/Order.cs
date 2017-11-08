using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace casa_do_codigo.Models
{
    public class Order
    {
        public int Id { get; private set; }

        public Product Product { get; private set; }

        public int Quantity  { get; private set; }

        public decimal UnitPrice { 
            get{
                return Product.Price;
            } 
            private set{} 
        }
       
       public decimal SubTotal { get{
           return Quantity * UnitPrice;
       } }

       public Order (){} 
       public Order(int id,  Product product, int quantity) : this(product,quantity) {
            this.Id = id;
       }

       public Order(Product Product, int Quantity) {
         this.Product = Product;
         this.Quantity = Quantity; 
       }
    
    }
}
