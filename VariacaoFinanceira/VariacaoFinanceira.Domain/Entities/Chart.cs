using System.Text.Json.Serialization;

namespace VariacaoFinanceira.Domain.Entities;

public class Chart
{
    [JsonPropertyName("result")]
    public List<Result> Result { get; set; }

    [JsonPropertyName("error")]
    public object Error { get; set; }
}
