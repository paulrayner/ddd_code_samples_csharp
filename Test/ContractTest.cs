using System.Diagnostics.Contracts;
using System.Net.Http.Headers;
using Warranty;

namespace Test;

[TestClass]
public class ContractTest
{
    [TestMethod]
    public void TestContractSetUpProperly()
    {
        var product  = new Warranty.Product("dishwasher", "OEUOEU23", "Whirlpool", "7DP840CWDB0");
        var contract = new Warranty.Contract(100.0, product, new DateTime(2010, 5, 6), new DateTime(2010, 5, 8), new DateTime(2013, 5, 8));

        Assert.IsNotNull(contract.Id);
        Assert.AreEqual(100.0, contract.PurchasePrice);
        Assert.AreEqual(Warranty.Contract.Lifecycle.Pending, contract.Status);
        Assert.AreEqual(new DateTime(2010, 5, 6), contract.PurchaseDate);
        Assert.AreEqual(new DateTime(2010, 5, 8), contract.EffectiveDate);
        Assert.AreEqual(new DateTime(2013, 5, 8), contract.ExpirationDate);

        Assert.AreEqual(product, contract.CoveredProduct);
    }

    [TestMethod]
    public void TestContractEquality()
    {
        var product  = new Warranty.Product("dishwasher", "OEUOEU23", "Whirlpool", "7DP840CWDB0");
        var contract1 = new Warranty.Contract(100.0, product, new DateTime(2010, 5, 6), new DateTime(2010, 5, 8), new DateTime(2013, 5, 8));
        var contract2 = new Warranty.Contract(100.0, product, new DateTime(2010, 5, 6), new DateTime(2010, 5, 8), new DateTime(2013, 5, 8));
        var contract3 = new Warranty.Contract(100.0, product, new DateTime(2010, 5, 6), new DateTime(2010, 5, 8), new DateTime(2013, 5, 8));

        Assert.AreNotEqual(contract2, contract1);
        Assert.AreNotEqual(contract3, contract1);
    }
}