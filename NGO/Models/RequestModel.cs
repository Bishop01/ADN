using NGO.DBContext;
using System;

namespace NGO.Models
{
    public class RequestModel
    {
        public int id { get; set; }
        public int restaurantId { get; set; }
        public Nullable<int> employeeId { get; set; }
        public string maxTime { get; set; }
        public string status { get; set; }
        public string details { get; set; }

        public EmployeeModel employee { get; set; }
        public RestaurantModel restaurant { get; set; }
    }
}