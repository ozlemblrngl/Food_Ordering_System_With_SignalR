using BusinessLayer.Abstract;
using DtoLayer.ContactDto;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;


        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;

        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var result = _contactService.TGetList();
            return Ok(result);
        }

        [HttpPost]

        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            _contactService.TAdd(createContactDto);
            return Ok("İletişim eklendi.");
        }

        [HttpDelete]

        public IActionResult DeleteContact(int id)
        {
            var result = _contactService.TGetById(id);
            _contactService.TDelete(result);
            return Ok("İletişim silindi.");
        }

        [HttpPut]

        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            _contactService.TUpdate(updateContactDto);
            return Ok("İletişim güncellendi.");
        }

        [HttpGet("GetById")]

        public IActionResult GetContact(int id)
        {
            var result = _contactService.TGetById(id);
            return Ok(result);
        }
    }
}
