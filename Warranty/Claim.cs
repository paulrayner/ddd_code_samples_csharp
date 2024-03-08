namespace Warranty;

public class Claim {

    /**
     * Claim represents a request for a benefit on an extended warranty. It contains a
     * set of purchase orders that provide information about any repairs and associated 
     * costs that may have occurred for a claim.
     */

    public double Amount;

    public Guid Id { get; }
    public DateTime FailureDate { get; set; }

    public List<RepairPO> RepairPO = new List<RepairPO>();

    public Claim(double amount, DateTime failureDate)
    {
        Id = Guid.NewGuid();
        Amount = amount;
        FailureDate = failureDate;
    }
}
