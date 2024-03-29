using Lucxy.LuceedTransaction.Domain;
using Lucxy.LuceedTransaction.Transfer;

namespace Lucxy.LuceedTransaction;

public class LuceedTransactionFacade(ILuceedTransactionFetcher luceedTransactionFetcher) : ILuceedTransactionFacade
{
    public Task<LuceedTransactionArticleResponse?> FetchLuceedArticleTransactions(LuceedTransactionRequest luceedTransactionRequest)
    {
        return luceedTransactionFetcher.FetchLuceedArticleTransactions(luceedTransactionRequest);
    }

    public Task<LuceedTransactionPaymentResponse?> FetchLuceedPaymentTransactions(LuceedTransactionRequest luceedTransactionRequest)
    {
        return luceedTransactionFetcher.FetchLuceedPaymentTransactions(luceedTransactionRequest);
    }
}
