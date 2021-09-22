using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

public class ExchangeProxy {

    public const string AppSettingName = "Proxies:Exchange";

    private readonly HttpClient exchangeClient;

    public ExchangeProxy(HttpClient exchangeClient) {
        this.exchangeClient = exchangeClient;
    }

    public async Task<decimal> GetExchangeRate(string sourceCurrencySymbol, string targetCurrencySymbol) {
        var response = await exchangeClient.GetAsync($"exchange?from={sourceCurrencySymbol}&to={targetCurrencySymbol}");
        var result = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<decimal>(result);
    }
}