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
        luceedArticleResponse.EnsureSuccessStatusCode();

        return await luceedArticleResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
    }
}
