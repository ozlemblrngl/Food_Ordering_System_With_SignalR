using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.CategoryDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var result = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetList());
            return Ok(result);
        }

        [HttpPost]

        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TAdd(category);
            return Ok("Kategori  kaydedildi");
        }

        [HttpDelete]

        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryService.TGetById(id);
            if (category == null) return NotFound("Kategori Bulunamadı.");

            _categoryService.TDelete(category);
            return Ok("Kategori silindi.");
        }

        [HttpPut]

        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(category);
            return Ok("Kategori güncellendi.");
        }

        [HttpGet("GetById")]

        public IActionResult GetCategory(int id)
        {
            var category = _categoryService.TGetById(id);
            if (category == null)
            {
                return NotFound("Kategori Bulunamadı.");
            }

            var result = _mapper.Map<GetCategoryDto>(category);
            return Ok(result);
        }
    }
}
