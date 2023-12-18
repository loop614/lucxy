using Tomsoft.LuceedClient.Transfer;

namespace Tomsoft.LuceedTransaction;

public interface ILuceedTransactionFacade
{
    public Task<LuceedTransactionArticleResponse?> FetchLuceedArticleTransactions(LuceedTransactionRequest request);
    public Task<LuceedTransactionPaymentResponse?> FetchLuceedPaymentTransactions(LuceedTransactionRequest request);
}
