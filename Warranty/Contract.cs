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

    public void add(Claim claim)
    {
        Claims.Add(claim);
    }

    public List<Claim> getClaims()
    {
        return Claims;
    }

    public bool covers(Claim claim)
    {
        return inEffectFor(claim.FailureDate) &&
               withinLimitOfLiability(claim.Amount);
    }

    public bool inEffectFor(DateTime failureDate)
    {
        return TermsAndConditions.status(failureDate) == Lifecycle.Active &&
                Status == Lifecycle.Active;
    }

    public bool withinLimitOfLiability(double claimAmount)
    {
        return claimAmount < remainingLiability();
    }

    public double remainingLiability() 
    {
        return TermsAndConditions.limitOfLiability(PurchasePrice) - claimTotal();
    }

    public double claimTotal() 
    {
        return getClaims().Sum(x => x.Amount);
    }
}
