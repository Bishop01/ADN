using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_03.Models
{
    public class User
    {
        [Required, StringLength(50, MinimumLength = 3)]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string contact { get; set; }
        [Required]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$")]
        public string password { get; set; }
        [Required, Compare("password")]
        public string cpassword { get; set; }
    }
}