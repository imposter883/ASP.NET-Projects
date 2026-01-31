using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class NotificationRepo : Repo, INotificationRepo
    {
        public bool Create(Notification obj)
        {
            db.Notifications.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int Id)
        {
            var ex = Read(Id);
            db.Notifications.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public bool MarkAsRead(int nId)
        {
            var note = db.Notifications.Find(nId);
            if (note == null) return false;
            note.IsRead = true;
            return db.SaveChanges() > 0;
        }

        public List<Notification> Read()
        {
            return db.Notifications.ToList();
        }

        public Notification Read(int Id)
        {
            return db.Notifications.Find(Id);
        }

        public List<Notification> UnreadNotifications(int vId)
        {
            return db.Notifications.Where(n => n.VoterId == vId && !n.IsRead).ToList();
        }

        public bool Update(Notification obj)
        {
            var ex = Read(obj.NotificationId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public bool VoteNotification(int vId)
        {
            var note = new Notification
            {
                VoterId = vId,
                CreatedAt = DateTime.Now,
                IsRead = false,
            };
            db.Notifications.Add(note);
            return db.SaveChanges() > 0;
        }
    }
}
