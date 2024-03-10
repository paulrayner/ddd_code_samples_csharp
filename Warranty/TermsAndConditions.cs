namespace Warranty;


public sealed record TermsAndConditions(DateTime PurchaseDate, DateTime EffectiveDate, DateTime ExpirationDate)
{
    public const double LimitOfLiabilityPercentage = 0.8;

    public double LimitOfLiability(double purchasePrice)
    {
        return purchasePrice * LimitOfLiabilityPercentage;
    }

    public Contract.Lifecycle Status(DateTime date)
    {
        if (DateTime.Compare(date, EffectiveDate) < 0) return Contract.Lifecycle.Pending;
        if (DateTime.Compare(date, ExpirationDate) > 0) return Contract.Lifecycle.Expired;
        return Contract.Lifecycle.Active;
    }

    public TermsAndConditions AnnuallyExtended()
    {
        return new TermsAndConditions(PurchaseDate, EffectiveDate, ExpirationDate.AddYears(1));
    }
};
