using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/country")]
public class CountryController : ControllerBase {

    private readonly CountryRepository countryRepository;

    public CountryController(CountryRepository countryRepository) {
        this.countryRepository = countryRepository;
    }

    [HttpGet("")]
    public async Task<List<Country>> GetCountries() {
        var dbData = await countryRepository.ListCountries();

        return dbData;
    }
}
