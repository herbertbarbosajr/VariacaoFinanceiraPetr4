using VariacaoFinanceira.Application.Interfaces;
using VariacaoFinanceira.Domain.Entities;
using VariacaoFinanceira.Infrastructure.Connection;

namespace VariacaoFinanceira.Infrastructure.Repositories;

public class VariacaoRepository : IVariacaoRepository
{
    private readonly ApiDBContext _dbContext;
    

    public VariacaoRepository(ApiDBContext dbContext)
    {
        _dbContext = dbContext;     
    }

    public IEnumerable<Variacao> Get30Days()
    {
        DateTime filtro = DateTime.Now.AddDays(-30);
        return _dbContext.TB_VARIACAO_DAILY.Where(v => v.CL_DATE >= filtro).OrderByDescending(v => v.CL_DATE).ToList();
    }

}
