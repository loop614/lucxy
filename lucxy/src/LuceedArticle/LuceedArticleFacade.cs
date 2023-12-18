using Lucxy.LuceedArticle.Domain;
using Lucxy.LuceedArticle.Transfer;

namespace Lucxy.LuceedArticle;

public class LuceedArticleFacade : ILuceedArticleFacade {
    private readonly ILuceedArticleFetcher _articleFetcher;
    public LuceedArticleFacade(ILuceedArticleFetcher articleFetcher) {
        _articleFetcher = articleFetcher;
    }

    public Task<LuceedArticleResponse?> FetchLuceedArticlesWhereNameLike(LuceedArticleRequest luceedArticleRequest) {
        return _articleFetcher.FetchLuceedArticlesWhereNameLike(luceedArticleRequest);
    }
}
