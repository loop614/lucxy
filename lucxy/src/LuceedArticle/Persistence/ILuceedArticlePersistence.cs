using Lucxy.LucxyCore.Model;

namespace Lucxy.LuceedArticle.Persistence;

public interface ILuceedArticlePersistence
{
    public void SaveCachedResponse(string uri, string responseBody);

    public LuceedRequestResponseCache? GetCachedResponseByRequest(string uri);

    public void DeleteCachedResponse(long id);
}
