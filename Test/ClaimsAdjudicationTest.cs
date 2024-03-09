using Warranty;

namespace Test;

[TestClass]
public class ClaimsAdjudicationTest
{

    Contract FakeContract()
    {
        var product = new Warranty.Product("dishwasher", "OEUOEU23", "Whirlpool", "7DP840CWDB0");
        TermsAndConditions termsAndConditions = new TermsAndConditions(new DateTime(2010, 5, 7), new DateTime(2010, 5, 8), new DateTime(2013, 5, 8));
        Contract contract = new Contract(100.0, product, termsAndConditions);
        contract.Status = Warranty.Contract.Lifecycle.Active;

        return contract;
    }

    [TestMethod]
    public void TestAdjudicateValidClaim()
    {
        var contract = FakeContract();
        var claim = new Claim(79.0, new DateTime(2010, 5, 8));

        new ClaimsAdjudication().adjudicate(contract, claim);

        Assert.AreEqual(1, contract.getClaims().Count);
        Assert.AreEqual(79.0, contract.getClaims().First().Amount);
        Assert.AreEqual(new DateTime(2010, 5, 8), contract.getClaims().First().FailureDate);
    }

    [TestMethod]
    public void TestAdjudicateClaimWithInvalidAmount()
    {
        var contract = FakeContract();
        var claim = new Claim(81.0, new DateTime(2010, 5, 8));

        new ClaimsAdjudication().adjudicate(contract, claim);

        Assert.AreEqual(0, contract.getClaims().Count);
    }

    [TestMethod]
    public void TestAdjudicateClaimForPendingContract()
    {
        var contract = FakeContract();
        contract.Status = Contract.Lifecycle.Pending;
        var claim = new Claim(79.0, new DateTime(2010, 5, 8));

        new ClaimsAdjudication().adjudicate(contract, claim);

        Assert.AreEqual(0, contract.getClaims().Count);
    }

    [TestMethod]
    public void TestAdjudicateClaimForExpiredContract()
    {
        var contract = FakeContract();
        contract.Status = Contract.Lifecycle.Expired;
        var claim = new Claim(79.0, new DateTime(2010, 5, 8));

        new ClaimsAdjudication().adjudicate(contract, claim);

        Assert.AreEqual(0, contract.getClaims().Count);
    }

    [TestMethod]
    public void TestAdjudicateClaimPriorToEffectiveDate()
    {
        var contract = FakeContract();
        var claim = new Claim(79.0, new DateTime(2010, 5, 7));

        new ClaimsAdjudication().adjudicate(contract, claim);

        Assert.AreEqual(0, contract.getClaims().Count);
    }

    [TestMethod]
    public void TestAdjudicateClaimAfterExpirationDate()
    {
        var contract = FakeContract();
        var claim = new Claim(79.0, new DateTime(2013, 5, 9));

        new ClaimsAdjudication().adjudicate(contract, claim);

        Assert.AreEqual(0, contract.getClaims().Count);
    }
}