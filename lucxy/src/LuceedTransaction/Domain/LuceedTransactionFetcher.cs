using Newtonsoft.Json;
using Lucxy.LuceedClient;
using Lucxy.LuceedTransaction.Transfer;
using Lucxy.LuceedArticle.Persistence;

namespace Lucxy.LuceedTransaction.Domain;

public class LuceedTransactionFetcher: ILuceedTransactionFetcher {
    private readonly ILuceedClientFacade _luceedClientFacade;

    private readonly LuceedTransactionArticlePersistence _articlePersistence;
    private readonly LuceedTransactionPaymentPersistence _paymentPersistence;

    public LuceedTransactionFetcher(
        ILuceedClientFacade luceedClientFacade,
        LuceedTransactionArticlePersistence luceedTransactionArticlePersistence,
        LuceedTransactionPaymentPersistence luceedTransactionPaymentPersistence
    ) {
        _luceedClientFacade = luceedClientFacade;
        _articlePersistence = luceedTransactionArticlePersistence;
        _paymentPersistence = luceedTransactionPaymentPersistence;
    }

    public async Task<LuceedTransactionArticleResponse?> FetchLuceedArticleTransactions(LuceedTransactionRequest request)
    {
        var uri = $"mpobracun/artikli/{request.PjUid}/{request.DateFrom.ToString("dd.MM.yyyy")}/{request.DateTo.ToString("dd.MM.yyyy")}";
        var cachedResponseBody = _articlePersistence.GetCachedResponseByRequest(uri);
        if (cachedResponseBody is null) {
            var responseBody = await _luceedClientFacade.Get(uri);
            _articlePersistence.SaveCachedResponse(uri, responseBody);
            return JsonConvert.DeserializeObject<LuceedTransactionArticleResponse>(responseBody);
        }

        return JsonConvert.DeserializeObject<LuceedTransactionArticleResponse>(cachedResponseBody);
    }

    public async Task<LuceedTransactionPaymentResponse?> FetchLuceedPaymentTransactions(LuceedTransactionRequest request)
    {
        var uri = $"mpobracun/placanja/{request.PjUid}/{request.DateFrom.ToString("dd.MM.yyyy")}/{request.DateTo.ToString("dd.MM.yyyy")}";
        var cachedResponseBody = _paymentPersistence.GetCachedResponseByRequest(uri);
        if (cachedResponseBody is null) {
            var responseBody = await _luceedClientFacade.Get(uri);
            _paymentPersistence.SaveCachedResponse(uri, responseBody);
            return JsonConvert.DeserializeObject<LuceedTransactionPaymentResponse>(responseBody);
        }

        return JsonConvert.DeserializeObject<LuceedTransactionPaymentResponse>(cachedResponseBody);
    }
}
