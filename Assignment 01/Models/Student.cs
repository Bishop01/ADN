using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Assignment_01.Models
{
    public class Student
    {
        public string id { get; set; }
        public string name { get; set; }
        public Education education { get; set; }
        public double cgpa { get; set; }
        public string contact { get; set; }

        public Student(string id, string name, Education education, double cGPA, string contact)
        {
            this.id = id;
            this.name = name;
            this.education = education;
            cgpa = cGPA;
            this.contact = contact;
        }
    }
}