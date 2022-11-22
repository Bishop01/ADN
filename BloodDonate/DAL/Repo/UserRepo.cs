using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class UserRepo : IRepo<User, string, User>, IAuth
    {
        BloodDonateEntities db;
        internal UserRepo()
        {
            db = new BloodDonateEntities();
        }
        public User Add(User obj)
        {
            db.Users.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public User Authenticate(string name, string pass)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            db.Users.Remove(db.Users.Find(id));
            db.SaveChanges();
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(string id)
        {
            return db.Users.Find(id);
        }

        public bool Update(User obj)
        {
            var data = db.Users.Find(obj.username);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
