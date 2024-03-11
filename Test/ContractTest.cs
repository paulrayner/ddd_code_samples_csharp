using Warranty;

namespace Test;

[TestClass]
public class ContractTest
{
    [TestMethod]
    public void TestContractSetUpProperly()
    {
        var product  = new Warranty.Product("dishwasher", "OEUOEU23", "Whirlpool", "7DP840CWDB0");
        var termsAndConditions = new TermsAndConditions(new DateTime(2010, 5, 7), new DateTime(2010, 5, 8), new DateTime(2013, 5, 8));
        var contract = new Contract(100.0, product, termsAndConditions);

        Assert.IsNotNull(contract.Id);
        Assert.AreEqual(100.0, contract.PurchasePrice);
        Assert.AreEqual(Warranty.Contract.Lifecycle.Pending, contract.Status);
        Assert.AreEqual(termsAndConditions, contract.TermsAndConditions);
        Assert.AreEqual(product, contract.CoveredProduct);
    }

    [TestMethod]
    public void TestContractInEffectBasedOnStatusAndEffectiveAndExpirationDateRange()
    {
        var product = new Product("dishwasher", "OEUOEU23", "Whirlpool", "7DP840CWDB0");
        var termsAndConditions = new TermsAndConditions(new DateTime(2010, 5, 7), new DateTime(2010, 5, 8), new DateTime(2013, 5, 8));
        var contract = new Contract(100.0, product, termsAndConditions);

        contract.Status = Contract.Lifecycle.Pending;
        Assert.IsFalse(contract.InEffectFor(new DateTime(2010, 5, 9)));

        contract.Status = Contract.Lifecycle.Active;
        Assert.IsFalse(contract.InEffectFor(new DateTime(2010, 5, 7)));
        Assert.IsTrue(contract.InEffectFor(new DateTime(2010, 5, 8)));
        Assert.IsTrue(contract.InEffectFor(new DateTime(2013, 5, 7)));
        Assert.IsFalse(contract.InEffectFor(new DateTime(2013, 5, 9)));

        contract.Status = Contract.Lifecycle.Expired;
        Assert.IsFalse(contract.InEffectFor(new DateTime(2010, 5, 8)));
    }

    [TestMethod]
    public void TestClaimAmountsWithinLimitOfLiability()
    {
        Product product = new Product("dishwasher", "OEUOEU23", "Whirlpool", "7DP840CWDB0");
        TermsAndConditions termsAndConditions = new TermsAndConditions(new DateTime(2010, 5, 7), new DateTime(2010, 5, 8), new DateTime(2013, 5, 8));
        Contract contract = new Contract(100.0, product, termsAndConditions);

        Assert.IsTrue(contract.WithinLimitOfLiability(10));
        Assert.IsTrue(contract.WithinLimitOfLiability(79));
        Assert.IsFalse(contract.WithinLimitOfLiability(80)); // Must be less than the limit amount
        Assert.IsFalse(contract.WithinLimitOfLiability(90));
    }

    [TestMethod]
    public void TestActiveContractCoverage()
    {
        Product product = new Product("dishwasher", "OEUOEU23", "Whirlpool", "7DP840CWDB0");
        TermsAndConditions termsAndConditions = new TermsAndConditions(new DateTime(2010, 5, 7), new DateTime(2010, 5, 8), new DateTime(2013, 5, 8));
        Contract contract = new Contract(100.0, product, termsAndConditions);

        contract.Status = Contract.Lifecycle.Pending;
        Assert.IsFalse(contract.Covers(new Claim(10.0, new DateTime(2010, 10, 1))));

        contract.Status = Contract.Lifecycle.Active;
        Assert.IsTrue(contract.Covers(new Claim(10.0, new DateTime(2010, 10, 1))));
        Assert.IsTrue(contract.Covers(new Claim(79.0, new DateTime(2010, 10, 1))));
        Assert.IsFalse(contract.Covers(new Claim(80.0, new DateTime(2010, 10, 1))));
        Assert.IsFalse(contract.Covers(new Claim(90.0, new DateTime(2010, 10, 1))));

        contract.Status = Contract.Lifecycle.Expired;
        Assert.IsFalse(contract.Covers(new Claim(10.0, new DateTime(2010, 10, 1))));
    }


    [TestMethod]
    public void TestExtendAnnualSubscription()
    {
        var product = new Product("dishwasher", "OEUOEU23", "Whirlpool", "7DP840CWDB0");
        var termsAndConditions = new TermsAndConditions(new DateTime(2010, 5, 7), new DateTime(2010, 5, 8), new DateTime(2013, 5, 8));
        var contract = new Contract(100.0, product, termsAndConditions);

        contract.ExtendAnnualSubscription();
        var extendedTermsAndConditions = new TermsAndConditions(new DateTime(2010, 5, 7), new DateTime(2010, 5, 8), new DateTime(2014, 5, 8));

        Assert.AreEqual(extendedTermsAndConditions, contract.TermsAndConditions);
        Assert.IsNotNull(contract.Renewals);
        Assert.AreEqual(1, contract.Renewals.Count);
        Assert.AreEqual(contract.Id, contract.Renewals.First().ContractId);
        Assert.AreEqual("Automatic Annual Renewal", contract.Renewals.First().Reason);
        Assert.AreEqual(DateTime.Today, contract.Renewals.First().OccurredAt.Date);
    }
}