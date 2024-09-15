using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IGenericDal<Product>
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }
    }
}
