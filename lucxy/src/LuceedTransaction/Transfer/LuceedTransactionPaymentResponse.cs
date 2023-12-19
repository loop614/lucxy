using System.Text.Json.Serialization;

namespace Lucxy.LuceedTransaction.Transfer;

public class LuceedTransactionPaymentResponse
{
    [JsonPropertyName("Result")]
    public List<LuceedTransactionPaymentResult>? result { get; set; }
}

public class LuceedTransactionPaymentResult
{
    [JsonPropertyName("PaymentCalculation")]
    public List<LuceedTransactionPayment>? obracun_placanja { get; set; }
}

public class LuceedTransactionPayment
{
    [JsonPropertyName("PaymentTypeUid")]
    public string? vrste_placanja_uid { get; init; }

    [JsonPropertyName("Name")]
    public string? naziv { get; set; }

    [JsonPropertyName("Amount")]
    public double? iznos { get; set; }

    [JsonPropertyName("SuperGroupPaymentId")]
    public string? nadgrupa_placanja_uid { get; set; }

    [JsonPropertyName("SuperGroupPaymentName")]
    public string? nadgrupa_placanja_naziv { get; set; }
}
