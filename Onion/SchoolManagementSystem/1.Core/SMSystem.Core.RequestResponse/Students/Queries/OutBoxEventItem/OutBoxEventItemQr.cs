namespace SMSystem.Core.RequestResponse.Students.Queries.OutBoxEventItemQr;

public class OutBoxEventItemQr
{
    public long OutBoxEventItemId { get; set; }
    public DateTime AccuredOn { get; set; }
    public string? AggregateName { get; set; }
    public string? EventName { get; set; }

}
