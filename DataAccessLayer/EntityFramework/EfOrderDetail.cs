using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
	public class EfOrderDetail : GenericRepository<OrderDetail>, IGenericDal<OrderDetail>, IOrderDetailDal
	{
		public EfOrderDetail(SignalRContext context) : base(context)
		{
		}
	}
}
