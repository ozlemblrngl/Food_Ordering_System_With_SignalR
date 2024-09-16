using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.AboutDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutsController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var result = _aboutService.TGetList();
            var mappedResult = _mapper.Map<List<ResultAboutDto>>(result);
            return Ok(mappedResult);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var aboutEntity = _mapper.Map<About>(createAboutDto);
            _aboutService.TAdd(aboutEntity);
            return Ok("Hakkımda alanı başarılı bir şekilde eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var result = _aboutService.TGetById(id);
            _aboutService.TDelete(result);
            return Ok("Hakkımda alanı silindi.");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var aboutEntity = _mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(aboutEntity);
            return Ok("Hakkımda alanı başarılı şekilde güncellendi.");
        }

        [HttpGet("GetById")]
        public IActionResult GetAbout(int id)
        {
            var result = _aboutService.TGetById(id);
            var mappedResult = _mapper.Map<GetAboutDto>(result);
            return Ok(mappedResult);
        }
    }
}
