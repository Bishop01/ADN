using NGO.DBContext;
using System;

namespace NGO.Models
{
    public class RequestModel
    {
        public int id { get; set; }
        public int restaurantId { get; set; }
        public Nullable<int> employeeId { get; set; }
        public int maxTime { get; set; }
        public string status { get; set; }
        public string details { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime expirationDate { get; set; }
        public Nullable<DateTime> completionDate { get; set; }

        public EmployeeModel employee { get; set; }
        public RestaurantModel restaurant { get; set; }
    }
}