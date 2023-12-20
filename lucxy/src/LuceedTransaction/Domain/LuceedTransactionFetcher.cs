using Newtonsoft.Json;
using Lucxy.LuceedClient;
using Lucxy.LuceedTransaction.Transfer;
using Lucxy.LuceedTransaction.Persistence;

namespace Lucxy.LuceedTransaction.Domain;

public class LuceedTransactionFetcher: ILuceedTransactionFetcher
{
    private readonly ILuceedClientFacade _luceedClientFacade;

    private readonly ILuceedTransactionArticlePersistence _articlePersistence;

    private readonly ILuceedTransactionPaymentPersistence _paymentPersistence;

    public LuceedTransactionFetcher(
        ILuceedClientFacade luceedClientFacade,
        ILuceedTransactionArticlePersistence luceedTransactionArticlePersistence,
        ILuceedTransactionPaymentPersistence luceedTransactionPaymentPersistence
    ) {
        _luceedClientFacade = luceedClientFacade;
        _articlePersistence = luceedTransactionArticlePersistence;
        _paymentPersistence = luceedTransactionPaymentPersistence;
    }

    public async Task<LuceedTransactionArticleResponse?> FetchLuceedArticleTransactions(LuceedTransactionRequest request)
    {
        var uri = $"mpobracun/artikli/{request.PjUid}/{request.DateFrom.ToString("dd.MM.yyyy")}/{request.DateTo.ToString("dd.MM.yyyy")}";
        var cachedResponseBody = _articlePersistence.GetCachedResponseByRequest(uri);
        if (cachedResponseBody is null)
        {
            return await FetcheArticleAndUpdateCache(uri);
        }

        var cacheDuration = (new DateTime() - cachedResponseBody.createdAt).TotalMinutes;
        if (cacheDuration > LuceedTransactionConfig.cachingArticleMinutes)
        {
            _articlePersistence.DeleteCachedResponse(cachedResponseBody.id);
            return await FetcheArticleAndUpdateCache(uri);
        }

        return JsonConvert.DeserializeObject<LuceedTransactionArticleResponse>(cachedResponseBody.response);
    }

    public async Task<LuceedTransactionPaymentResponse?> FetchLuceedPaymentTransactions(LuceedTransactionRequest request)
    {
        var uri = $"mpobracun/placanja/{request.PjUid}/{request.DateFrom.ToString("dd.MM.yyyy")}/{request.DateTo.ToString("dd.MM.yyyy")}";
        var cachedResponseBody = _paymentPersistence.GetCachedResponseByRequest(uri);
        if (cachedResponseBody is null)
        {
            return await FetchePaymentAndUpdateCache(uri);
        }

        var cacheDuration = (new DateTime() - cachedResponseBody.createdAt).TotalMinutes;
        if (cacheDuration > LuceedTransactionConfig.cachingPaymentMinutes)
        {
            _articlePersistence.DeleteCachedResponse(cachedResponseBody.id);
            return await FetchePaymentAndUpdateCache(uri);
        }

        return JsonConvert.DeserializeObject<LuceedTransactionPaymentResponse>(cachedResponseBody.response);
    }

    private async Task<LuceedTransactionPaymentResponse?> FetchePaymentAndUpdateCache(string uri)
    {
        var responseBody = await _luceedClientFacade.Get(uri);
        _paymentPersistence.SaveCachedResponse(uri, responseBody);
        return JsonConvert.DeserializeObject<LuceedTransactionPaymentResponse>(responseBody);
    }

    private async Task<LuceedTransactionArticleResponse?> FetcheArticleAndUpdateCache(string uri)
    {
        var responseBody = await _luceedClientFacade.Get(uri);
        _articlePersistence.SaveCachedResponse(uri, responseBody);
        return JsonConvert.DeserializeObject<LuceedTransactionArticleResponse>(responseBody);
    }
}
