namespace Tomsoft.LuceedClient;

public interface ILuceedClientFacade {
    public Task<String> Get(String uri);
}
