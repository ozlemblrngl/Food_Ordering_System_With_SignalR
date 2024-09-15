using BusinessLayer.Abstract;
using DtoLayer.SocialMediaDto;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;


        public SocialMediasController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;

        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var result = _socialMediaService.TGetList();
            return Ok(result);
        }

        [HttpPost]

        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            _socialMediaService.TAdd(createSocialMediaDto);
            return Ok("Sosyal Medya eklendi.");
        }

        [HttpDelete]

        public IActionResult DeleteSocialMedia(int id)
        {
            var result = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(result);
            return Ok("Sosyal Medya silindi.");
        }

        [HttpPut]

        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _socialMediaService.TUpdate(updateSocialMediaDto);
            return Ok("Sosyal Medya güncellendi.");
        }

        [HttpGet("GetById")]

        public IActionResult GetSocialMedia(int id)
        {
            var result = _socialMediaService.TGetById(id);
            return Ok(result);
        }
    }
}
