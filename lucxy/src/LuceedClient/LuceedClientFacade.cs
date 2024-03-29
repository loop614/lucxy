namespace Lucxy.LuceedClient;

public class LuceedClientFacade(ILuceedGetter luceedClientGetter) : ILuceedClientFacade
{
    public Task<String> Get(String uri)
    {
        return luceedClientGetter.Get(uri);
    }
}
