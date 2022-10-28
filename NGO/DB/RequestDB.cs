using NGO.DBContext;
using NGO.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NGO.DB
{
    public class RequestDB
    {
        public static NGOEntities db = new NGOEntities();
        public static List<RequestModel> All()
        {
            var reqs = db.Requests.ToList();
            List<RequestModel> requests = new List<RequestModel>();
            foreach(var req in reqs)
            {
                RequestModel model = new RequestModel()
                {
                    id = req.id,
                    employeeId = req.employeeId,
                    restaurantId = req.restaurantId,
                    maxTime = req.maxTime,
                    status = req.status,
                    details = req.details,
                    creationDate = req.creationDate,
                    expirationDate = req.expirationDate,
                    completionDate = req.completionDate,
                };

                if (req.Employee != null)
                {
                    model.employee = new EmployeeModel() { id = req.Employee.id, name = req.Employee.name, contact = req.Employee.contact };
                }
                model.restaurant = new RestaurantModel() { id = req.Restaurant.id, name = req.Restaurant.name, location = req.Restaurant.location };
                requests.Add(model);
            }

            return requests;
        }

        public static List<RequestModel> All(int id)
        {
            var reqs = (from request in db.Requests
                        where request.restaurantId == id
                        select request).ToList();

            List<RequestModel> requests = new List<RequestModel>();
            foreach (var req in reqs)
            {
                RequestModel model = new RequestModel()
                {
                    id = req.id,
                    employeeId = req.employeeId,
                    restaurantId = req.restaurantId,
                    maxTime = req.maxTime,
                    status = req.status,
                    details = req.details,
                    employee = null,
                    restaurant = null,
                    creationDate = req.creationDate,
                    expirationDate = req.expirationDate,
                    completionDate = req.completionDate,
                };
                if(req.Employee !=null)
                {
                    model.employee = new EmployeeModel() { id = req.Employee.id, name = req.Employee.name, contact = req.Employee.contact };
                }
                if (req.Restaurant != null)
                {
                    model.restaurant = new RestaurantModel() { id = req.Restaurant.id, name = req.Restaurant.name, location = req.Restaurant.location };
                }
                //RequestModel model = new RequestModel();
                //model.id = req.id;
                //model.details = req.details;
                //model.status = req.status;
                //model.employeeId = req.employeeId;
                //model.restaurantId = req.restaurantId;
                //model.employee = new EmployeeModel() { id = req.Employee.id, contact=req.Employee.contact, name=req.Employee.name };
                requests.Add(model);
            }

            return requests;
        }

        public static int Add(RequestModel request)
        {
            try
            {
                Request r = new Request()
                {
                    restaurantId = request.restaurantId,
                    maxTime = request.maxTime,
                    creationDate = DateTime.Now,
                    expirationDate = DateTime.Now,
                };

                r.expirationDate = r.creationDate.AddDays(r.maxTime);

                if (request.details != String.Empty)
                 r.details = request.details;


                db.Requests.Add(r);
                db.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public static int Update(RequestModel requestModel)
        {
            var request = db.Requests.Find(requestModel.id);

            if (request == null)
                return 0;

            request.employeeId = requestModel.employeeId;
            db.SaveChanges();

            return 1;
        }
        public static int Update(int requestId, string status)
        {
            var request = db.Requests.Find(requestId);
            if(request == null)
            {
                return 0;
            }

            request.status = status;
            request.completionDate = DateTime.Now;
            db.SaveChanges();
            return 1;
        }
        public static int Delete(int requestId, string status)
        {
            var request = db.Requests.Find(requestId);
            if (request == null)
            {
                return 0;
            }

            request.status = status;
            db.SaveChanges();
            return 1;
        }
    }
}