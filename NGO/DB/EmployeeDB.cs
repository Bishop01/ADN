using NGO.DBContext;
using NGO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGO.DB
{
    public class EmployeeDB
    {
        public static NGOEntities db = new NGOEntities();

        public static List<EmployeeModel> All()
        {
            var emps = db.Employees.ToList();
            List<EmployeeModel> employees = new List<EmployeeModel>();

            foreach(var emp in emps)
            {
                EmployeeModel employee = new EmployeeModel()
                {
                    id = emp.id,
                    name = emp.name,
                    contact = emp.contact,
                    email = emp.email,
                    password = emp.password,
                    role = emp.role,
                };

                employees.Add(employee);
            }
            return employees;
        }
    }
}