using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class CountryRepository {

    private readonly DbProvider<TravelDbContext> travelDb;

    public CountryRepository(DbProvider<TravelDbContext> travelDb) {
        this.travelDb = travelDb;
    }

    public Task<List<Country>> ListCountries() =>
        travelDb.Use(db => db.Countries.ToListAsync());

    public Task<Country> GetCountry(int id) =>
        travelDb.Use(db => db.Countries.SingleOrDefaultAsync(c => c.Id == id));
}