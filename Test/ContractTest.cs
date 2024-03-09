using Warranty;

namespace Test;

[TestClass]
public class ContractTest
{
    [TestMethod]
    public void TestContractSetUpProperly()
    {
        var product  = new Warranty.Product("dishwasher", "OEUOEU23", "Whirlpool", "7DP840CWDB0");
        TermsAndConditions termsAndConditions = new TermsAndConditions(new DateTime(2010, 5, 7), new DateTime(2010, 5, 8), new DateTime(2013, 5, 8));
        Contract contract = new Contract(100.0, product, termsAndConditions);

        Assert.IsNotNull(contract.Id);
        Assert.AreEqual(100.0, contract.PurchasePrice);
        Assert.AreEqual(Warranty.Contract.Lifecycle.Pending, contract.Status);
        Assert.AreEqual(termsAndConditions, contract.TermsAndConditions);
        Assert.AreEqual(product, contract.CoveredProduct);
    }

    [TestMethod]
    public void contractInEffectBasedOnStatusAndEffectiveAndExpirationDateRange()
    {
        Product product = new Product("dishwasher", "OEUOEU23", "Whirlpool", "7DP840CWDB0");
        TermsAndConditions termsAndConditions = new TermsAndConditions(new DateTime(2010, 5, 7), new DateTime(2010, 5, 8), new DateTime(2013, 5, 8));
        Contract contract = new Contract(100.0, product, termsAndConditions);

        contract.Status = Contract.Lifecycle.Pending;
        Assert.IsTrue(contract.inEffectFor(new DateTime(2010, 5, 9)));

        contract.Status = Contract.Lifecycle.Active;
        Assert.IsFalse(contract.inEffectFor(new DateTime(2010, 5, 7)));
        Assert.IsTrue(contract.inEffectFor(new DateTime(2010, 5, 8)));
        Assert.IsTrue(contract.inEffectFor(new DateTime(2013, 5, 7)));
        Assert.IsFalse(contract.inEffectFor(new DateTime(2013, 5, 9)));

        contract.Status = Contract.Lifecycle.Expired;
        Assert.IsFalse(contract.inEffectFor(new DateTime(2010, 5, 8)));
    }
}