using Microsoft.Extensions.DependencyInjection;
using Lucxy.LuceedArticle;
using Lucxy.LuceedArticle.Domain;
using Lucxy.LuceedClient;
using Lucxy.LuceedTransaction;
using Lucxy.LuceedTransaction.Domain;
using lucxytest.LuceedClient;

namespace lucxytest;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<ILuceedClientFacade, LuceedClientFacadeMock>();

        // LuceedArticle
        services.AddTransient<ILuceedArticleFetcher, LuceedArticleFetcher>();
        services.AddTransient<ILuceedArticleFacade, LuceedArticleFacade>();

        // LuceedTransaction
        services.AddTransient<ILuceedTransactionFetcher, LuceedTransactionFetcher>();
        services.AddTransient<ILuceedTransactionFacade, LuceedTransactionFacade>();
    }
}
