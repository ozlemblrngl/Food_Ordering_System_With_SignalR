using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfSocialMediaDal : GenericRepository<SocialMedia>, IGenericDal<SocialMedia>
    {
        public EfSocialMediaDal(SignalRContext context) : base(context)
        {
        }
    }
}
