using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_02.Models
{
    public class Student
    {
        [Required]
        [RegularExpression("^[1-9]{1}[0-9]{1}\\-[0-9]{5}\\-[1-3]{1}$")]
        public string id { get; set; }
        [Required,StringLength(50,MinimumLength = 3)]
        public string name { get; set; }
        [Required]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$")]
        public string password { get; set; }
        [Compare("password")]
        public string cPassword { get; set; }
        [Required]
        //[RegularExpression("asd+@" + "student.aiub.edu" + "$")]
        public string email { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        [Age(minAge = 18)]
        public DateTime dob { get; set; }
    }
}