using System.Text.Json.Serialization;

namespace VariacaoFinanceira.Application.Dtos;

public class VariacaoResponseDTO
{
    [JsonPropertyName("Dia")]
    public int Id { get; set; }

    [JsonPropertyName("Data")]
    public DateTime Data { get; set; }

    [JsonPropertyName("Valor")]
    public double Valor { get; set; }

    [JsonPropertyName("Variação em relação a D-1")]
    public double Variacao_em_relacao_a_Dm1 { get; set; }

    [JsonPropertyName("Variação em relação a primeira data")]
    public double Variacao_em_relacao_a_primeira_data { get; set; }
}
