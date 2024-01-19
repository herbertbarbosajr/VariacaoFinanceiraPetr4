using Dapper;
using System.Data;
using System.Text.Json;
using VariacaoFinanceira.Application.Dtos;
using VariacaoFinanceira.Application.Interfaces;
using VariacaoFinanceira.Infrastructure.Connection;
using VariacaoFinanceira.Infrastructure.Queries;

namespace VariacaoFinanceira.Infrastructure.Repositories;

public class VariacaoFinanceiraRepository : IVariacaoFinanceiraRepository
{
    private readonly IVariacaoFinanceiraService _financeService;
    private readonly IDbConnection _connection;
   


    public VariacaoFinanceiraRepository(IVariacaoFinanceiraService financeService,
        ConnectionDb query)
    {
        _financeService = financeService;
        _connection = query.SqlConnection();
    }

    public async Task<List<VariacaoAnaliticaDTO>> Get()
    {
        var jsonFull = _financeService.Get();

        var json = JsonSerializer.Deserialize<VariacaoDTO>(await jsonFull);

        List<VariacaoAnaliticaDTO> vaDTO = new List<VariacaoAnaliticaDTO>();
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        var timestamp = json.Chart.Result[0].Timestamp[0];

        for (int i = 0; i < json.Chart.Result[0].Timestamp.Count; i++)
        {
            var valueFirstDate = json.Chart.Result[0].Indicators.Quote[0].Open[0];
            var valueToday = json.Chart.Result[0].Indicators.Quote[0].Open[i];
            VariacaoAnaliticaDTO vAnalyticsdto = new VariacaoAnaliticaDTO();

            var date = dateTime.AddSeconds(json.Chart.Result[0].Timestamp[i]).ToLocalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
            vAnalyticsdto.Date = Convert.ToDateTime(date);
            vAnalyticsdto.Value = Math.Round(valueToday, 2);
            if (i > 0)
            {
                var valuePreviousDate = json.Chart.Result[0].Indicators.Quote[0].Open[i - 1];
                vAnalyticsdto.VariationPreviousDate = Math.Round(((valueToday / valuePreviousDate) - 1) * 100, 2);
                vAnalyticsdto.VariationFirstDate = Math.Round(((valueToday / valueFirstDate) - 1) * 100, 2);
            }
            else
            {
                vAnalyticsdto.VariationPreviousDate = 0;
                vAnalyticsdto.VariationFirstDate = 0;
            }

            vaDTO.Add(vAnalyticsdto);
        }

        return vaDTO;

    }

    public void InsertVariacao(VariacaoAnaliticaDTO variacaoDto)
    {
        _connection.Open();

        try
        {
            var query = new QueryResponse().InsertVariationQuery(variacaoDto);
            _connection.Execute(query.Query, query.Parameters);
        }
        catch
        {
            throw new Exception("Erro ao inserir dados.");
        }

        _connection.Close();
    }

    
}
