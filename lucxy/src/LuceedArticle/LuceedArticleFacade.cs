using Lucxy.LuceedArticle.Domain;
using Lucxy.LuceedArticle.Transfer;

namespace Lucxy.LuceedArticle;

public class LuceedArticleFacade(ILuceedArticleFetcher articleFetcher) : ILuceedArticleFacade
{
    public Task<LuceedArticleResponse?> FetchLuceedArticlesWhereNameLike(LuceedArticleRequest luceedArticleRequest)
    {
        return articleFetcher.FetchLuceedArticlesWhereNameLike(luceedArticleRequest);
    }
}
