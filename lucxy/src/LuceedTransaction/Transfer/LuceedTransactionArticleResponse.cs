using System.Text.Json.Serialization;

namespace Tomsoft.LuceedClient.Transfer;

public class LuceedTransactionArticleResponse
{
    [JsonPropertyName("result")]
    public List<LuceedTransactionArticleResult>? result { get; set; }
}

public class LuceedTransactionArticleResult
{
    [JsonPropertyName("ArticleCalculation")]
    public List<LuceedArticle>? obracun_artikli { get; set; }
}

public class LuceedTransactionArticle
{
    [JsonPropertyName("ArticleUid")]
    public int artikl_uid { get; init; }

    [JsonPropertyName("ArticleName")]
    public string? naziv_artikla { get; set; }

    [JsonPropertyName("Quantity")]
    public double? kolicina { get; set; }

    [JsonPropertyName("Amount")]
    public double? iznos { get; set; }

    [JsonPropertyName("Service")]
    public string? usluga { get; set; }
}
