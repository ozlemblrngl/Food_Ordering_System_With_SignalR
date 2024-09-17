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
			var categoryList = _categoryService.TGetList();
			var result = _mapper.Map<List<ResultCategoryDto>>(categoryList);
			return Ok(result);
		}

		[HttpPost]
		public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
		{
			var categoryEntity = _mapper.Map<Category>(createCategoryDto);
			_categoryService.TAdd(categoryEntity);
			return Ok("Kategori kaydedildi.");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCategory(int id)
		{
			var categoryEntity = _categoryService.TGetById(id);
			if (categoryEntity == null)
				return NotFound("Kategori bulunamadı.");

			_categoryService.TDelete(categoryEntity);
			return Ok("Kategori silindi.");
		}

		[HttpPut]
		public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			var categoryEntity = _mapper.Map<Category>(updateCategoryDto);
			_categoryService.TUpdate(categoryEntity);
			return Ok("Kategori güncellendi.");
		}

		[HttpGet("GetById")]
		public IActionResult GetCategory(int id)
		{
			var categoryEntity = _categoryService.TGetById(id);
			if (categoryEntity == null)
				return NotFound("Kategori bulunamadı.");

			var result = _mapper.Map<GetCategoryDto>(categoryEntity);
			return Ok(result);
		}
	}
}
