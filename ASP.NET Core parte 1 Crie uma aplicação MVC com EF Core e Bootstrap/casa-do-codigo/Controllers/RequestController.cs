using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace casa_do_codigo.Controllers
{
    public class RequestController : Controller
    {
        public IActionResult Carousel()
        {
            return View();
        }

        public IActionResult ShoppingBag(){
            return View();
        }

        public IActionResult Summary(){
            return View();
        } 
    } 
}
