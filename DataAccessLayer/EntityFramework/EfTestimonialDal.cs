using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfTestimonialDal : GenericRepository<Testimonial>, IGenericDal<Testimonial>
    {
        public EfTestimonialDal(SignalRContext context) : base(context)
        {
        }
    }
}
