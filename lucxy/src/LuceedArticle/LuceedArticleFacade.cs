using Tomsoft.LuceedArticle.Domain;
using Tomsoft.LuceedClient.Transfer;

namespace Tomsoft.LuceedArticle;

public class LuceedArticleFacade : ILuceedArticleFacade {
    private readonly ILuceedArticleFetcher _articleFetcher;
    public LuceedArticleFacade(ILuceedArticleFetcher articleFetcher) {
        _articleFetcher = articleFetcher;
    }

    public Task<LuceedArticleResponse?> GetLuceedArticlesWhereNameLike(String name) {
        return _articleFetcher.FetchLuceedArticlesWhereNameLike(name);
    }
}
