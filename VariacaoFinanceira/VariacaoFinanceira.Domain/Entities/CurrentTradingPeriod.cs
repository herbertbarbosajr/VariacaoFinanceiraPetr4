using System.Text.Json.Serialization;

namespace VariacaoFinanceira.Domain.Entities;

public class CurrentTradingPeriod
{
    [JsonPropertyName("pre")]
    public Post? Pre { get; set; }

    [JsonPropertyName("regular")]
    public Post? Regular { get; set; }

    [JsonPropertyName("post")]
    public Post? Post { get; set; }
}
