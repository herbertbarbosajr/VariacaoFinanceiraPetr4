using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using VariacaoFinanceira.Application;
using VariacaoFinanceira.Application.Interfaces;
using VariacaoFinanceira.Application.Mappings;
using VariacaoFinanceira.Infrastructure.Connection;
using VariacaoFinanceira.Infrastructure.Repositories;
using VariacaoFinanceira.Infrastructure.Services;

namespace VariacaoFinanceira.Ioc;

public static class DependencyInjectionAPI
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
           IConfiguration configuration)
    {
        services.AddScoped<ConnectionDb>();
        services.AddScoped<IVariacaoRepository, VariacaoRepository>();
        services.AddTransient<IVariacaoFinanceiraRepository, VariacaoFinanceiraRepository>();
        services.AddTransient<IVariacaoFinanceiraService, VariacaoFinanceiraService>();

        services.AddTransient<InsertRequest>();

        services.AddAutoMapper(typeof(MappingViewsProfile));
        var connectionString = configuration["ConnectionStrings:DevConnection"];
        services.AddDbContext<ApiDBContext>(options =>
                                                    options.UseSqlServer(connectionString));

        return services;
    }
}
