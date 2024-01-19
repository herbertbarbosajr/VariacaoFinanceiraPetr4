using Microsoft.EntityFrameworkCore;
using VariacaoFinanceira.Domain.Entities;

namespace VariacaoFinanceira.Infrastructure.Connection;

public class ApiDBContext : DbContext
{
    public ApiDBContext(DbContextOptions<ApiDBContext> options)
        : base(options)
    {

    }
    public DbSet<Variacao> TB_VARIACAO_DAILY { get; set; }
}
