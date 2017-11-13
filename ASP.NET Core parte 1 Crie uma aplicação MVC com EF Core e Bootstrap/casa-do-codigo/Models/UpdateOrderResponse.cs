using System;
using casa_do_codigo.Models.ViewModels;

namespace casa_do_codigo.Models
{
    public class UpdateOrderResponse
    {
        public Order Order{get; private set;}
        public ShoppingCartViewModel ShoppingCartViewModel { get; private set; }

        public UpdateOrderResponse(ShoppingCartViewModel shoppingCartViewModel, Order order )
        {
            this.Order = order;
            this.ShoppingCartViewModel = shoppingCartViewModel;
        }
    }
}