using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace casa_do_codigo.Models
{
    public class Product
    {

        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal  Price { get; private set; }
        
        public Product(){}

        public Product(int Id, string name, decimal price) : this(name,price){
            this.Id = Id;
        }

        public Product(string name, decimal price){
            this.Name = name;
            this.Price = price;
        }
    }
}
