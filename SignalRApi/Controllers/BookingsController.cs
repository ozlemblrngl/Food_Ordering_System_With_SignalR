using BusinessLayer.Abstract;
using DtoLayer.BookingDto;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var result = _bookingService.TGetList();
            return Ok(result);
        }

        [HttpPost]

        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            _bookingService.TAdd(createBookingDto);
            return Ok("Rezervasyon yapıldı");
        }

        [HttpDelete]

        public IActionResult DeleteBooking(int id)
        {
            var result = _bookingService.TGetById(id);
            _bookingService.TDelete(result);
            return Ok("Rezervasyon silindi.");
        }

        [HttpPut]

        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            _bookingService.TUpdate(updateBookingDto);
            return Ok("Rezervasyon güncellendi.");
        }

        [HttpGet("GetById")]

        public IActionResult GetBooking(int id)
        {
            var result = _bookingService.TGetById(id);
            return Ok(result);
        }
    }
}
