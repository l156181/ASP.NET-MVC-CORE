using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using casa_do_codigo.Models.ViewModels;


namespace casa_do_codigo.Models
{
    public class DataService : IDataService
    {
        private readonly Context _context;

        public DataService (Context Context)
        {
            this._context = Context;
        }
        public void InitDB()
        {           
            this._context.Database.EnsureCreated();
        
            if(this._context.Products.Count() == 0) {
               foreach (var product in this.GenerateProducts(9)){
                    this._context.Products.Add(product);
                    this._context.Orders.Add (new Order(product,1));
                    this._context.SaveChanges();
               } 
            }      
        }

        public List<Product> GetProducts()
        {
            return this._context.Products.ToList();
        }

        public List<Order> GetOrders()
        {
           GetProducts(); 
           return this._context.Orders.ToList();  
        }

        private ICollection<Product> GenerateProducts(int productsNumber)
        {
            List<Product> products = new List<Product>();

            for(int i = 1; i <  productsNumber; i++)
            {
                Product p = new Product ("Product " + i, 10.90m * i);
                products.Add(p);    
            } 

            return products; 
        }

        public UpdateOrderResponse updateOrder(Order order)
        {
            var orderDb = this._context.Orders.Where(i => i.Id == order.Id).SingleOrDefault();
 
            if(orderDb != null){
                  orderDb.Quantity = order.Quantity; 
                  if(orderDb.Quantity ==0){
                      this._context.Remove(orderDb);
                  }
                  this._context.SaveChanges();            
            }

            var orders = this._context.Orders.ToList();
            var shoppingCartViewModel = new ShoppingCartViewModel(orders);

            return new UpdateOrderResponse(shoppingCartViewModel,order);
        }

        void IDataService.AddOrder(int produtoId)
        {
            try
            {
                var product = this._context.Products.Where(p => p.Id == produtoId).SingleOrDefault();
                if(!this._context.Orders.Where(i => i.Product.Id == product.Id).Any()){
                    this._context.Orders.Add(new Order(product,1));
                    this._context.SaveChanges();
                }else{
                    var order = this._context.Orders.Where(o => o.Product.Id == produtoId).SingleOrDefault();
                    order.Quantity = order.Quantity + 1;
                    this._context.SaveChanges();
                }
            }catch(NullReferenceException e)
            {

            }
        }
    }
}