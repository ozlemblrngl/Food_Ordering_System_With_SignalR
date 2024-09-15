using BusinessLayer.Abstract;
using DtoLayer.TestimonialDto;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;


        public TestimonialsController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;

        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var result = _testimonialService.TGetList();
            return Ok(result);
        }

        [HttpPost]

        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(createTestimonialDto);
            return Ok("Beyan eklendi.");
        }

        [HttpDelete]

        public IActionResult DeleteTestimonial(int id)
        {
            var result = _testimonialService.TGetById(id);
            _testimonialService.TDelete(result);
            return Ok("Beyan silindi.");
        }

        [HttpPut]

        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TUpdate(updateTestimonialDto);
            return Ok("Beyan güncellendi.");
        }

        [HttpGet("GetById")]

        public IActionResult GetTestimonial(int id)
        {
            var result = _testimonialService.TGetById(id);
            return Ok(result);
        }
    }
}
