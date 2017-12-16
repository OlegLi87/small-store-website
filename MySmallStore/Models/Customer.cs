using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySmallStore.Models
{
    public class Customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Passport { get; set; }

        [Required,StringLength(10)]
        public string FirstName { get; set; }

        [Required,StringLength(20)]
        public string LastName { get; set; }

        [Required,DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        [Required]
        public bool Active { get; set; }
    
        public int Age { get { return DateTime.Now.Year - this.BirthDate.Year; } }

        public virtual ICollection<Order> Orders { get; set; }
    }
}