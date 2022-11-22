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
    public class GroupServices
    {
        public static List<GroupDTO> GetGroups()
        {
            var data = DataAccessFactory.GroupDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Group, GroupDTO>());
            var mapper = new Mapper(config);
            var rtdata = mapper.Map<List<GroupDTO>>(data);
            return rtdata;
        }
        public static GroupDTO Get(int id)
        {
            var data = DataAccessFactory.GroupDataAccess().Get(id);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Group, GroupDTO>());
            var mapper = new Mapper(config);
            var rtdata = mapper.Map<GroupDTO>(data);

            return rtdata;
        }
        public static GroupDTO Add(GroupDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Group, GroupDTO>();
                cfg.CreateMap<GroupDTO, Group>();
                });

            var mapper = new Mapper(config);
            var group = mapper.Map<Group>(obj);
            var rtgroup = DataAccessFactory.GroupDataAccess().Add(group);

            return mapper.Map<GroupDTO>(rtgroup);
        }
        public static bool Update(GroupDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<GroupDTO, Group>();
                });

            var mapper = new Mapper(config);
            var group = mapper.Map<Group>(obj);
            return DataAccessFactory.GroupDataAccess().Update(group);
        }
        public static bool Delete(int id)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<GroupDTO, Group>();
            });
            var mapper = new Mapper(config);

            return DataAccessFactory.GroupDataAccess().Delete(id);
        }
    }
}
