using Microsoft.AspNetCore.Mvc;
using Lucxy.LuceedArticle.Transfer;

namespace Lucxy.LuceedArticle.Controller;

[Route("luceed/article")]
[ApiController]
public class LuceedArticleController(ILuceedArticleFacade facade) : ControllerBase
{
    [Route("{name}/{from}/{to}")]
    public async Task<IActionResult> Article(String name, int from, int to)
    {
        LuceedArticleRequest luceedArticleRequest = new(name, from, to);
        var articles = await facade.FetchLuceedArticlesWhereNameLike(luceedArticleRequest);

        return Ok(articles);
    }
}
