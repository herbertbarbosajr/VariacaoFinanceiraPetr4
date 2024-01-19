namespace VariacaoFinanceira.Infrastructure.Mappings;

public class QueryMain
{
    public QueryMain(string? query, object? parameters)
    {
        Query = query;
        Parameters = parameters;
    }
    public string? Query { get; set; }
    public object? Parameters { get; set; }
}
