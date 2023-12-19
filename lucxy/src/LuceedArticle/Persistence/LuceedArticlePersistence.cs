using Dapper;
using Npgsql;
using Lucxy.LucxyCore.Persistence;
using Lucxy.LucxyCore.Model;

namespace Lucxy.LuceedArticle.Persistence;

public class LuceedArticlePersistence : LucxyCorePersistence {
    public LuceedArticlePersistence(IConfiguration config) : base(config)
    {
    }

    public void SaveCachedResponse(string uri, string responseBody) {
        const string sql = @"INSERT INTO luceed_article_cache (request, response, created_at) VALUES (@request, @response, @created_at)";
        var parameters = new { request = uri, response = responseBody, created_at = new DateTime() };
        _connection.Query<string>(sql, parameters);
    }

    public string? GetCachedResponseByRequest(string uri) {
        const string sql = @"SELECT * FROM luceed_article_cache WHERE request = @request LIMIT 1";
        var parameters = new { request = uri };
        var response = _connection.Query<LuceedRequestResponseCache>(sql, parameters);
        var firstResponse = response.FirstOrDefault();
        if (firstResponse is null) {
            return null;
        }

        var cacheHours = (new DateTime() - firstResponse.createdAt).TotalHours;
        if (cacheHours > 1) {
            DeleteCachedResponse(firstResponse.id);
            return null;
        }

        return firstResponse.response;
    }

    private void DeleteCachedResponse(long id) {
        const string sql = @"DELETE FROM luceed_article_cache WHERE id = @id";
        var parameters = new { id };
        _connection.Execute(sql, parameters);
    }
}
