using System.Net.Http.Headers;
using Lucxy.LuceedArticle;
using Lucxy.LuceedArticle.Domain;
using Lucxy.LuceedClient;
using Lucxy.LuceedTransaction;
using Lucxy.LuceedTransaction.Domain;
using Lucxy.LucxyCore.Transfer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var settings = builder.Configuration.GetSection("Luceed").Get<LucxyAppSettings>();
if (settings is null) {
    Console.WriteLine("Error: Could not load settings");
    return;
}

var authenticationString = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{settings.Username}:{settings.Password}"));
builder.Services.AddHttpClient("Luceed", httpClient =>
{
    httpClient.BaseAddress = new Uri(settings.BaseUrl);
    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authenticationString);
});

// LuceedClient
builder.Services.AddSingleton<ILuceedGetter, LuceedGetter>();
builder.Services.AddTransient<ILuceedClientFacade, LuceedClientFacade>();

// LuceedArticle
builder.Services.AddTransient<ILuceedArticleFetcher, LuceedArticleFetcher>();
builder.Services.AddTransient<ILuceedArticleFacade, LuceedArticleFacade>();

// LuceedTransaction
builder.Services.AddTransient<ILuceedTransactionFetcher, LuceedTransactionFetcher>();
builder.Services.AddTransient<ILuceedTransactionFacade, LuceedTransactionFacade>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
