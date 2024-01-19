using System.Text.Json.Serialization;

namespace VariacaoFinanceira.Domain.Entities;

public class Indicators
{
    [JsonPropertyName("quote")]
    public List<Quote> Quote { get; set; }
}
