namespace Tomsoft.LuceedClient;

public class LuceedClientFacade : ILuceedClientFacade {
    private readonly ILuceedGetter _luceedClientGetter;
    public LuceedClientFacade(ILuceedGetter luceedClientGetter) {
        _luceedClientGetter = luceedClientGetter;
    }

    public Task<String> Get(String uri) {
        return _luceedClientGetter.Get(uri);
    }
}
