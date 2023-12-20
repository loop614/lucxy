using Lucxy.LuceedTransaction.Persistence;
using Lucxy.LucxyCore.Model;

namespace lucxytest.LuceedTransaction;

class LuceedTransactionPaymentPersistenceMock : ILuceedTransactionPaymentPersistence
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
