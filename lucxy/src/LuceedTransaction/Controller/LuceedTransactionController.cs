using Microsoft.AspNetCore.Mvc;
using Lucxy.LuceedTransaction.Transfer;

namespace Lucxy.LuceedTransaction.Controller;

[Route("luceed/transaction")]
[ApiController]
public class LuceedTransactionCalculationController : ControllerBase
{
    private readonly ILuceedTransactionFacade _facade;

    public LuceedTransactionCalculationController(ILuceedTransactionFacade facade)
    {
        _facade = facade;
    }

    [Route("payment/{pj_uid}/{date_from}/{date_to}")]
    public async Task<IActionResult> Payment (String pj_uid, String date_from, String date_to) {
        var luceedTransactionRequest = new LuceedTransactionRequest(pj_uid, DateOnly.Parse(date_from), DateOnly.Parse(date_to));
        var paymentCalculations = await _facade.FetchLuceedPaymentTransactions(luceedTransactionRequest);

        return Ok(paymentCalculations);
    }

    [Route("article/{pj_uid}/{date_from}/{date_to}")]
    public async Task<IActionResult> Article (String pj_uid, String date_from, String date_to) {
        var luceedTransactionRequest = new LuceedTransactionRequest(pj_uid, DateOnly.Parse(date_from), DateOnly.Parse(date_to));
        var articleCalculations = await _facade.FetchLuceedArticleTransactions(luceedTransactionRequest);

        return Ok(articleCalculations);
    }
}
