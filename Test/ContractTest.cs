using System.Diagnostics.Contracts;
using Warranty;

namespace Test;

[TestClass]
public class ContractTest
{
    [TestMethod]
    public void TestContractSetUpProperly()
    {
        var contract = new Warranty.Contract(100.0, new DateTime(2010, 5, 6), new DateTime(2010, 5, 8), new DateTime(2013, 5, 8));

        Assert.IsNotNull(contract.Id);
        Assert.AreEqual(100.0, contract.PurchasePrice);
        Assert.AreEqual(new DateTime(2010, 5, 6), contract.PurchaseDate);
        Assert.AreEqual(new DateTime(2010, 5, 8), contract.EffectiveDate);
        Assert.AreEqual(new DateTime(2013, 5, 8), contract.ExpirationDate);
    }
}