using NGO.DBContext;
using NGO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGO.DB
{
    public class AuthenticationDB
    {
        public static NGOEntities db = new NGOEntities();

        public static Employee VerifyLogin(EmployeeModel employeeModel)
        {
            var employee = (from emp in db.Employees
                            where emp.email == employeeModel.email
                            select emp).FirstOrDefault();

            if (employee != null)
            {
                if (employee.password == employeeModel.password && employee.role == 1)
                {
                    return employee;
                }
            }

            return null;
        }
    }
}