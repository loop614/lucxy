using Lucxy.LuceedArticle.Transfer;

namespace Lucxy.LuceedArticle.Domain;

public interface ILuceedArticleFetcher
{
    Task<LuceedArticleResponse?> FetchLuceedArticlesWhereNameLike(LuceedArticleRequest luceedArticleRequest);
}
