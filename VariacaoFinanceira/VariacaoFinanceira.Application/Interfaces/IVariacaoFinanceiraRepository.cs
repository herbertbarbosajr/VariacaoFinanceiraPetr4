using VariacaoFinanceira.Application.Dtos;
using VariacaoFinanceira.Domain.Entities;

namespace VariacaoFinanceira.Application.Interfaces;

public interface IVariacaoFinanceiraRepository
{
    Task<List<VariacaoAnaliticaDTO>> Get();
    void InsertVariacao(VariacaoAnaliticaDTO variacaoDto);
    
    
}
