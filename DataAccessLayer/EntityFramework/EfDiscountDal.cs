using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfDiscountDal : GenericRepository<Discount>, IGenericDal<Discount>
    {
        public EfDiscountDal(SignalRContext context) : base(context)
        {
        }
    }
}
