using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.DiscountDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountsController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var discountList = _discountService.TGetList();
            var result = _mapper.Map<List<ResultDiscountDto>>(discountList);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            var discountEntity = _mapper.Map<Discount>(createDiscountDto);
            _discountService.TAdd(discountEntity);
            return Ok("İndirim eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var discountEntity = _discountService.TGetById(id);
            if (discountEntity == null)
                return NotFound("İndirim bulunamadı.");

            _discountService.TDelete(discountEntity);
            return Ok("İndirim silindi.");
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var discountEntity = _mapper.Map<Discount>(updateDiscountDto);
            _discountService.TUpdate(discountEntity);
            return Ok("İndirim güncellendi.");
        }

        [HttpGet("GetById")]
        public IActionResult GetDiscount(int id)
        {
            var discountEntity = _discountService.TGetById(id);
            if (discountEntity == null)
                return NotFound("İndirim bulunamadı.");

            var result = _mapper.Map<GetDiscountDto>(discountEntity);
            return Ok(result);
        }
    }
}
