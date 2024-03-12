namespace Warranty;

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
