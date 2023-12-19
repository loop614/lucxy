using Lucxy.LuceedTransaction.Persistence;

namespace lucxytest.LuceedTransaction;

class LuceedTransactionPaymentPersistenceMock : ILuceedTransactionPaymentPersistence
{
    public string? GetCachedResponseByRequest(string uri)
    {
        return null;
    }

    public void SaveCachedResponse(string uri, string responseBody)
    {
    }
}