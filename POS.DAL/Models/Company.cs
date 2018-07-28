using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace POS.DAL.Models
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public long Phone_1 { get; set; }
        public long Phone_2 { get; set; }
        public long Phone_3 { get; set; }
        public long Phone_4 { get; set; }
        public string Notes { get; set; }
        public string LogoUrl { get; set; }
        public virtual Location Location { get; set; }

    }
}
