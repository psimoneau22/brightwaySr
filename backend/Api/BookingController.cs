using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[Route("api/booking")]
[ApiController]
public class BookingController : ControllerBase {

    private readonly BookingService bookingService;

    public BookingController(
        BookingService bookingService
    ) {
        this.bookingService = bookingService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Booking>> GetDetail(int id) {
        var dbData = await bookingService.GetDetail(id);

        return dbData == null
            ? NotFound()
            : dbData;
    }

    [HttpPost("")]
    public async Task<Booking> CreateBooking(CreateBookingRequest request) {

        var result = await bookingService.CreateBooking(request);
        return result;
    }
}
