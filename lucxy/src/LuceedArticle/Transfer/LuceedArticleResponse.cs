using System.Text.Json.Serialization;

namespace Tomsoft.LuceedClient.Transfer;

public class LuceedArticleResponse
{
    [JsonPropertyName("result")]
    public List<LuceedArticleResult>? result { get; set; }
}

public class LuceedArticleResult
{
    [JsonPropertyName("Articles")]
    public List<LuceedArticle>? artikli { get; set; }
}

public class LuceedArticle
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("Name")]
    public string? naziv { get; set; }
}
