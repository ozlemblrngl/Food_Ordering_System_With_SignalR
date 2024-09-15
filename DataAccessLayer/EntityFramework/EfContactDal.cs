using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfContactDal : GenericRepository<Contact>, IGenericDal<Contact>
    {
        public EfContactDal(SignalRContext context) : base(context)
        {
        }
    }
}
