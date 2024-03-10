namespace Warranty;

public class ClaimsAdjudication
{
    /**
     * Adjudicate/adjudication - a judgment made on a claim to determine whether
     * we are legally obligated to process the claim against the warranty. From
     * Wikipedia (https://en.wikipedia.org/wiki/Adjudication):
     * "Claims adjudication" is a phrase used in the insurance industry to refer to
     * the process of paying claims submitted or denying them after comparing claims
     * to the benefit or coverage requirements.
     */
    public void Adjudicate(Contract contract, Claim newClaim)
    {
        if ((LimitOfLiability(contract) > newClaim.Amount) &&
             InEffectFor(contract, newClaim.FailureDate))
        {
            contract.Add(newClaim);
        }
    }

    // These two new methods we've added seem to be responsibilities of Contract. Let's move them...
    public double LimitOfLiability(Contract contract)
    {
        double claimTotal = contract.GetClaims().Sum(x => x.Amount);
        return (contract.PurchasePrice - claimTotal) * 0.8;
    }

    public bool InEffectFor(Contract contract, DateTime failureDate)
    {
        return (contract.Status == Contract.Lifecycle.Active) &&
             (DateTime.Compare(failureDate, contract.EffectiveDate) >= 0) &&
             (DateTime.Compare(failureDate, contract.ExpirationDate) <= 0);
    }
}