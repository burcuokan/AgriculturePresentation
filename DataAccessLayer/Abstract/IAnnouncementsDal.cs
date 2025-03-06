using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
   public interface IAnnouncementsDal : IGenericDal<Announcement>
    {
        void AnnouncementStatusToTrue(int id); //Duyuru aktif yap metodu
        void AnnouncementStatusToFalse(int id); //Duyuru pasif yap metodu
    }
}
