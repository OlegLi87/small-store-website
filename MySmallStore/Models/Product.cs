using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace MySmallStore.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required,StringLength(20)]
        public string ProductName { get; set; }

        [Required,DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [StringLength(50)]
        public string Desc { get; set; }

        [Required]
        public bool Active { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}