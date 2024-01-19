using System.Text.Json.Serialization;

namespace VariacaoFinanceira.Application.Dtos;

public class VariacaoAnaliticaDTO
{
    public VariacaoAnaliticaDTO()
    {
    }

    public VariacaoAnaliticaDTO(DateTime date, double value, double variationPreviousDate, double variationFirstDate)
    {
        Date = date;
        Value = value;
        VariationPreviousDate = variationPreviousDate;
        VariationFirstDate = variationFirstDate;
    }

    [JsonPropertyName("Data")]
    public DateTime Date { get; set; }

    [JsonPropertyName("Valor")]
    public double Value { get; set; }

    [JsonPropertyName("Variação em relação a D-1")]
    public double VariationPreviousDate { get; set; }

    [JsonPropertyName("Variação em relação a primeira data")]
    public double VariationFirstDate { get; set; }
}
