
namespace Warranty;

public class Contract
{

    public double PurchasePrice;

    public DateTime PurchaseDate { get; }
    public DateTime EffectiveDate { get; }
    public DateTime ExpirationDate { get; }
    public Guid Id { get; }

    public Contract(double purchasePrice, DateTime purchaseDate, DateTime effectiveDate, DateTime expirationDate)
    {
        Id = Guid.NewGuid();
        PurchasePrice = purchasePrice;
        PurchaseDate = purchaseDate;
        EffectiveDate = effectiveDate;
        ExpirationDate = expirationDate;
    }
}
