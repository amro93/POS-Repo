using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.Models
{
    public class Login : BaseEntity
    {
        public virtual User User { get; set; }
        public DateTime Date { get; set; }
    }
}
