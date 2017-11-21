using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using casa_do_codigo.Models;
using casa_do_codigo.Models.ViewModels;

namespace casa_do_codigo.Controllers
{
    public class RequestController : Controller
    {    
        private readonly IDataService _dataService;

        public RequestController(IDataService dataService) : base() {
            this._dataService = dataService;
        }

        public IActionResult Carousel()
        {
            List<Product> Products = this._dataService.GetProducts();  
            return View(Products);
        }


        public IActionResult ShoppingBag(int? productId){    
            if(!(productId == null))
            {
                   this._dataService.AddOrder(productId.Value);
            }
        
            return View(GetShoppingCart());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Summary(OrderUser register)
        {
            if(ModelState.IsValid)
            {
                var orderUser = this._dataService.UpdateOrderUser(register);
                return View(orderUser);
            }else
            {
                return RedirectToAction("register");
            }
        } 
            
        [HttpPost]
        [ValidateAntiForgeryToken]
        public UpdateOrderResponse PostQuantity([FromBody]Order order){
            return this._dataService.updateOrder(order);
        }

        private ShoppingCartViewModel GetShoppingCart()
        {    
            List<Order> orders = this._dataService.GetOrders();
            return new ShoppingCartViewModel(orders);     
        }

        public IActionResult Register(){
            var orderUser = this._dataService.GetOrderUser();            
            return View(orderUser);
        }
    } 
}
