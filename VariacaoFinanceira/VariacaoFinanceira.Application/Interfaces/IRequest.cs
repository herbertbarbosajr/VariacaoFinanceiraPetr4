using VariacaoFinanceira.Application.Dtos;
using VariacaoFinanceira.Domain.Entities;

namespace VariacaoFinanceira.Application.Interfaces;

public interface IRequest<in T, out W>
        where T : List<VariacaoAnaliticaDTO>
        where W : State
{
    W Action(T command);
}