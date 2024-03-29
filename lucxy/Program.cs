using System.Net.Http.Headers;
using Npgsql;
using Lucxy.LucxyCore.Persistence;
using Lucxy.LucxyCore.Transfer;
using Lucxy.LucxyCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var settingsLuceed = builder.Configuration.GetSection("Luceed").Get<LucxyLuceedSettings>();
if (settingsLuceed is null) {
    Console.WriteLine("Error: Could not load luceed settings");
    return;
}

var settingsSql = builder.Configuration.GetSection("Sql").Get<LucxySqlSettings>();
if (settingsSql is null) {
    Console.WriteLine("Error: Could not load sql settings");
    return;
}

if (settingsSql.DbCaching) {
    var sqlConnection = new NpgsqlConnection(settingsSql.ConnectionString);
    sqlConnection.Open();
    if (sqlConnection.State != System.Data.ConnectionState.Open) {
        Console.WriteLine("Error: Could not connect to sqlpostgres");
        return;
    }
    await LucxyCoreDatabaseInit.InitTables(sqlConnection);
}

var authenticationString = $"{settingsLuceed.Username}:{settingsLuceed.Password}";
var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));
builder.Services.AddHttpClient("Luceed", httpClient =>
{
    httpClient.BaseAddress = new Uri(settingsLuceed.BaseUrl);
    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
});

LucxyCoreConfig.AddServices(builder);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
