using VariacaoFinanceira.Application.Dtos;

namespace VariacaoFinanceira.Application.Interfaces;

public interface IVariacaoFinanceiraService
{
    Task<string> Get();
}
