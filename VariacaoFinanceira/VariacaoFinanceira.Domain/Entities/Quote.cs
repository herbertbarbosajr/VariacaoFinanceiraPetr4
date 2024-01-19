using System.Text.Json.Serialization;

namespace VariacaoFinanceira.Domain.Entities;

public class Quote
{
    [JsonPropertyName("close")]
    public List<double>? Close { get; set; }

    [JsonPropertyName("volume")]
    public List<long>? Volume { get; set; }

    [JsonPropertyName("open")]
    public List<double>? Open { get; set; }

    [JsonPropertyName("high")]
    public List<double>? High { get; set; }

    [JsonPropertyName("low")]
    public List<double>? Low { get; set; }
}
