using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace casa_do_codigo.Models
{
    public interface IDataService
    {         
         // Methods        
         void InitDB();

         List<Product> GetProducts();

         List<Order> GetOrders();

         UpdateOrderResponse updateOrder(Order order);

         void AddOrder(int produtoId);
    }
}