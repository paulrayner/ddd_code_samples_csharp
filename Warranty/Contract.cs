namespace Warranty;

/**
 * Contract represents an extended warranty for a covered product.
 * A contract is in a PENDING state prior to the effective date,
 * ACTIVE between effective and expiration dates, and EXPIRED after
 * the expiration date.
 */

public class Contract
{
    public enum Lifecycle { Pending, Active, Expired }

    public Guid Id { get; }

    public double PurchasePrice;

    public Lifecycle Status { get; set; }
    public Product CoveredProduct { get; set; }

    private List<Claim> Claims = new List<Claim>();

    public TermsAndConditions TermsAndConditions;

    public Contract(double purchasePrice, Product coveredProduct, TermsAndConditions termsAndConditions)
    {
        Id = Guid.NewGuid();
        Status = Lifecycle.Pending;
        PurchasePrice = purchasePrice;
        CoveredProduct = coveredProduct;
        TermsAndConditions = termsAndConditions;
    }

    public void Add(Claim claim)
    {
        Claims.Add(claim);
    }

    public List<Claim> GetClaims()
    {
        return Claims;
    }

    public bool Covers(Claim claim)
    {
        return InEffectFor(claim.FailureDate) &&
               WithinLimitOfLiability(claim.Amount);
    }

    public bool InEffectFor(DateTime failureDate)
    {
        return TermsAndConditions.Status(failureDate) == Lifecycle.Active &&
                Status == Lifecycle.Active;
    }

    public bool WithinLimitOfLiability(double claimAmount)
    {
        return claimAmount < RemainingLiability();
    }

    public double RemainingLiability() 
    {
        return TermsAndConditions.LimitOfLiability(PurchasePrice) - GetClaims().Sum(x => x.Amount);
    }
}
