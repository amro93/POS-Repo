using System;
using System.Collections.Generic;
using System.Text;

namespace POS.DAL.Models
{

    public class Location : BaseEntity
    {
        public string Address { get; set; }
        public string Notes { get; set; }
        
    }
}
