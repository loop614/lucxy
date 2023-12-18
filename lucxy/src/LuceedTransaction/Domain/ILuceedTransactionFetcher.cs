using Lucxy.LuceedTransaction.Transfer;

namespace Lucxy.LuceedTransaction.Domain;

public interface ILuceedTransactionFetcher {
    Task<LuceedTransactionArticleResponse?> FetchLuceedArticleTransactions(LuceedTransactionRequest request);
    Task<LuceedTransactionPaymentResponse?> FetchLuceedPaymentTransactions(LuceedTransactionRequest request);
}
