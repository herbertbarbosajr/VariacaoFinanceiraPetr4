using Microsoft.AspNetCore.Http.HttpResults;
using VariacaoFinanceira.Application.Dtos;
using VariacaoFinanceira.Domain.Entities;
using VariacaoFinanceira.Infrastructure.Connection;

namespace VariacaoFinanceira.API.Endpoints;

public class VariacaoFinanceiraEndPoint
{
    public static Created<Variacao> InsertVariacao(Variacao variacao, ApiDBContext db)
    {
        db.TB_VARIACAO_DAILY.Add(variacao);
        db.SaveChanges();

        return TypedResults.Created($"/variacao/{variacao.ID}", variacao);
    }
    public static IEnumerable<Variacao>BuscarVariacao(ApiDBContext db)
    {
       return db.TB_VARIACAO_DAILY.ToList();
    }
}
