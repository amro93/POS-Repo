using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace POS.DAL.Models
{
    public enum Role { SuperAdmin, Admin, User }
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Magic { get; set; }
        [DefaultValue(Role.User)]
        public Role Role { get; set; }
        public string PhotoUrl { get; set; }
        public virtual Person Person { get; set; }
        public virtual List<Order> Orders { get; set; }
        
    }
}
