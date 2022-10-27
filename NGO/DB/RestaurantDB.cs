using NGO.DBContext;
using NGO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGO.DB
{
    public class RestaurantDB
    {
        public static NGOEntities db = new NGOEntities();
        public static List<RestaurantModel> All()
        {
            var r = db.Restaurants.ToList();

            List<RestaurantModel> restaurants = new List<RestaurantModel>();

            foreach(var r1 in r)
            {
                RestaurantModel restaurant = new RestaurantModel()
                {
                    id = r1.id,
                    name = r1.name,
                    location = r1.location,
                };
                restaurants.Add(restaurant);
            }

            return restaurants;
        }
    }
}