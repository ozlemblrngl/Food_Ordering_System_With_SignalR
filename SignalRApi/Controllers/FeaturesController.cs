using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.FeatureDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeaturesController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var featureList = _featureService.TGetList();
            var result = _mapper.Map<List<ResultFeatureDto>>(featureList);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var featureEntity = _mapper.Map<Feature>(createFeatureDto);
            _featureService.TAdd(featureEntity);
            return Ok("Özellik eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var featureEntity = _featureService.TGetById(id);
            if (featureEntity == null)
                return NotFound("Özellik bulunamadı.");

            _featureService.TDelete(featureEntity);
            return Ok("Özellik silindi.");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var featureEntity = _mapper.Map<Feature>(updateFeatureDto);
            _featureService.TUpdate(featureEntity);
            return Ok("Özellik güncellendi.");
        }

        [HttpGet("GetById")]
        public IActionResult GetFeature(int id)
        {
            var featureEntity = _featureService.TGetById(id);
            if (featureEntity == null)
                return NotFound("Özellik bulunamadı.");

            var result = _mapper.Map<GetFeatureDto>(featureEntity);
            return Ok(result);
        }
    }
}
