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

        public IActionResult ShoppingBag()
        {
            return View(GetShoppingCart());
        }

        public IActionResult Summary()
        {
            return View(GetShoppingCart());
        } 

        private ShoppingCartViewModel GetShoppingCart()
        {    
            List<Order> orders = this._dataService.GetOrders();
            return new ShoppingCartViewModel(orders);     
        }
    } 
}
