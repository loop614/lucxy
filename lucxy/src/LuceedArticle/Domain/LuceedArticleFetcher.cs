using Newtonsoft.Json;
using Lucxy.LuceedArticle.Transfer;
using Lucxy.LuceedClient;
using Lucxy.LuceedArticle.Persistence;

namespace Lucxy.LuceedArticle.Domain;

public class LuceedArticleFetcher(ILuceedClientFacade luceedClientFacade, ILuceedArticlePersistence persistence) : ILuceedArticleFetcher
{
    public async Task<LuceedArticleResponse?> FetchLuceedArticlesWhereNameLike(LuceedArticleRequest luceedArticleRequest)
    {
        var uri = $"artikli/naziv/{luceedArticleRequest.Name}/[{luceedArticleRequest.From},{luceedArticleRequest.To}]";
        if (!LuceedArticleConfig.useDbCaching)
        {
            var responseBody = await luceedClientFacade.Get(uri);
            return JsonConvert.DeserializeObject<LuceedArticleResponse>(responseBody);
        }

        return await ResolveLuceedArticleCache(uri);
    }

    private async Task<LuceedArticleResponse?> ResolveLuceedArticleCache(string uri)
    {
        var cachedResponseBody = persistence.GetCachedResponseByRequest(uri);
        if (cachedResponseBody is null)
        {
            return await FetcheArticleAndUpdateCache(uri);
        }

        var cacheDuration = (new DateTime() - cachedResponseBody.createdAt).TotalMinutes;
        if (cacheDuration > LuceedArticleConfig.cachingMinutes)
        {
            persistence.DeleteCachedResponse(cachedResponseBody.id);
            return await FetcheArticleAndUpdateCache(uri);
        }

        return JsonConvert.DeserializeObject<LuceedArticleResponse>(cachedResponseBody.response);
    }

    private async Task<LuceedArticleResponse?> FetcheArticleAndUpdateCache(string uri)
    {
        var responseBody = await luceedClientFacade.Get(uri);
        persistence.SaveCachedResponse(uri, responseBody);
        return JsonConvert.DeserializeObject<LuceedArticleResponse>(responseBody);
    }
}
