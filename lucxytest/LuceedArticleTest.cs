using Lucxy.LuceedArticle;
using Lucxy.LuceedArticle.Transfer;

namespace lucxytest;

public class LuceedArticleTest
{
    private readonly ILuceedArticleFacade _luceedArticleFacade;

    public LuceedArticleTest(ILuceedArticleFacade luceedArticleFacade) => _luceedArticleFacade = luceedArticleFacade;

    [Fact]
    public async void FetchLuceedArticlesWhereNameLike()
    {
        LuceedArticleRequest luceedArticleRequest = new("pri", 0, 10);
        LuceedArticleResponse? response = await _luceedArticleFacade.FetchLuceedArticlesWhereNameLike(luceedArticleRequest);
        Assert.NotNull(response);
    }
}
