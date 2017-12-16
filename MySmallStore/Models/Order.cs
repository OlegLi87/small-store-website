using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace MySmallStore.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public long CustomerPassport { get; set; }

        [Required]
        public int ProductID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }
    }
}