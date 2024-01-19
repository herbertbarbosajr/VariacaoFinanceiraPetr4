using System.Text.Json.Serialization;
using VariacaoFinanceira.Domain.Entities;

namespace VariacaoFinanceira.Application.Dtos;

public class VariacaoDTO
{
    [JsonPropertyName("chart")]
    public Chart Chart { get; set; }
}
