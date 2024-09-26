using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.ProductDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public ProductsController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ProductList()
		{
			var productList = _productService.TGetList();
			var result = _mapper.Map<List<ResultProductDto>>(productList);
			return Ok(result);
		}


		[HttpGet("ProductCountByHamburger")]
		public IActionResult ProductCountByHamburger()
		{
			return Ok(_productService.TProductCountByCategoryNameHamburger());
		}


		[HttpGet("ProductCountByDrink")]
		public IActionResult ProductCountByDrink()
		{
			return Ok(_productService.TProductCountByCategoryNameDrink());
		}

		[HttpGet("ProductCount")]

		public IActionResult ProductCount()
		{
			return Ok(_productService.TProductCount());
		}

		[HttpGet("ProductPriceAvg")]

		public IActionResult ProductPriceAvg()
		{
			return Ok(_productService.TProductPriceAvg());
		}

		[HttpGet("ProductNameByMaxPrice")]

		public IActionResult ProductNameByMaxPrice()
		{
			return Ok(_productService.TProductNameByMaxPrice());
		}

		[HttpGet("ProductNameByMinPrice")]

		public IActionResult ProductNameByMinPrice()
		{
			return Ok(_productService.TProductNameByMinPrice());
		}


		[HttpPost]
		public IActionResult CreateProduct(CreateProductDto createProductDto)
		{
			var productEntity = _mapper.Map<Product>(createProductDto);
			//productEntity.CategoryId = createProductDto.CategoryId;
			_productService.TAdd(productEntity);
			return Ok("Ürün eklendi.");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteProduct(int id)
		{
			var productEntity = _productService.TGetById(id);
			if (productEntity == null)
				return NotFound("Ürün bulunamadı.");

			_productService.TDelete(productEntity);
			return Ok("Ürün silindi.");
		}

		[HttpPut]
		public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
		{
			var productEntity = _mapper.Map<Product>(updateProductDto);
			_productService.TUpdate(productEntity);
			return Ok("Ürün güncellendi.");
		}

		[HttpGet("GetById")]
		public IActionResult GetProduct(int id)
		{
			var productEntity = _productService.TGetById(id);
			if (productEntity == null)
				return NotFound("Ürün bulunamadı.");

			var result = _mapper.Map<GetProductDto>(productEntity);
			return Ok(result);
		}

		[HttpGet("ProductListWithCategory")]

		public IActionResult ProductListWithCategory()
		{
			var result = _mapper.Map<List<ResultProductWithCategoryDto>>(_productService.TGetProductsWithCategories());
			return Ok(result);
		}
	}
}
