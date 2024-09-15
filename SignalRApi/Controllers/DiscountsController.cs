using BusinessLayer.Abstract;
using DtoLayer.DiscountDto;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;


        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;

        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var result = _discountService.TGetList();
            return Ok(result);
        }

        [HttpPost]

        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            _discountService.TAdd(createDiscountDto);
            return Ok("İndirim eklendi.");
        }

        [HttpDelete]

        public IActionResult DeleteDiscount(int id)
        {
            var result = _discountService.TGetById(id);
            _discountService.TDelete(result);
            return Ok("İndirim silindi.");
        }

        [HttpPut]

        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _discountService.TUpdate(updateDiscountDto);
            return Ok("İndirim güncellendi.");
        }

        [HttpGet("GetById")]

        public IActionResult GetDiscount(int id)
        {
            var result = _discountService.TGetById(id);
            return Ok(result);
        }
    }
}
