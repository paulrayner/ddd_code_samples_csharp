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

    public DateTime PurchaseDate { get; }
    public DateTime EffectiveDate { get; }
    public DateTime ExpirationDate { get; }
    public Lifecycle Status { get; set; }
    public Product CoveredProduct { get; set; }

    private List<Claim> Claims = new List<Claim>();

    public Contract(double purchasePrice, Product coveredProduct, DateTime purchaseDate, DateTime effectiveDate, DateTime expirationDate)
    {
        Id = Guid.NewGuid();
        Status = Lifecycle.Pending;
        PurchasePrice = purchasePrice;
        CoveredProduct = coveredProduct;
        PurchaseDate = purchaseDate;
        EffectiveDate = effectiveDate;
        ExpirationDate = expirationDate;
    }

    public void Add(Claim claim)
    {
        Claims.Add(claim);
    }

    public List<Claim> GetClaims()
    {
        return Claims;
    }
}
