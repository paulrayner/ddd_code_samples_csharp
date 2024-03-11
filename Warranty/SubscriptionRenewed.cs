namespace Warranty;

public class Event
{
    public DateTime OccurredAt {get; set;}
};

public class SubscriptionRenewed
{
    public DateTime OccurredAt;
    public Guid ContractId;
    public string Reason;

    public SubscriptionRenewed(Guid contractId, string reason)
    {
        ContractId = contractId;
        Reason = reason;
        OccurredAt = DateTime.Now;
    }
};
