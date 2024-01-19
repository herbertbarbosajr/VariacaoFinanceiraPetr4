using VariacaoFinanceira.Application.Dtos;
using VariacaoFinanceira.Application.Interfaces;
using VariacaoFinanceira.Domain.Entities;

namespace VariacaoFinanceira.Application;

public class InsertRequest : IRequest<List<VariacaoAnaliticaDTO>, State>
{
    private readonly IVariacaoFinanceiraRepository _variacaoFinanceiraRepository;

    public InsertRequest(IVariacaoFinanceiraRepository variacaoFinanceiraRepository)
    {
        _variacaoFinanceiraRepository = variacaoFinanceiraRepository;
    }

    public State Action(List<VariacaoAnaliticaDTO> entities)
    {
        try
        {
            foreach (var item in entities)
            {
                var variacao = new VariacaoAnaliticaDTO(item.Date, item.Value, item.VariationPreviousDate, item.VariationFirstDate);
                _variacaoFinanceiraRepository.InsertVariacao(item);
            }

            return new State(200, "Dados inseridos com sucesso!", entities);
        }
        catch (Exception ex)
        {
            return new State(500, ex.Message, null);
        }
        return new State(400, "Houve um erro ao tentar inserir os dados, por favor tente novamente!", null);
    }
}
