namespace Warranty;

public class Claim {

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
