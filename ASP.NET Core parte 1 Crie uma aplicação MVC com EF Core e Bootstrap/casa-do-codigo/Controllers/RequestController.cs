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
        private List<Product> Products;

        public ShoppingCartViewModel shoppingCartViewModel {get; set;}

        private int NumberProducts;

        public RequestController() : base() {
            this.Products = new List<Product>();
            this.NumberProducts = 12;
            GenerateData();
        }

        public IActionResult Carousel()
        {
            List<Product> Products = new List<Product>();
            var NumberProducts = 12;
            
            for(int i = 1; i < NumberProducts; i++){
                Product p = new Product (i,"Product " + i, 10.90m * i);
                Products.Add(p);    
            }                

            return View(Products);
        }

        public IActionResult ShoppingBag(){
            return View(this.shoppingCartViewModel);
        }

        public IActionResult Summary(){
            return View(this.shoppingCartViewModel);
        } 

        private void GenerateData(){
            List<Order> Orders = new List<Order>();

            for(int i = 1; i < this.NumberProducts; i++){
                Product p = new Product (i,"Product " + i, 10.90m * i);
                this.Products.Add(p);    
            } 

            for(int i = 0; i < 3; i++){
                Orders.Add(new Order(i + 1,Products[i], i));
            }               

            this.shoppingCartViewModel = new ShoppingCartViewModel(Orders);
        }
    } 
}
