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
    public class DonorServices
    {
        public static List<DonorDTO> GetDonors()
        {
            var data = DataAccessFactory.DonorDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Donor, DonorDTO>());
            var mapper = new Mapper(config);
            var rtdata = mapper.Map<List<DonorDTO>>(data);
            return rtdata;
        }
        public static DonorDTO Get(int id)
        {
            var data = DataAccessFactory.DonorDataAccess().Get(id);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Donor, DonorDTO>());
            var mapper = new Mapper(config);
            var rtdata = mapper.Map<DonorDTO>(data);

            return rtdata;
        }
        public static DonorDTO Add(DonorDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Donor, DonorDTO>();
                cfg.CreateMap<DonorDTO, Donor>();
            });

            var mapper = new Mapper(config);
            var Donor = mapper.Map<Donor>(obj);
            var rtDonor = DataAccessFactory.DonorDataAccess().Add(Donor);

            return mapper.Map<DonorDTO>(rtDonor);
        }
        public static bool Update(DonorDTO obj)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DonorDTO, Donor>();
            });

            var mapper = new Mapper(config);
            var Donor = mapper.Map<Donor>(obj);
            return DataAccessFactory.DonorDataAccess().Update(Donor);
        }
        public static bool Delete(int id)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DonorDTO, Donor>();
            });
            var mapper = new Mapper(config);

            return DataAccessFactory.DonorDataAccess().Delete(id);
        }
    }
}
