namespace Lucxy.LuceedArticle.Persistence;

public interface ILuceedArticlePersistence
{
    public void SaveCachedResponse(string uri, string responseBody);

    public string? GetCachedResponseByRequest(string uri);
}
