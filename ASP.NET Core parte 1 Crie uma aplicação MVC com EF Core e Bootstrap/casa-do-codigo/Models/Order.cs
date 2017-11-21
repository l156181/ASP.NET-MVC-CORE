using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace casa_do_codigo.Models
{
    public class Order : BaseModel
    { 

        [DataMember]
        [Required]
        public OrderUser OrderUser { get; private set; }

        [Required]
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
       public Order(int id,OrderUser orderUser,Product product, int quantity) : this(orderUser,product,quantity) {
            this.Id = id;
       }

       public Order(OrderUser orderUser,Product Product, int Quantity) {
         this.OrderUser = orderUser;
         this.Product = Product;
         this.Quantity = Quantity; 
       }
    
    }
}
