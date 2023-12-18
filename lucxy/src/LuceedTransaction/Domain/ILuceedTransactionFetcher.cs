using Tomsoft.LuceedClient.Transfer;

namespace Tomsoft.LuceedTransaction.Domain;

public interface ILuceedTransactionFetcher {
    Task<LuceedTransactionArticleResponse?> FetchLuceedArticleTransactions(LuceedTransactionRequest request);
    Task<LuceedTransactionPaymentResponse?> FetchLuceedPaymentTransactions(LuceedTransactionRequest request);
}
