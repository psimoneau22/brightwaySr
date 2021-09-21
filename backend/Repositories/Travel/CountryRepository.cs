using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class CountryRepository {

    private readonly TravelDbContext dbContext;

    public CountryRepository(TravelDbContext dbContext) {
        this.dbContext = dbContext;
    }

    public Task<List<Country>> ListCountries() =>
        dbContext.Countries
            .ToListAsync();

    public Task<Country> GetCountry(int id) =>
        dbContext.Countries.SingleOrDefaultAsync(c => c.Id == id);
}