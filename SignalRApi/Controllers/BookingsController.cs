using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.BookingDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingsController : ControllerBase
	{
		private readonly IBookingService _bookingService;
		private readonly IMapper _mapper;

		public BookingsController(IBookingService bookingService, IMapper mapper)
		{
			_bookingService = bookingService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult BookingList()
		{
			var result = _bookingService.TGetList();
			var mappedResult = _mapper.Map<List<ResultBookingDto>>(result);
			return Ok(mappedResult);
		}

		[HttpPost]
		public IActionResult CreateBooking(CreateBookingDto createBookingDto)
		{
			var bookingEntity = _mapper.Map<Booking>(createBookingDto);
			_bookingService.TAdd(bookingEntity);
			return Ok("Rezervasyon yapıldı");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteBooking(int id)
		{
			var result = _bookingService.TGetById(id);
			_bookingService.TDelete(result);
			return Ok("Rezervasyon silindi.");
		}

		[HttpPut]
		public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
		{
			var bookingEntity = _mapper.Map<Booking>(updateBookingDto);
			_bookingService.TUpdate(bookingEntity);
			return Ok("Rezervasyon güncellendi.");
		}

		[HttpGet("GetById")]
		public IActionResult GetBooking(int id)
		{
			var result = _bookingService.TGetById(id);
			var mappedResult = _mapper.Map<GetBookingDto>(result);
			return Ok(mappedResult);
		}
	}
}
