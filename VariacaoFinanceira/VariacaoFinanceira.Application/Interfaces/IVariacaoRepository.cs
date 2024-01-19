using VariacaoFinanceira.Application.Dtos;
using VariacaoFinanceira.Domain.Entities;

namespace VariacaoFinanceira.Application.Interfaces;

public interface IVariacaoRepository
{
    IEnumerable<Variacao> Get30Days();
    
}
