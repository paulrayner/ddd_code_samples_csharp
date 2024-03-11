namespace Warranty;

public sealed record SubscriptionRenewed(Guid ContractId, string Reason)
{
    internal readonly DateTime OccuredAt = new DateTime();
};
