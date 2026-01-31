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
    public class NotificationService
    {
        private static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Notification,NotificationDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        //CRUD

        public static List<NotificationDTO> Get()
        {
            var data = DataAccessFactory.NotificationData().Read();
            return GetMapper().Map<List<NotificationDTO>>(data);
        }

        public static NotificationDTO Get(int Id)
        {
            var data = DataAccessFactory.NotificationData().Read(Id);
            return GetMapper().Map<NotificationDTO>(data);
        }

        public static bool Create(NotificationDTO notification)
        {
            var entity = GetMapper().Map<Notification>(notification);
            return DataAccessFactory.NotificationData().Create(entity);
        }

        public static bool Update(NotificationDTO notification)
        {
            var entity = GetMapper().Map<Notification>(notification);
            return DataAccessFactory.NotificationData().Update(entity);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.ElectionData().Delete(id);

        }

        //Feature

        public static bool VoteNotification(int voterId)
        {
            return DataAccessFactory.NotificationData().VoteNotification(voterId);
        }

        public static List<NotificationDTO> UnreadNotifications(int voterId) 
        { 
            var data = DataAccessFactory.NotificationData().UnreadNotifications(voterId);
            return GetMapper().Map<List<NotificationDTO>>(data);
        }

        public static bool MarkAsRead(int notificationId)
        {
            return DataAccessFactory.NotificationData().MarkAsRead(notificationId);
        }
    }
}
