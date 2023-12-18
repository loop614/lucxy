using Microsoft.AspNetCore.Mvc;

namespace Lucxy.LuceedClient;

public class LuceedGetter : ILuceedGetter
{
    private readonly IHttpClientFactory _httpClientFactory;

    public LuceedGetter(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<String> Get(String uri) {
        HttpClient client = _httpClientFactory.CreateClient("Luceed");
        HttpResponseMessage luceedArticleResponse = await client.GetAsync(uri);

        Console.WriteLine(client.BaseAddress);
        Console.WriteLine(uri);
        Console.WriteLine(client.DefaultRequestHeaders.Authorization);
        Console.WriteLine(luceedArticleResponse.StatusCode);

        if (!luceedArticleResponse.IsSuccessStatusCode) {
            throw new HttpRequestException();
        }
        luceedArticleResponse.EnsureSuccessStatusCode();

        return await luceedArticleResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
    }
}
