using Lucxy.LuceedArticle.Persistence;
using Lucxy.LucxyCore.Model;

namespace lucxytest.LuceedArticle;

class LuceedArticlePersistenceMock : ILuceedArticlePersistence
{
    public LuceedRequestResponseCache? GetCachedResponseByRequest(string uri)
    {
        return null;
    }

    public void SaveCachedResponse(string uri, string responseBody)
    {
    }

    public void DeleteCachedResponse(long id)
    {
    }
}
