using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class BookingRepository {

    private readonly DbProvider<TravelDbContext> travelDb;

    public BookingRepository(DbProvider<TravelDbContext> travelDb) {
        this.travelDb = travelDb;
    }

    public Task<Booking> GetBooking(int id) =>
        travelDb.Use(db => db.Booking.SingleOrDefaultAsync(b => b.Id == id));

    public async Task<Booking> AddBooking(CreateBookingRequest request)  {
        var toAdd = new Booking {
            Destination = request.Destination,
            Duration = request.Duration,
            Username = request.Username,
            Email = request.Email
        };

        await travelDb.Use(db => {
            db.Booking.Add(toAdd);
            return db.SaveChangesAsync();
        });

        return toAdd;
    }
}