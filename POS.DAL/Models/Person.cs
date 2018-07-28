using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace POS.DAL.Models
{ 
    public enum Gender { Male, Female}

    /// <summary>
    /// This class represents people in the system
    /// </summary>
    public class Person : BaseIntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int? Age { get; set; }

        public Gender? Gender { get; set; }

        public string Notes { get; set; }

        public string Mobile { get; set; }

        public string AlternativePhone { get; set; }

        public string Address { get; set; }
        
        public virtual User User { get; set; }

        public virtual Client Client { get; set; }        
    }
}
