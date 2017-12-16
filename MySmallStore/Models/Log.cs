using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MySmallStore.Models
{
    public class Log
    {
        [Key]
        public int LogID { get; set; }

        [StringLength(50)]
        public string LogText { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LogDateTime { get; set; }
    }
}