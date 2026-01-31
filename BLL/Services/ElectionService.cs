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
    public class ElectionService
    {
        private static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Election,ElectionDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        //CRUD

        public static List<ElectionDTO> Get() 
        { 
            var data = DataAccessFactory.ElectionData().Read();
            return GetMapper().Map<List<ElectionDTO>>(data);
        }

        public static ElectionDTO Get(int Id)
        {
            var data = DataAccessFactory.ElectionData().Read(Id);
            return GetMapper().Map<ElectionDTO>(data);
        }

        public static bool Create(ElectionDTO election)
        {
            var entity = GetMapper().Map<Election>(election);
            return DataAccessFactory.ElectionData().Create(entity);
        }

        public static bool Update(ElectionDTO election)
        {
            var entity = GetMapper().Map<Election>(election);
            return DataAccessFactory.ElectionData().Update(entity);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.ElectionData().Delete(id);
        }

        //Feature

        public static List<ElectionDTO> ActiveElections() 
        {
            var data = DataAccessFactory.ElectionData().ActiveElections();
            return GetMapper().Map<List<ElectionDTO>>(data);
        }

        public static bool EndElection(int id)
        {
            return DataAccessFactory.ElectionData().EndElection(id);
        }

        public static ElectionDTO ElectionWithCandidates(int id)
        {
            var data = DataAccessFactory.ElectionData().ElectionWithCandidates(id);
            return GetMapper().Map<ElectionDTO>(data);
        }

        public static List<ElectionDTO> SearchElection(string title)
        {
            var data = DataAccessFactory.ElectionData().SearchElection(title);
            return GetMapper().Map<List<ElectionDTO>>(data);
        }
    }
}
