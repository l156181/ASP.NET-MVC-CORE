using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace casa_do_codigo.Models
{   
    public class Product : BaseModel
    {      
        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public decimal  Price { get; private set; }
        [DataMember]
        public List<Order> Orders {get; set;} = new List<Order>();
        
        public Product(){}

        public Product(int Id, string name, decimal price) : this(name,price)
        {
            this.Id = Id;
        }

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
