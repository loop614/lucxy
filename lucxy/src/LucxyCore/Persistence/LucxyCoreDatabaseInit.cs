using Dapper;
using Npgsql;

namespace Lucxy.LucxyCore.Persistence;

class LucxyCoreDatabaseInit {

    public async static Task InitTables(NpgsqlConnection con) {
        var sql = """
            CREATE TABLE IF NOT EXISTS
            luceed_article_cache (
                id serial PRIMARY KEY,
                request VARCHAR (255),
                response TEXT,
                created_at DATE
            );
            CREATE INDEX  IF NOT EXISTS idx_request_luceed_article ON luceed_article_cache(request);

            CREATE TABLE IF NOT EXISTS
            luceed_transaction_payment_cache (
                id serial PRIMARY KEY,
                request VARCHAR (255),
                response TEXT,
                created_at DATE
            );
            CREATE INDEX IF NOT EXISTS idx_request_luceed_transaction_payment ON luceed_transaction_payment_cache(request);

            CREATE TABLE IF NOT EXISTS
            luceed_transaction_article_cache (
                id serial PRIMARY KEY,
                request VARCHAR (255),
                response TEXT,
                created_at DATE
            );
            CREATE INDEX IF NOT EXISTS idx_request_luceed_transaction_article ON luceed_transaction_article_cache(request);
        """;

        await con.ExecuteAsync(sql);
    }
}
