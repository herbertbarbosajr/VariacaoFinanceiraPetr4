using VariacaoFinanceira.Application.Dtos;
using VariacaoFinanceira.Domain.Entities;
using VariacaoFinanceira.Infrastructure.Mappings;

namespace VariacaoFinanceira.Infrastructure.Queries;

public class QueryResponse : DefaultQuery 
{
    public QueryMain InsertVariationQuery(VariacaoAnaliticaDTO variacao)
    {
        this.Table = Mapping.GetYahooFinanceTable();
        this.Query = $@"
                INSERT INTO {this.Table}
                VALUES
                (
                    @CL_DATE,
                    @CL_VALUE,
                    @CL_VARIATION_PREVIOUS_DATE,
                    @CL_VARIATION_FIRST_DATE
                )
            ";

        this.Parameters = new
        {
            CL_DATE = variacao.Date,
            CL_VALUE = variacao.Value,
            CL_VARIATION_PREVIOUS_DATE = variacao.VariationPreviousDate,
            CL_VARIATION_FIRST_DATE = variacao.VariationFirstDate
        };

        return new QueryMain(this.Query, this.Parameters);
    }
}
