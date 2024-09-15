using BusinessLayer.Abstract;
using DtoLayer.CategoryDto;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var result = _categoryService.TGetList();
            return Ok(result);
        }

        [HttpPost]

        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryService.TAdd(createCategoryDto);
            return Ok("Kategori  kaydedildi");
        }

        [HttpDelete]

        public IActionResult DeleteCategory(int id)
        {
            var result = _categoryService.TGetById(id);
            _categoryService.TDelete(result);
            return Ok("Kategori silindi.");
        }

        [HttpPut]

        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _categoryService.TUpdate(updateCategoryDto);
            return Ok("Kategori güncellendi.");
        }

        [HttpGet("GetById")]

        public IActionResult GetCategory(int id)
        {
            var result = _categoryService.TGetById(id);
            return Ok(result);
        }
    }
}
