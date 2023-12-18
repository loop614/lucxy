using System.Text.Json.Serialization;

namespace Lucxy.LuceedArticle.Transfer;

public class LuceedArticleResponse
{
    [JsonPropertyName("Result")]
    public List<LuceedArticleResult>? result { get; set; }
}

public class LuceedArticleResult
{
    [JsonPropertyName("Articles")]
    public List<LuceedArticle>? artikli { get; set; }
}

public class LuceedArticle
{
    [JsonPropertyName("Id")]
    public int Id { get; init; }

    [JsonPropertyName("Name")]
    public string? naziv { get; set; }
}
