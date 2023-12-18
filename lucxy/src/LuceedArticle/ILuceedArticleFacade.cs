using Lucxy.LuceedArticle.Transfer;

namespace Lucxy.LuceedArticle;

public interface ILuceedArticleFacade {
    public Task<LuceedArticleResponse?> FetchLuceedArticlesWhereNameLike(LuceedArticleRequest luceedArticleRequest);
}
