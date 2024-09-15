using BusinessLayer.Abstract;
using DtoLayer.FeatureDto;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;


        public FeaturesController(IFeatureService featureService)
        {
            _featureService = featureService;

        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var result = _featureService.TGetList();
            return Ok(result);
        }

        [HttpPost]

        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            _featureService.TAdd(createFeatureDto);
            return Ok("Özellik eklendi.");
        }

        [HttpDelete]

        public IActionResult DeleteFeature(int id)
        {
            var result = _featureService.TGetById(id);
            _featureService.TDelete(result);
            return Ok("Özellik silindi.");
        }

        [HttpPut]

        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            _featureService.TUpdate(updateFeatureDto);
            return Ok("Özellik güncellendi.");
        }

        [HttpGet("GetById")]

        public IActionResult GetFeature(int id)
        {
            var result = _featureService.TGetById(id);
            return Ok(result);
        }
    }
}
