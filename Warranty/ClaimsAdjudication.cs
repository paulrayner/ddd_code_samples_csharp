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
    public void adjudicate(Contract contract, Claim newClaim)
    {
        double claimTotal = contract.getClaims().Sum(x => x.Amount);
        if (((contract.PurchasePrice - claimTotal) * 0.8 > newClaim.Amount) &&
             (contract.Status == Contract.Lifecycle.Active) &&
             (DateTime.Compare(newClaim.FailureDate, contract.EffectiveDate) >= 0) &&
             (DateTime.Compare(newClaim.FailureDate, contract.ExpirationDate) <= 0))
        {
            contract.add(newClaim);
        }
    }
}