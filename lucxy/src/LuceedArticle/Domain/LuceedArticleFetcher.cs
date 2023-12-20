namespace Lucxy.LuceedArticle.Domain;

using System.Threading.Tasks;
using Newtonsoft.Json;
using Lucxy.LuceedArticle.Transfer;
using Lucxy.LuceedClient;
using Lucxy.LuceedArticle.Persistence;

public class LuceedArticleFetcher: ILuceedArticleFetcher
{
    private readonly ILuceedClientFacade _luceedClientFacade;
    private readonly ILuceedArticlePersistence _persistence;

    public LuceedArticleFetcher(
        ILuceedClientFacade luceedClientFacade,
        ILuceedArticlePersistence persistence
    ) {
        _luceedClientFacade = luceedClientFacade;
        _persistence = persistence;
    }

    public async Task<LuceedArticleResponse?> FetchLuceedArticlesWhereNameLike(LuceedArticleRequest luceedArticleRequest)
    {
        var uri = $"artikli/naziv/{luceedArticleRequest.Name}/[{luceedArticleRequest.From},{luceedArticleRequest.To}]";
        if (!LuceedArticleConfig.useDbCaching)
        {
            var responseBody = await _luceedClientFacade.Get(uri);
            return JsonConvert.DeserializeObject<LuceedArticleResponse>(responseBody);
        }

        return await ResolveLuceedArticleCache(uri);
    }

    private async Task<LuceedArticleResponse?> ResolveLuceedArticleCache(string uri)
    {
        var cachedResponseBody = _persistence.GetCachedResponseByRequest(uri);
        if (cachedResponseBody is null)
        {
            return await FetcheArticleAndUpdateCache(uri);
        }

        var cacheDuration = (new DateTime() - cachedResponseBody.createdAt).TotalMinutes;
        if (cacheDuration > LuceedArticleConfig.cachingMinutes)
        {
            _persistence.DeleteCachedResponse(cachedResponseBody.id);
            return await FetcheArticleAndUpdateCache(uri);
        }

        return JsonConvert.DeserializeObject<LuceedArticleResponse>(cachedResponseBody.response);
    }

    private async Task<LuceedArticleResponse?> FetcheArticleAndUpdateCache(string uri)
    {
        var responseBody = await _luceedClientFacade.Get(uri);
        _persistence.SaveCachedResponse(uri, responseBody);
        return JsonConvert.DeserializeObject<LuceedArticleResponse>(responseBody);
    }
}
