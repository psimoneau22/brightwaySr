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

    public async Task<Booking> GetDetail(int id) {
        var booking = await bookingRepository.GetBooking(id);
        if(booking == null) {
            return null;
        }

        var exchangeRate = await GetExchangeRate(booking.Destination);

        booking.PopulateExchangeRateDetails(exchangeRate, travelSettings);

        return booking;
    }

    public async Task<Booking> CreateBooking(CreateBookingRequest request) {
        var (booking, exchangeRate) = await TaskHelper.WhenAll(
            bookingRepository.AddBooking(request),
            GetExchangeRate(request.Destination)
        );

        booking.PopulateExchangeRateDetails(exchangeRate, travelSettings);

        return booking;
    }

    private async Task<decimal> GetExchangeRate(int targetCountryId) {
        var destination = await countryRepository.GetCountry(targetCountryId);
        return await exchangeProxy.GetExchangeRate("USD", destination.Currency);
    }
}
