using VariacaoFinanceira.Infrastructure.Mappings;

namespace VariacaoFinanceira.Infrastructure.Queries;

public class QueryRequest : DefaultQuery
{
    public QueryMain Get30Days()
    {

        this.Table = Mapping.GetYahooFinanceTable();

        this.Query = $@"
                SELECT 
                PET.[ID] AS [Dia],
                CONVERT(VARCHAR(10), PET.[CL_DATE], 103) AS [Data],
                CONCAT('R$', PET.[CL_VALUE]) AS [Valor],
                CONCAT(PET.[CL_VARIATION_PREVIOUS_DATE], '%') AS [Variacao_em_relacao_a_Dm1],
                CONCAT(PET.[CL_VARIATION_FIRST_DATE], '%') AS [Variacao_em_relacao_a_primeira_data]
                FROM {this.Table} AS PET
            ";

        return new QueryMain(this.Query, null);
    }
}
