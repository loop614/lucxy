using Tomsoft.LuceedClient.Transfer;

namespace Tomsoft.LuceedArticle.Domain;

public interface ILuceedArticleFetcher {
    Task<LuceedArticleResponse?> FetchLuceedArticlesWhereNameLike(String name);
}
