using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class VoterService
    {
        private static Mapper GetMapper() 
        {
            var config = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Voter,VoterDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        //CURD

        public static List<VoterDTO> Get()
        {
            var data = DataAccessFactory.VoterData().Read();
            return GetMapper().Map<List<VoterDTO>>(data);
        }

        public static VoterDTO Get(int id) 
        {
            var data = DataAccessFactory.VoterData().Read(id);
            return GetMapper().Map<VoterDTO>(data);
        }

        public static bool Create(VoterDTO voter)
        {
            var entity = GetMapper().Map<Voter>(voter);
            return DataAccessFactory.VoterData().Create(entity);
        }

        public static bool Update(VoterDTO voter)
        {
            var entity = GetMapper().Map<Voter>(voter);
            return DataAccessFactory.VoterData().Update(entity);
        }

        public static bool Delete(int id) 
        {
            return DataAccessFactory.VoterData().Delete(id);
        }

        //Feature

        public static List<VoterDTO> SearchByName(string name)
        {
            var data = DataAccessFactory.VoterData().SearchByName(name);
            return GetMapper().Map<List<VoterDTO>>(data);
        }

        public static VoterDTO GetByEmail(string email)
        {
            var data = DataAccessFactory.VoterData().GetByEmail(email);
            return GetMapper().Map<VoterDTO>(data);
        }
    }
}
