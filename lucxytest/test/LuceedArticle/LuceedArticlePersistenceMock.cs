using Lucxy.LuceedArticle.Persistence;

namespace lucxytest.LuceedArticle;

class LuceedArticlePersistenceMock : ILuceedArticlePersistence
{
    public string? GetCachedResponseByRequest(string uri)
    {
        return null;
    }

    public void SaveCachedResponse(string uri, string responseBody)
    {
    }
}
