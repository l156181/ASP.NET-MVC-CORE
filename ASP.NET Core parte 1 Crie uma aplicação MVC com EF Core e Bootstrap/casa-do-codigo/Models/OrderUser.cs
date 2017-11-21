using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;


namespace casa_do_codigo.Models
{
    public class OrderUser : BaseModel
    {
        public List<Order> Orders  { get;  set; }
        
        [Required(ErrorMessage = "Name is a field required")]
        [StringLength(50,MinimumLength = 5,ErrorMessage = "Name must have between 5 to 50 characters")]
        public String Name { get;  set; }
        
        [Required]
        public String PhoneNumber  { get;  set; }        
        
        [Required]
        public String Address { get;  set; }
        
        [Required]
        public String Email { get;  set; }
        public String Complement { get;  set; }

        public String Neighborhood { get;  set; }
        public String City { get;  set; }
        public String UF { get;  set; }
        public String ZipCode { get;  set; }

        public OrderUser()
        {
            this.Orders = new List<Order>();
            this.Name = "Alura";
            this.Email = "Alura@gmail.com";
            this.Address = "José street";
            this.Neighborhood = "Vila Mariana";
            this.City = "São Paulo";
        }

        public void UpdateOrderUser(OrderUser orderUser, bool shouldUpdate){
           if(shouldUpdate){
                this.Name = orderUser.Name;
                this.Email = orderUser.Email;
                this.Address = orderUser.Address;
                this.Neighborhood  = orderUser.Neighborhood;
                this.City = orderUser.City;
           } 
        }
    }   
}