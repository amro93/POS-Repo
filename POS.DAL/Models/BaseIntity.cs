using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.DAL.Models
{
    public abstract class BaseIntity
    {
        [Key]
        public int Id { get; set; }
        //public int Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifyDate { get; set; }

        public BaseIntity()
        {
            CreationDate = DateTime.Now;
        }
    }
}
