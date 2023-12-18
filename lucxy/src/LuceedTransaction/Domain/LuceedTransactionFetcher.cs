using Newtonsoft.Json;
using Tomsoft.LuceedClient;
using Tomsoft.LuceedClient.Transfer;

namespace Tomsoft.LuceedTransaction.Domain;

class LuceedTransactionFetcher: ILuceedTransactionFetcher {
    private readonly ILuceedClientFacade _luceedClientFacade;

    public LuceedTransactionFetcher(ILuceedClientFacade luceedClientFacade)
    {
        _luceedClientFacade = luceedClientFacade;
    }

    public async Task<LuceedTransactionArticleResponse?> FetchLuceedArticleTransactions(LuceedTransactionRequest request)
    {
        var uri = $"{request.PjUid}/{request.DateFrom}/{request.DateTo}";
        var responseBody = await _luceedClientFacade.Get(uri);

        return JsonConvert.DeserializeObject<LuceedTransactionArticleResponse>(responseBody);
    }

    public async Task<LuceedTransactionPaymentResponse?> FetchLuceedPaymentTransactions(LuceedTransactionRequest request)
    {
        var uri = $"{request.PjUid}/{request.DateFrom}/{request.DateTo}";
        var responseBody = await _luceedClientFacade.Get(uri);

        return JsonConvert.DeserializeObject<LuceedTransactionPaymentResponse>(responseBody);
    }
}
