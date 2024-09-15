﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IGenericDal<Booking>
    {
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }
    }
}
