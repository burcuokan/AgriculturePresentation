using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.Entity
{
    public class EfAnnouncementDal : GenericRepository<Announcement>, IAnnouncementsDal
    {
        public void AnnouncementStatusToFalse(int id)
        {
            using (var context = new AgricultureContext())
            {
                Announcement p = context.Announcements.Find(id);
                p.Status = false;
                context.SaveChanges();
            }
        }

        public void AnnouncementStatusToTrue(int id)
        {
            using (var context = new AgricultureContext())
            {
                Announcement p = context.Announcements.Find(id);
                p.Status = true;
                context.SaveChanges();
            }
        }
    }
}
