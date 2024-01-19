using System.Text.Json.Serialization;

namespace VariacaoFinanceira.Domain.Entities;

public class Result
{
    [JsonPropertyName("meta")]
    public Meta Meta { get; set; }

    [JsonPropertyName("timestamp")]
    public List<long> Timestamp { get; set; }

    [JsonPropertyName("indicators")]
    public Indicators Indicators { get; set; }
}
