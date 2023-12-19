namespace Lucxy.LuceedTransaction.Persistence;

public interface ILuceedTransactionPaymentPersistence
{

    public void SaveCachedResponse(string uri, string responseBody);

    public string? GetCachedResponseByRequest(string uri);
}
