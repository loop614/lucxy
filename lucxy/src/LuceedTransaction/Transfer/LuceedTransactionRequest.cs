namespace Tomsoft.LuceedTransaction;

public class LuceedTransactionRequest {
    public string? PjUid { get; set; }

    public DateTime? DateFrom { get; set; }

    public DateTime? DateTo { get; set; }

    public LuceedTransactionRequest(string? pjUid, DateTime? dateFrom, DateTime? dateTo) {
        PjUid = pjUid;
        DateFrom = dateFrom;
        DateTo = dateTo;
    }
}
