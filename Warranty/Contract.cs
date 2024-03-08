using System.Runtime.ConstrainedExecution;

namespace Warranty;

public class Contract
{
    public enum Lifecycle { Pending, Active, Expired }

    public double PurchasePrice;

    public DateTime PurchaseDate { get; }
    public DateTime EffectiveDate { get; }
    public DateTime ExpirationDate { get; }
    public Guid Id { get; }
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

    public void add(Claim claim)
    {
        Claims.Add(claim);
    }

    public List<Claim> getClaims()
    {
        return Claims;
    }
}
