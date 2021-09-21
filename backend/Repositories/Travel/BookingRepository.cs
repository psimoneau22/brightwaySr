using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class BookingRepository {

    private readonly TravelDbContext dbContext;

    public BookingRepository(TravelDbContext dbContext) {
        this.dbContext = dbContext;
    }

    public Task<Booking> GetBooking(int id) =>
        dbContext.Booking.SingleOrDefaultAsync(b => b.Id == id);

    public async Task<Booking> AddBooking(CreateBookingRequest request)  {
        var toAdd = new Booking {
            Destination = request.Destination,
            Duration = request.Duration,
            Username = request.Username,
            Email = request.Email
        };

        dbContext.Booking.Add(toAdd);
        await dbContext.SaveChangesAsync();

        return toAdd;
    }
}