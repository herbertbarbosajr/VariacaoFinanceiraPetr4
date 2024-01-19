using System.Text.Json;
using VariacaoFinanceira.Application.Dtos;
using VariacaoFinanceira.Application.Interfaces;

namespace VariacaoFinanceira.Infrastructure.Services;

public class VariacaoFinanceiraService : IVariacaoFinanceiraService
{

    public async Task<string> Get()
    {
        string yahooFinance = "https://query2.finance.yahoo.com/v8/finance/chart/PETR4.SA?symbol=PETR4.SA&period1=1695814400&period2=9999999999&interval=1d";

        var httpClient = new HttpClient();

        var response = await httpClient.GetAsync(yahooFinance);

        var data = await response.Content.ReadAsStringAsync();

        var json = JsonSerializer.Deserialize<VariacaoDTO>(data);

        return data;
    }

}
