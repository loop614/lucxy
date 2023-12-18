namespace Tomsoft.LuceedArticle.Domain;

using System.Threading.Tasks;
using Newtonsoft.Json;
using Tomsoft.LuceedClient;
using Tomsoft.LuceedClient.Transfer;

class LuceedArticleFetcher: ILuceedArticleFetcher {
    private readonly ILuceedClientFacade _luceedClientFacade;

    private readonly IConfiguration _configuration;

    public LuceedArticleFetcher(ILuceedClientFacade luceedClientFacade, IConfiguration configuration)
    {
        _luceedClientFacade = luceedClientFacade;
        _configuration = configuration;
    }

    public async Task<LuceedArticleResponse?> FetchLuceedArticlesWhereNameLike(string name)
    {
        var uri = $"artikli/naziv/{name}/[0,10]";
        var responseBody = await _luceedClientFacade.Get(uri);

        return JsonConvert.DeserializeObject<LuceedArticleResponse>(responseBody);
    }
}
