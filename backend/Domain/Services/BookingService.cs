using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System.Linq;

public class BookingService {

    private readonly BookingRepository bookingRepository;
    private readonly CountryRepository countryRepository;
    private readonly ExchangeProxy exchangeProxy;
    private readonly TravelSettings travelSettings;

    public BookingService(
        BookingRepository bookingRepository,
        CountryRepository countryRepository,
        ExchangeProxy exchangeProxy,
        IOptions<TravelSettings> travelSettings
    ) {
        this.bookingRepository = bookingRepository;
        this.countryRepository = countryRepository;
        this.exchangeProxy = exchangeProxy;
        this.travelSettings = travelSettings.Value;
    }

    public Task<Booking> GetDetail(int id) => bookingRepository.GetBooking(id);

    public async Task<Booking> CreateBooking(CreateBookingRequest request) {

        var destination = await countryRepository.GetCountry(request.Destination);

        var result = exchangeProxy.Convert(travelSettings.CostPerDayUSD, "USD", destination.Currency);
        return null;
        //var dbData = await bookingRepository.AddBooking(request);

        //return dbData;
    }
}
