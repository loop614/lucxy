using Tomsoft.LuceedClient.Transfer;

namespace Tomsoft.LuceedArticle;

public interface ILuceedArticleFacade {
    public Task<LuceedArticleResponse?> GetLuceedArticlesWhereNameLike(String name);
}
