using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.SocialMediaDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediasController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var socialMediaList = _socialMediaService.TGetList();
            var result = _mapper.Map<List<ResultSocialMediaDto>>(socialMediaList);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var socialMediaEntity = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.TAdd(socialMediaEntity);
            return Ok("Sosyal Medya eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var socialMediaEntity = _socialMediaService.TGetById(id);
            if (socialMediaEntity == null)
                return NotFound("Sosyal Medya bulunamadı.");

            _socialMediaService.TDelete(socialMediaEntity);
            return Ok("Sosyal Medya silindi.");
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var socialMediaEntity = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _socialMediaService.TUpdate(socialMediaEntity);
            return Ok("Sosyal Medya güncellendi.");
        }

        [HttpGet("GetById")]
        public IActionResult GetSocialMedia(int id)
        {
            var socialMediaEntity = _socialMediaService.TGetById(id);
            if (socialMediaEntity == null)
                return NotFound("Sosyal Medya bulunamadı.");

            var result = _mapper.Map<GetSocialMediaDto>(socialMediaEntity);
            return Ok(result);
        }
    }
}
