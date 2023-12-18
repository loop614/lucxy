using Lucxy.LuceedTransaction.Domain;
using Lucxy.LuceedTransaction.Transfer;

namespace Lucxy.LuceedTransaction;

public class LuceedTransactionFacade : ILuceedTransactionFacade {
    private readonly ILuceedTransactionFetcher _luceedTransactionFetcher;
    public LuceedTransactionFacade(ILuceedTransactionFetcher luceedTransactionFetcher) {
        _luceedTransactionFetcher = luceedTransactionFetcher;
    }

    public Task<LuceedTransactionArticleResponse?> FetchLuceedArticleTransactions(LuceedTransactionRequest luceedTransactionRequest)
    {
        return _luceedTransactionFetcher.
            FetchLuceedArticleTransactions(luceedTransactionRequest);
    }

    public Task<LuceedTransactionPaymentResponse?> FetchLuceedPaymentTransactions(LuceedTransactionRequest luceedTransactionRequest)
    {
        return _luceedTransactionFetcher.
            FetchLuceedPaymentTransactions(luceedTransactionRequest);
    }
}
