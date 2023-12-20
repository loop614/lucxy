using Lucxy.LucxyCore.Model;

namespace Lucxy.LuceedTransaction.Persistence;

public interface ILuceedTransactionArticlePersistence
{
    public void SaveCachedResponse(string uri, string responseBody);

    public LuceedRequestResponseCache? GetCachedResponseByRequest(string uri);

    public void DeleteCachedResponse(long id);
}
