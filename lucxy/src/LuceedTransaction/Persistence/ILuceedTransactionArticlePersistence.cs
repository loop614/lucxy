namespace Lucxy.LuceedTransaction.Persistence;

public interface ILuceedTransactionArticlePersistence
{
    public void SaveCachedResponse(string uri, string responseBody);

    public string? GetCachedResponseByRequest(string uri);
}
