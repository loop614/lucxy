using Npgsql;
using Lucxy.LucxyCore.Transfer;

namespace Lucxy.LucxyCore.Persistence;

public class LucxyCorePersistence
{
    protected NpgsqlConnection _connection;
    public LucxyCorePersistence(IConfiguration config)
    {
        var settingsSql = config.GetSection("Sql").Get<LucxySqlSettings>();
        if (settingsSql is null) {
            Console.WriteLine("Error: Could not load sql settings");
        }
        _connection = new NpgsqlConnection(settingsSql?.ConnectionString);
    }
}
