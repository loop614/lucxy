namespace Lucxy.LuceedArticle.Domain;

using System.Threading.Tasks;
using Newtonsoft.Json;
using Lucxy.LuceedArticle.Transfer;
using Lucxy.LuceedClient;

public class LuceedArticleFetcher: ILuceedArticleFetcher {
    private readonly ILuceedClientFacade _luceedClientFacade;

    public LuceedArticleFetcher(ILuceedClientFacade luceedClientFacade)
    {
        _luceedClientFacade = luceedClientFacade;
    }

    public async Task<LuceedArticleResponse?> FetchLuceedArticlesWhereNameLike(LuceedArticleRequest luceedArticleRequest)
    {
        var uri = $"artikli/naziv/{luceedArticleRequest.Name}/[{luceedArticleRequest.From},{luceedArticleRequest.To}]";
        var responseBody = await _luceedClientFacade.Get(uri);

        return JsonConvert.DeserializeObject<LuceedArticleResponse>(responseBody);
    }
}
