using Lucxy.LuceedArticle;
using Lucxy.LuceedArticle.Domain;
using Lucxy.LuceedArticle.Persistence;
using Lucxy.LuceedClient;
using Lucxy.LuceedTransaction;
using Lucxy.LuceedTransaction.Domain;
using Lucxy.LuceedTransaction.Persistence;

namespace Lucxy.LucxyCore;

public class LucxyCoreConfig
{
    public static void AddServices(WebApplicationBuilder builder)
    {
        // LuceedClient
        builder.Services.AddSingleton<ILuceedGetter, LuceedGetter>();
        builder.Services.AddTransient<ILuceedClientFacade, LuceedClientFacade>();

        // LuceedTransaction
        builder.Services.AddTransient<ILuceedTransactionArticlePersistence, LuceedTransactionArticlePersistence>();
        builder.Services.AddTransient<ILuceedTransactionPaymentPersistence, LuceedTransactionPaymentPersistence>();
        builder.Services.AddTransient<ILuceedTransactionFetcher, LuceedTransactionFetcher>();
        builder.Services.AddTransient<ILuceedTransactionFacade, LuceedTransactionFacade>();

        // LuceedArticle
        builder.Services.AddTransient<ILuceedArticlePersistence, LuceedArticlePersistence>();
        builder.Services.AddTransient<ILuceedArticleFetcher, LuceedArticleFetcher>();
        builder.Services.AddTransient<ILuceedArticleFacade, LuceedArticleFacade>();
    }
}
