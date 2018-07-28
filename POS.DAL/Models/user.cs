using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.Models
{
    public enum UserRole { SuperAdmin,Admin, User }
    public class User : BaseIntity
    {
        public string UserName { get; set; }
        public string Magic { get; set; }
        public UserRole Role { get; set; }
        public string PhotoUrl { get; set; }

    }
}
