using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Assignment_02.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class AgeAttribute:ValidationAttribute
    {
        public int minAge { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult(ErrorMessage ?? "Value cannot be empty");

            DateTime bday = ((DateTime)value);
            DateTime currentDay = DateTime.Parse("1-1-2022");
            TimeSpan age = currentDay - bday;

            double ageInDays = age.TotalDays;
            double daysInYear = 365.2425;
            double ageInYears = ageInDays / daysInYear;

            if (ageInYears < minAge)
                return new ValidationResult(ErrorMessage ?? "Age must be greater than " + minAge);

            return ValidationResult.Success;
        }
    }
}