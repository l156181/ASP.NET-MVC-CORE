using System;
using System.Collections.Generic;

namespace entity_frawework_core_1.Model
{
    public partial class Customer
    {
        public byte CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool? Active { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
