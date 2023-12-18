namespace Lucxy.LuceedClient;

public interface ILuceedGetter
{
    public Task<String> Get(String uri);
}
