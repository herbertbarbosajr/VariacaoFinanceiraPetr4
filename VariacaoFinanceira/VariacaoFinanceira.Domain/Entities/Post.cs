using System.Text.Json.Serialization;

namespace VariacaoFinanceira.Domain.Entities;

public class Post
{
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    [JsonPropertyName("start")]
    public long Start { get; set; }

    [JsonPropertyName("end")]
    public long End { get; set; }

    [JsonPropertyName("gmtoffset")]
    public long Gmtoffset { get; set; }
}
