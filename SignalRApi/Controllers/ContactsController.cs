using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.ContactDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactsController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var contactList = _contactService.TGetList();
            var result = _mapper.Map<List<ResultContactDto>>(contactList);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            var contactEntity = _mapper.Map<Contact>(createContactDto);
            _contactService.TAdd(contactEntity);
            return Ok("İletişim eklendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contactEntity = _contactService.TGetById(id);
            if (contactEntity == null)
                return NotFound("İletişim bulunamadı.");

            _contactService.TDelete(contactEntity);
            return Ok("İletişim silindi.");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var contactEntity = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(contactEntity);
            return Ok("İletişim güncellendi.");
        }

        [HttpGet("GetById")]
        public IActionResult GetContact(int id)
        {
            var contactEntity = _contactService.TGetById(id);
            if (contactEntity == null)
                return NotFound("İletişim bulunamadı.");

            var result = _mapper.Map<GetContactDto>(contactEntity);
            return Ok(result);
        }
    }
}
