using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserServices
    {
        public static List<UserDTO> GetUsers()
        {
            var data = DataAccessFactory.UserDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
            var mapper = new Mapper(config);
            var rtdata = mapper.Map<List<UserDTO>>(data);
            return rtdata;
        }
        public static UserDTO Get(string username)
        {
            var data = DataAccessFactory.UserDataAccess().Get(username);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
            var mapper = new Mapper(config);
            var rtdata = mapper.Map<UserDTO>(data);

            return rtdata;
        }
        public static UserDTO Add(UserDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
            });

            var mapper = new Mapper(config);
            var User = mapper.Map<User>(obj);
            var rtUser = DataAccessFactory.UserDataAccess().Add(User);

            return mapper.Map<UserDTO>(rtUser);
        }
        public static bool Update(UserDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, User>();
            });

            var mapper = new Mapper(config);
            var User = mapper.Map<User>(obj);
            return DataAccessFactory.UserDataAccess().Update(User);
        }
        public static bool Delete(int id)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(config);

            return DataAccessFactory.UserDataAccess().Delete(id);
        }
    }
}
