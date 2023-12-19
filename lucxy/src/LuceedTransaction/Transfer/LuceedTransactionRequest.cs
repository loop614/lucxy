namespace Lucxy.LuceedTransaction.Transfer;

public class LuceedTransactionRequest
{
    public string PjUid { get; set; }

    public DateOnly DateFrom { get; set; }

    public DateOnly DateTo { get; set; }

    public LuceedTransactionRequest(string pjUid, DateOnly dateFrom, DateOnly dateTo) {
        PjUid = pjUid;
        DateFrom = dateFrom;
        DateTo = dateTo;
    }
}
