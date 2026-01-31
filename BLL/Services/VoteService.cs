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
    public class VoteService
    {
        private static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Vote,VoteDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        //CRUD

        public static List<VoteDTO> Get()
        {
            var data = DataAccessFactory.VoteData().Read();
            return GetMapper().Map<List<VoteDTO>>(data);
        }

        public static VoteDTO Get(int Id)
        {
            var data = DataAccessFactory.VoteData().Read(Id);
            return GetMapper().Map<VoteDTO>(data);
        }

        public static bool Create(VoteDTO vote)
        {
            var entity = GetMapper().Map<Vote>(vote);
            return DataAccessFactory.VoteData().Create(entity);
        }

        public static bool Update(VoteDTO vote)
        {
            var entity = GetMapper().Map<Vote>(vote);
            return DataAccessFactory.VoteData().Update(entity);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.VoteData().Delete(id);
        }

        //Feature

        public static bool CastVote(int vId, int eId, int cId)
        {
            var successful = DataAccessFactory.VoteData().CastVote(vId, eId, cId);
            if (successful)
            {
                DataAccessFactory.NotificationData().VoteNotification(vId);
            }
            return successful;
        }

        public static Dictionary<string, int> GetResult(int electionId)
        {
            return DataAccessFactory.VoteData().GetResult(electionId);
        }

        public static string Winner(int electionId)
        {
            return DataAccessFactory.VoteData().Winner(electionId);
        }

        public static int TotalVotes(int candidateId)
        {
            return DataAccessFactory.VoteData().TotalVotes(candidateId);
        }

        public static bool HasVoterVoted(int voterId, int electionId) 
        { 
            return DataAccessFactory.VoteData().HasVoterVoted(voterId, electionId);
        }
    }
}
