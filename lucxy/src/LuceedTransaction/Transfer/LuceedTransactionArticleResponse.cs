using System.Text.Json.Serialization;

namespace Lucxy.LuceedTransaction.Transfer;

public class LuceedTransactionArticleResponse
{
    [JsonPropertyName("Result")]
    public List<LuceedTransactionArticleResult>? result { get; set; }
}

public class LuceedTransactionArticleResult
{
    [JsonPropertyName("ArticleCalculation")]
    public List<LuceedTransactionArticle>? obracun_artikli { get; set; }
}

public class LuceedTransactionArticle
{
    [JsonPropertyName("ArticleUid")]
    public string? artikl_uid { get; init; }

    [JsonPropertyName("ArticleName")]
    public string? naziv_artikla { get; set; }

    [JsonPropertyName("Quantity")]
    public double? kolicina { get; set; }

    [JsonPropertyName("Amount")]
    public double? iznos { get; set; }

    [JsonPropertyName("Service")]
    public string? usluga { get; set; }
}
