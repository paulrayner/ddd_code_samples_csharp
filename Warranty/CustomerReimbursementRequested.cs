namespace Warranty;

public class CustomerReimbursementRequested
{
    public Guid ContractId;
    public DateTime OccurredAt;
    public string RepName;
    public string Reason;
    
    public CustomerReimbursementRequested(Guid contractId, string repName, string reason)
    {
        ContractId = contractId;
        RepName = repName;
        Reason  = reason;
        OccurredAt = DateTime.Now;
    }
}