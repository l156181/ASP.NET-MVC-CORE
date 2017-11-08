using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace casa_do_codigo.Models
{
    public class DataService : IDataService
    {
         

        private readonly Context _context;

        public DataService (Context Context)
        {
            this._context = Context;
        }
        public void InitDB(){
            // banco criado
            this._context.Database.EnsureCreated();
        
            if(this._context.Products.Count() == 0) {
               foreach (var product in this.GenerateProducts(12)){
                    this._context.Products.Add(product);
                    this._context.Orders.Add (new Order(product,1));
                    this._context.SaveChanges();
               } 
            }      
        }
        private ICollection<Product> GenerateProducts(int productsNumber){
            List<Product> products = new List<Product>();

            for(int i = 1; i <  productsNumber; i++){
                Product p = new Product ("Product " + i, 10.90m * i);
                products.Add(p);    
            } 

            return products; 
        }
    }
}