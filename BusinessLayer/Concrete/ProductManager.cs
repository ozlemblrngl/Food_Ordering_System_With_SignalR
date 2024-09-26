using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;

namespace BusinessLayer.Concrete
{
	public class ProductManager : IProductService
	{
		private readonly IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public int TProductCountByCategoryNameDrink()
		{
			return _productDal.ProductCountByCategoryNameDrink();
		}

		public int TProductCountByCategoryNameHamburger()
		{
			return _productDal.ProductCountByCategoryNameHamburger();
		}

		public void TAdd(Product entity)
		{
			_productDal.Add(entity);
		}

		public void TDelete(Product entity)
		{
			_productDal.Delete(entity);
		}

		public Product TGetById(int id)
		{
			return _productDal.GetById(id);
		}

		public List<Product> TGetList()
		{
			return _productDal.GetList();
		}

		public List<Product> TGetProductsWithCategories()
		{
			return _productDal.GetProductsWithCategories();
		}

		public int TProductCount()
		{
			return _productDal.ProductCount();
		}

		public void TUpdate(Product entity)
		{
			_productDal.Update(entity);
		}

		public decimal TProductPriceAvg()
		{
			return _productDal.ProductPriceAvg();
		}
	}
}
