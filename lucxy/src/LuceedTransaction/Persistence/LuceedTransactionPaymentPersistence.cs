using Dapper;
using Lucxy.LucxyCore.Persistence;
using Lucxy.LucxyCore.Model;

namespace Lucxy.LuceedTransaction.Persistence;

public class LuceedTransactionPaymentPersistence(IConfiguration config) : LucxyCorePersistence(config), ILuceedTransactionPaymentPersistence
{
    public void SaveCachedResponse(string uri, string responseBody)
    {
        const string sql = @"INSERT INTO luceed_transaction_payment_cache (request, response, created_at) VALUES (@request, @response, @created_at)";
        var parameters = new { request = uri, response = responseBody, created_at = new DateTime() };
        _connection.Query<string>(sql, parameters);
    }

    public LuceedRequestResponseCache? GetCachedResponseByRequest(string uri)
    {
        const string sql = @"SELECT * FROM luceed_transaction_payment_cache WHERE request = @request LIMIT 1";
        var parameters = new { request = uri };
        var response = _connection.Query<LuceedRequestResponseCache>(sql, parameters);
        var firstResponse = response.FirstOrDefault();
        if (firstResponse is null) {
            return null;
        }

        return firstResponse;
    }

    public void DeleteCachedResponse(long id)
    {
        const string sql = @"DELETE FROM luceed_transaction_payment_cache WHERE id = @id";
        var parameters = new { id };
        _connection.Execute(sql, parameters);
    }
}
