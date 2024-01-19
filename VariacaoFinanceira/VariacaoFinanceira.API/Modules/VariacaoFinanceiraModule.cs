using Microsoft.AspNetCore.Mvc;
using VariacaoFinanceira.Application;
using VariacaoFinanceira.Application.Dtos;
using VariacaoFinanceira.Application.Interfaces;
using VariacaoFinanceira.Domain.Entities;

namespace VariacaoFinanceira.API.Modules;

public static class VariacaoFinanceiraModule
{
    public static void ConfigureVariacaoFinanceiraModule(this WebApplication app)
    {
        app.MapGet("VariacaoFinanceira/Variacao/GetDatas/", ([FromServices] IVariacaoFinanceiraRepository repository) =>
        {
            return repository.Get();
        })
            .WithSummary("Busca Variação Financeira");

        app.MapPost("/VariacaoFinanceira/Variacao/Insert/", ([FromServices] InsertRequest request, [FromBody] List<VariacaoAnaliticaDTO> dto) =>
        {
            return request.Action(dto);
        })
            .WithSummary("Insere Variação Financeira");


        app.MapGet("/VariacaoFinanceira/Variacao/Last30Days/", ([FromServices] IVariacaoRepository repository) =>
        {
            return repository.Get30Days();
        })
            .WithSummary("Buscar Variação dos últimos 30 dias")
            .WithOpenApi();

    }
}
