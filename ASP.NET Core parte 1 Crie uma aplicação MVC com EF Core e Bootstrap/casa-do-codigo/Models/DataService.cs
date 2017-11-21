using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using casa_do_codigo.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace casa_do_codigo.Models
{
    public class DataService : IDataService
    {
        private readonly Context _context;
        private readonly IHttpContextAccessor _contextAcessor;

        public DataService (Context Context, IHttpContextAccessor contextAcessor)
        {
            this._contextAcessor = contextAcessor;
            this._context = Context;
        }
        public void InitDB()
        {           
            this._context.Database.EnsureCreated();
        
            if(this._context.Products.Count() == 0) {
               foreach (var product in this.GenerateProducts(9)){
                    this._context.Products.Add(product);
                    //this._context.Orders.Add (new Order(product,1));
               } 
            }      

            if(this._context.OrdersUsers.Count() == 0){
                this._context.OrdersUsers.Add(new OrderUser());
            }

            this._context.SaveChanges();
        }

        public List<Product> GetProducts()
        {
            return this._context.Products.ToList();
        }

        public List<Order> GetOrders()
        {
           GetProducts(); 
           List<Order> orders = new List<Order>(); 
           OrderUser orderUser = null;

           try
           {
                var ordersUsersId = GetSessionOrderUserId();
                orderUser = this._context.OrdersUsers.Where(or => or.Id == ordersUsersId).SingleOrDefault();
                orders = this._context.Orders.Where(i => i.OrderUser.Id == orderUser.Id).ToList();    
                
           }catch(NullReferenceException e)
           {
               Console.WriteLine("orderUsers or orderUsersid have null value");
               orders =  new List<Order>();
           } 

           return orders; 
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
 
            if(orderDb != null)
            {
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

        private  int? GetSessionOrderUserId(){
//            var keySession  = ;
            int? sessionId = this._contextAcessor.HttpContext.Session.GetInt32("orderUserId");
            
            if(sessionId == null){
                Console.WriteLine("SESSION NOT EXISTS. It will be created");
                SetSessionOrderUserId();
                sessionId = this._contextAcessor.HttpContext.Session.GetInt32("orderUserId");
            }

            return  sessionId;
        }

        private OrderUser SetSessionOrderUserId(){
            OrderUser orderUser = new OrderUser();
            this._context.OrdersUsers.Add(orderUser);
            orderUser = this._context.OrdersUsers.LastOrDefault();
            this._contextAcessor.HttpContext.Session.SetInt32("orderUserId",orderUser.Id);
            this._context.SaveChanges();

            return orderUser;
        }

        void IDataService.AddOrder(int produtoId)
        {    
//          var orderUser =  this._context.OrdersUsers.FirstOrDefault();
            OrderUser orderUser;
            var ordersUsersId = GetSessionOrderUserId();            

            orderUser = this._context.OrdersUsers.Where(or => or.Id == ordersUsersId).SingleOrDefault();    
            var product = this._context.Products.Where(p => p.Id == produtoId).SingleOrDefault();
            
            if(!this._context.Orders.Where(o => o.Product.Id == product.Id && o.OrderUser.Id == orderUser.Id).Any()){
                this._context.Orders.Add(new Order(orderUser,product,1));
            }else{
                var order = this._context.Orders.Where(o => o.Product.Id == produtoId  && o.OrderUser.Id == orderUser.Id).SingleOrDefault();
                order.Quantity = order.Quantity + 1;
            }

            this._context.SaveChanges();
        }

        OrderUser IDataService.GetOrderUser(){

             int? orderUserId = GetSessionOrderUserId();
             return this._context.OrdersUsers
                        .Include(ou => ou.Orders)
                        .ThenInclude(o => o.Product)
                        .Where(ou => ou.Id == orderUserId).SingleOrDefault();
         }

         OrderUser IDataService.UpdateOrderUser(OrderUser orderUser){
                orderUser = (this as IDataService).GetOrderUser();
                orderUser.UpdateOrderUser(orderUser,false);
                this._context.SaveChanges();
                return orderUser;
         }     
    }
}