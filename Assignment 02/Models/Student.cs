using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_02.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Field cannot be empty")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        [RegularExpression("^[A-Za-z. -]+$",ErrorMessage = "Name can only contain alphabets and dots,spaces,dashes")]
        public string studentName { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [RegularExpression("^[1-9]{1}[0-9]{1}\\-[0-9]{5}\\-[1-3]{1}$",ErrorMessage = "Id must be of xx-xxxxx-x format")]
        public string id { get; set; }
        
        [Required(ErrorMessage = "Field cannot be empty")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$",ErrorMessage = "Password must contain 1uppercase, 1lowercase, 1number and 1special character")]
        public string password { get; set; }

        [Compare("password",ErrorMessage = "Password and Confirm Password must match")]
        public string cPassword { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        //[RegularExpression("asd+@" + "student.aiub.edu" + "$")]
        public string email { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        public string gender { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        [Age(minAge = 18)]
        public DateTime dob { get; set; }
    }
}