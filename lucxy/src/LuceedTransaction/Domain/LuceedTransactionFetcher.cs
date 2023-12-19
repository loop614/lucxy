using Newtonsoft.Json;
using Lucxy.LuceedClient;
using Lucxy.LuceedTransaction.Transfer;

namespace Lucxy.LuceedTransaction.Domain;

public class LuceedTransactionFetcher: ILuceedTransactionFetcher {
    private readonly ILuceedClientFacade _luceedClientFacade;

    public LuceedTransactionFetcher(ILuceedClientFacade luceedClientFacade)
    {
        _luceedClientFacade = luceedClientFacade;
    }

    public async Task<LuceedTransactionArticleResponse?> FetchLuceedArticleTransactions(LuceedTransactionRequest request)
    {
        var uri = $"mpobracun/artikli/{request.PjUid}/{request.DateFrom.ToString("dd.MM.yyyy")}/{request.DateTo.ToString("dd.MM.yyyy")}";
        var responseBody = await _luceedClientFacade.Get(uri);

        return JsonConvert.DeserializeObject<LuceedTransactionArticleResponse>(responseBody);
    }

    public async Task<LuceedTransactionPaymentResponse?> FetchLuceedPaymentTransactions(LuceedTransactionRequest request)
    {
        var uri = $"mpobracun/placanja/{request.PjUid}/{request.DateFrom.ToString("dd.MM.yyyy")}/{request.DateTo.ToString("dd.MM.yyyy")}";
        var responseBody = await _luceedClientFacade.Get(uri);

        return JsonConvert.DeserializeObject<LuceedTransactionPaymentResponse>(responseBody);
    }
}
