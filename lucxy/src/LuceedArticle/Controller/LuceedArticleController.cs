namespace Lucxy.LuceedArticle.Controller;

using Microsoft.AspNetCore.Mvc;
using Lucxy.LuceedArticle.Transfer;

[Route("luceed/article")]
[ApiController]
public class LuceedArticleController : ControllerBase
{
    private readonly ILuceedArticleFacade _facade;

    public LuceedArticleController(ILuceedArticleFacade facade)
    {
        _facade = facade;
    }

    [Route("{name}/{from}/{to}")]
    public async Task<IActionResult> Article (String name, int from, int to) {
        LuceedArticleRequest luceedArticleRequest = new(name, from, to);
        var articles = await _facade.FetchLuceedArticlesWhereNameLike(luceedArticleRequest);

        return Ok(articles);
    }
}
