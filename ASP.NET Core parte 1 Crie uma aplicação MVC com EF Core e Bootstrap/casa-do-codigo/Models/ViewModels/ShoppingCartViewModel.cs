using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using casa_do_codigo.Models;

namespace casa_do_codigo.Models.ViewModels
{
    public class ShoppingCartViewModel {
        public List<Order> Itens { get; private set;}
        public decimal Total { 
            get{
                return Itens.Sum(i => i.SubTotal);
            } 
        }

        public ShoppingCartViewModel(List<Order> itens){
            this.Itens = itens;
        }
    }
}
