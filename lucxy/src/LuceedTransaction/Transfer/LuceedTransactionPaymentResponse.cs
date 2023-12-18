using System.Text.Json.Serialization;

namespace Tomsoft.LuceedClient.Transfer;

public class LuceedTransactionPaymentResponse
{
    [JsonPropertyName("result")]
    public List<LuceedTransactionPaymentResult>? result { get; set; }
}

public class LuceedTransactionPaymentResult
{
    [JsonPropertyName("PaymentCalculation")]
    public List<LuceedArticle>? obracun_placanja { get; set; }
}

public class LuceedTransactionPayment
{
    [JsonPropertyName("PaymentTypeUid")]
    public int vrste_placanja_uid { get; init; }

    [JsonPropertyName("Name")]
    public string? naziv { get; set; }

    [JsonPropertyName("Amount")]
    public double? iznos { get; set; }
}
