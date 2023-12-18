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
        string DateFrom = request.DateFrom.Day + "." + request.DateFrom.Month + "." + request.DateFrom.Year;
        string DateTo = request.DateTo.Day + "." + request.DateTo.Month + "." + request.DateTo.Year;
        var uri = $"mpobracun/artikli/{request.PjUid}/{DateFrom}/{DateTo}";
        var responseBody = await _luceedClientFacade.Get(uri);

        return JsonConvert.DeserializeObject<LuceedTransactionArticleResponse>(responseBody);
    }

    public async Task<LuceedTransactionPaymentResponse?> FetchLuceedPaymentTransactions(LuceedTransactionRequest request)
    {
        string DateFrom = request.DateFrom.Day + "." + request.DateFrom.Month + "." + request.DateFrom.Year;
        string DateTo = request.DateTo.Day + "." + request.DateTo.Month + "." + request.DateTo.Year;
        var uri = $"mpobracun/artikli/{request.PjUid}/{DateFrom}/{DateTo}";
        var responseBody = await _luceedClientFacade.Get(uri);

        return JsonConvert.DeserializeObject<LuceedTransactionPaymentResponse>(responseBody);
    }
}
