using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[Route("api/booking")]
public class BookingController : ControllerBase {

    private readonly BookingService bookingService;

    public BookingController(
        BookingService bookingService
    ) {
        this.bookingService = bookingService;
    }

    [HttpGet("{id}")]
    public async Task<Booking> GetDetail(int id) {
        var dbData = await bookingService.GetDetail(id);

        return dbData;
    }

    [HttpGet("{id}")]
    public async Task<Booking> CreateBooking(CreateBookingRequest request) {

        var result = await bookingService.CreateBooking(request);
        return result;
    }
}
