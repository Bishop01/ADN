using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_03.Models
{
    public class Product
    {
        [Required]
        public string name { get; set; }
        [Required]
        public int price { get; set; }
    }
}