using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_01.Models
{
    public class Education
    {

        public double SSCGPA { get; set; }
        public double HSCGPA { get; set; }
        public double BSCGPA { get; set; }

        public Education(double sSCGPA, double hSCGPA, double bSCGPA)
        {
            SSCGPA = sSCGPA;
            HSCGPA = hSCGPA;
            BSCGPA = bSCGPA;
        }

    }
}