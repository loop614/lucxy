using Lucxy.LuceedTransaction.Persistence;

namespace lucxytest.LuceedTransaction;

class LuceedTransactionArticlePersistenceMock : ILuceedTransactionArticlePersistence
{
    public string? GetCachedResponseByRequest(string uri)
    {
        return null;
    }

    public void SaveCachedResponse(string uri, string responseBody)
    {
    }
}
