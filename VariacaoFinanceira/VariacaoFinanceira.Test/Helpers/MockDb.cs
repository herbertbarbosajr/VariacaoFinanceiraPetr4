using Microsoft.EntityFrameworkCore;
using VariacaoFinanceira.Infrastructure.Connection;

namespace VariacaoFinanceira.Test.Helpers;

public class MockDb : IDbContextFactory<ApiDBContext>
{
    public ApiDBContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<ApiDBContext>()
             .UseInMemoryDatabase($"InMemoryTestDb-{DateTime.Now.ToFileTimeUtc()}")
             .Options;

        return new ApiDBContext(options);
    }
}
