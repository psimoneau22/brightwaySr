using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

public class DbProvider<TDbContext> where TDbContext : DbContext {
    private readonly IDbContextFactory<TDbContext> contextFactory;

    public DbProvider(IDbContextFactory<TDbContext> contextFactory) {
        this.contextFactory = contextFactory;
    }

    public async Task<TReturn> Use<TReturn>(Func<TDbContext, Task<TReturn>> action) {
        using(var db = contextFactory.CreateDbContext()) {
            var result = await action(db);
            return result;
        }
    }
}