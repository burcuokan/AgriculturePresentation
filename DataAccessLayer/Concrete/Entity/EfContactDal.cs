﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.Entity
{
   public class EfContactDal : GenericRepository<Contact>, IContactDal
    {
    }
}
