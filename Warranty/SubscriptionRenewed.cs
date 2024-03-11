namespace Warranty;

public record Event() 
{
    public readonly DateTime OccuredAt = DateTime.Now;
};

public sealed record SubscriptionRenewed(Guid ContractId, string Reason) : Event
{
};
