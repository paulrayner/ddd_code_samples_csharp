using System.Diagnostics.Contracts;
using Warranty;

namespace Test;

[TestClass]
public class ContractTest
{
    [TestMethod]
    public void TestContractSetUpProperly()
    {
        var contract = new Warranty.Contract(100.0);
        Assert.AreEqual(100.0, contract.PurchasePrice);
    }
}