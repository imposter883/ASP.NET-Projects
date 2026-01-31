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
    public class CandidateService
    {
        private static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Candidate,CandidateDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        //CURD

        public static List<CandidateDTO> Get()
        {
            var data = DataAccessFactory.CandidateData().Read();
            return GetMapper().Map<List<CandidateDTO>>(data);
        }

        public static CandidateDTO Get(int id)
        {
            var data = DataAccessFactory.CandidateData().Read(id);
            return GetMapper().Map<CandidateDTO>(data);
        } 
        
        public static bool Create(CandidateDTO candidate)
        {
            var entity = GetMapper().Map<Candidate>(candidate);
            return DataAccessFactory.CandidateData().Create(entity);
        }

        public static bool Update(CandidateDTO candidate)
        {
            var entity = GetMapper().Map<Candidate>(candidate);
            return DataAccessFactory.CandidateData().Update(entity);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.CandidateData().Delete(id);
        }

        //Feature

        public static List<CandidateDTO> CandidateByElection(int electionId)
        {
            var data = DataAccessFactory.CandidateData().CandidatesByElection(electionId);
            return GetMapper().Map<List<CandidateDTO>>(data);
        }

        public static List<CandidateDTO>SearchByName(string name)
        {
            var data = DataAccessFactory.CandidateData().SearchByName(name);
            return GetMapper().Map<List<CandidateDTO>>(data);
        }
    }
}
