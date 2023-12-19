namespace Lucxy.LuceedArticle.Domain;

using System.Threading.Tasks;
using Newtonsoft.Json;
using Lucxy.LuceedArticle.Transfer;
using Lucxy.LuceedClient;
using Lucxy.LuceedArticle.Persistence;

public class LuceedArticleFetcher: ILuceedArticleFetcher {
    private readonly ILuceedClientFacade _luceedClientFacade;
    private readonly LuceedArticlePersistence _persistence;

    public LuceedArticleFetcher(
        ILuceedClientFacade luceedClientFacade,
        LuceedArticlePersistence persistence
    ) {
        _luceedClientFacade = luceedClientFacade;
        _persistence = persistence;
    }

    public async Task<LuceedArticleResponse?> FetchLuceedArticlesWhereNameLike(LuceedArticleRequest luceedArticleRequest)
    {
        var uri = $"artikli/naziv/{luceedArticleRequest.Name}/[{luceedArticleRequest.From},{luceedArticleRequest.To}]";
        var cachedResponseBody = _persistence.GetCachedResponseByRequest(uri);
        if (cachedResponseBody is null) {
            var responseBody = await _luceedClientFacade.Get(uri);
            _persistence.SaveCachedResponse(uri, responseBody);
            return JsonConvert.DeserializeObject<LuceedArticleResponse>(responseBody);
        }

        return JsonConvert.DeserializeObject<LuceedArticleResponse>(cachedResponseBody);
    }
}
