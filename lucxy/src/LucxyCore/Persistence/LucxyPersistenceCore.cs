using Npgsql;

namespace Lucxy.LucxyCore.Persistence;

public class LucxyCorePersistence {
    protected NpgsqlConnection _connection;
    public LucxyCorePersistence(NpgsqlConnection connection) {
        _connection = connection;
    }
}
