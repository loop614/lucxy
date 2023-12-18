using Lucxy.LuceedTransaction;
using Lucxy.LuceedTransaction.Transfer;

namespace lucxytest.LuceedTransaction;

public class LuceedTransactionTest
{
    private readonly ILuceedTransactionFacade _luceedTransactionFacade;

    public LuceedTransactionTest(ILuceedTransactionFacade luceedTransactionFacade) => _luceedTransactionFacade = luceedTransactionFacade;

    [Fact]
    public async void FetchLuceedArticleTransactions()
    {
        DateOnly from = DateOnly.ParseExact("01.01.1999", "dd.MM.yyyy", null);
        DateOnly to = DateOnly.ParseExact("01.01.2024", "dd.MM.yyyy", null);

        LuceedTransactionRequest luceedTransactionRequest = new("132", from, to);
        LuceedTransactionArticleResponse? response = await _luceedTransactionFacade.FetchLuceedArticleTransactions(luceedTransactionRequest);
        Assert.NotNull(response);
    }

    [Fact]
    public async void FetchLuceedPaymentTransactions()
    {
        DateOnly from = DateOnly.ParseExact("01.01.1999", "dd.MM.yyyy");
        DateOnly to = DateOnly.ParseExact("01.01.2024", "dd.MM.yyyy");

        LuceedTransactionRequest luceedTransactionRequest = new("132", from, to);
        LuceedTransactionPaymentResponse? response = await _luceedTransactionFacade.FetchLuceedPaymentTransactions(luceedTransactionRequest);
        Assert.NotNull(response);
    }
}
