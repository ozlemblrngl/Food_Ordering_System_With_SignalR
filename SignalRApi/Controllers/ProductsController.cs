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

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var productEntity = _mapper.Map<Product>(createProductDto);
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
    }
}
