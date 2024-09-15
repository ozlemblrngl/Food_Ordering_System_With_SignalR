using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, IGenericDal<Category>
    {
        public EfCategoryDal(SignalRContext context) : base(context)
        {
        }
    }
}
