using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface INotificationRepo : IRepo<Notification,int,bool>
    {
        bool VoteNotification(int vId);
        List<Notification> UnreadNotifications(int vId);
        bool MarkAsRead(int nId);
    }
}

