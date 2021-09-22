public class Booking
{
    public int Id { get; set; }
    public int Destination { get; set; }
    public int Duration { get; set; }
    public string Username {get;set;}
    public string Email {get;set;}
    public decimal CurrentExchangeRate {get;set;}
    public decimal CostPerDayExchange {get;set;}
    public decimal TotalCostExchange => this.Duration * CostPerDayExchange;

    public void PopulateExchangeRateDetails(decimal exchangeRate, TravelSettings travelSettings) {
        CostPerDayExchange = exchangeRate * travelSettings.CostPerDayUSD;
        CurrentExchangeRate = exchangeRate;
    }
}