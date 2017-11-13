using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace casa_do_codigo.Models
{
    public class Order : BaseModel
    { 
        [DataMember]
        public Product Product { get; set; }

        [DataMember]
        public int Quantity  { get;  set;}

        [DataMember]
        public decimal UnitPrice { 
            get{
                return (Product != null)? Product.Price : 0;
            } 
            private set{} 
        }
       
       [DataMember]
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
