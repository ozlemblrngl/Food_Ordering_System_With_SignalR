using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfAboutDal : GenericRepository<About>, IGenericDal<About>
    {
        public EfAboutDal(SignalRContext context) : base(context)
        {
        }
    }
}
