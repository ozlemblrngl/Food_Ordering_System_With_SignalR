using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.TestimonialDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialsController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var testimonialList = _testimonialService.TGetList();
            var result = _mapper.Map<List<ResultTestimonialDto>>(testimonialList);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var testimonialEntity = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TAdd(testimonialEntity);
            return Ok("Beyan eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var testimonialEntity = _testimonialService.TGetById(id);
            if (testimonialEntity == null)
                return NotFound("Beyan bulunamadı.");

            _testimonialService.TDelete(testimonialEntity);
            return Ok("Beyan silindi.");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var testimonialEntity = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(testimonialEntity);
            return Ok("Beyan güncellendi.");
        }

        [HttpGet("GetById")]
        public IActionResult GetTestimonial(int id)
        {
            var testimonialEntity = _testimonialService.TGetById(id);
            if (testimonialEntity == null)
                return NotFound("Beyan bulunamadı.");

            var result = _mapper.Map<GetTestimonialDto>(testimonialEntity);
            return Ok(result);
        }
    }
}
