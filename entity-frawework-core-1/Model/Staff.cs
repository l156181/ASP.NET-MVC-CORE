using System;
using System.Collections.Generic;

namespace entity_frawework_core_1.Model
{
    public partial class Staff
    {
        public byte StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool? Active { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
