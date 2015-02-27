using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace demoDay.Models
{
    public class ItemList
    {
        [Key]
        public int Id{ get; set; }
        public string Title{ get; set; }
        public string Observations { get; set; }

    }
}