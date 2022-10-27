using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGO.Models
{
    public class EmployeeModel
    {
        public Nullable<int> id { get; set; }
        public string name { get; set; }
        public string contact { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int role { get; set; }
        public virtual ICollection<RequestModel> Requests { get; set; }
    }
}