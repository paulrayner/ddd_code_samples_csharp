namespace Warranty;

public sealed record SubscriptionRenewed(Guid ContractId, string Reason)
{
    public readonly DateTime OccuredAt = DateTime.Now;
};
