using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.DAL.Models
{
    public class TestDB
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
    }
}
