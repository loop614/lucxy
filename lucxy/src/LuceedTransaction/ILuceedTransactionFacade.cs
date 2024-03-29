using Lucxy.LuceedTransaction.Transfer;

namespace Lucxy.LuceedTransaction;

public interface ILuceedTransactionFacade
{
    public Task<LuceedTransactionArticleResponse?> FetchLuceedArticleTransactions(LuceedTransactionRequest request);

    public Task<LuceedTransactionPaymentResponse?> FetchLuceedPaymentTransactions(LuceedTransactionRequest request);
}
