namespace Tomsoft.LuceedArticle.Controller;

using Microsoft.AspNetCore.Mvc;

[Route("luceed/article")]
[ApiController]
public class LuceedArticleController : ControllerBase
{
    private readonly ILuceedArticleFacade _facade;

    public LuceedArticleController(ILuceedArticleFacade facade)
    {
        _facade = facade;
    }

    [Route("{name}")]
    public async Task<IActionResult> Article (String name) {
        var articles = await _facade.GetLuceedArticlesWhereNameLike(name);
        return Ok(articles);
    }
}
