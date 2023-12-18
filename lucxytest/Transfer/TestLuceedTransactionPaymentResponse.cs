using System.Text.Json.Serialization;

namespace Lucxy.LuceedTransaction.Transfer;

public class TestLuceedTransactionPaymentResponse
{
    public List<LuceedTransactionPaymentResult>? Result { get; set; }
}

public class TestLuceedTransactionPaymentResult
{
    public List<LuceedTransactionPayment>? PaymentCalculation { get; set; }
}

public class TestLuceedTransactionPayment
{
    public int PaymentTypeUid { get; init; }

    public string? Name { get; set; }

    public double? Amount { get; set; }
}
