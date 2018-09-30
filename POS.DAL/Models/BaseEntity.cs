using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.DAL.Models
{
    public abstract class BaseEntity
    {
        protected ILazyLoader LazyLoader { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public BaseEntity()
        {
            CreationDate = DateTime.Now;
            ModifyDate = DateTime.Now;
        }
        public BaseEntity(ILazyLoader lazyLoader) : this()
        {
            LazyLoader = lazyLoader;
        }

    }
}
