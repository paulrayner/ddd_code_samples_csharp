namespace Warranty;

public sealed record TermsAndConditions(DateTime purchaseDate, DateTime effectiveDate, DateTime expirationDate)
{
    public double limitOfLiability(double purchasePrice)
    {
        return 0.0;
    }

    public Contract.Lifecycle status(DateTime date)
    {
        return Contract.Lifecycle.Active;
    }
};
