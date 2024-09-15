using BusinessLayer.Abstract;
using DtoLayer.ProductDto;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;


        public ProductsController(IProductService productService)
        {
            _productService = productService;

        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var result = _productService.TGetList();
            return Ok(result);
        }

        [HttpPost]

        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(createProductDto);
            return Ok("Ürün eklendi.");
        }

        [HttpDelete]

        public IActionResult DeleteProduct(int id)
        {
            var result = _productService.TGetById(id);
            _productService.TDelete(result);
            return Ok("Ürün silindi.");
        }

        [HttpPut]

        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TUpdate(updateProductDto);
            return Ok("Ürün güncellendi.");
        }

        [HttpGet("GetById")]

        public IActionResult GetProduct(int id)
        {
            var result = _productService.TGetById(id);
            return Ok(result);
        }
    }
}
