using Microsoft.Extensions.DependencyInjection;
using Lucxy.LuceedArticle;
using Lucxy.LuceedArticle.Domain;
using Lucxy.LuceedClient;
using Lucxy.LuceedTransaction;
using Lucxy.LuceedTransaction.Domain;
using lucxytest.LuceedClient;
using Lucxy.LuceedArticle.Persistence;
using lucxytest.LuceedTransaction;
using lucxytest.LuceedArticle;
using Lucxy.LuceedTransaction.Persistence;

namespace lucxytest;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // LuceedClient
        services.AddTransient<ILuceedClientFacade, LuceedClientFacadeMock>();

        // LuceedArticle
        services.AddTransient<ILuceedArticlePersistence, LuceedArticlePersistenceMock>();
        services.AddTransient<ILuceedArticleFetcher, LuceedArticleFetcher>();
        services.AddTransient<ILuceedArticleFacade, LuceedArticleFacade>();

        // LuceedTransaction
        services.AddTransient<ILuceedTransactionArticlePersistence, LuceedTransactionArticlePersistenceMock>();
        services.AddTransient<ILuceedTransactionPaymentPersistence, LuceedTransactionPaymentPersistenceMock>();
        services.AddTransient<ILuceedTransactionFetcher, LuceedTransactionFetcher>();
        services.AddTransient<ILuceedTransactionFacade, LuceedTransactionFacade>();
    }
}
