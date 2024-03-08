using System.ComponentModel.DataAnnotations;
using Warranty;

namespace Test;

[TestClass]
public class ClaimTest
{
    [TestMethod]
    public void TestClaimSetupCorrectly()
    {
        var lineItem1 = new Warranty.LineItem("PARTS", 45.0, "Replacement part for soap dispenser");
        var lineItem2 = new Warranty.LineItem("LABOR", 50.0, "1 hour repair");
        var repairPO = new RepairPO();
        repairPO.LineItems.Add(lineItem1);
        repairPO.LineItems.Add(lineItem2);

        var claim = new Claim(100.0, new DateTime(2010, 5, 8));
        claim.RepairPO.Add(repairPO);

        Assert.IsNotNull(claim.Id);
        Assert.AreEqual(100.0, claim.Amount);
        Assert.AreEqual(new DateTime(2010, 5, 8), claim.FailureDate);
        Assert.AreEqual("PARTS", claim.RepairPO.First().LineItems.First().Type);
        Assert.AreEqual(45.0, claim.RepairPO.First().LineItems.First().Amount);
        Assert.AreEqual("Replacement part for soap dispenser", claim.RepairPO.First().LineItems.First().Description);
        Assert.AreEqual("LABOR", claim.RepairPO.First().LineItems[1].Type);
        Assert.AreEqual(50.0, claim.RepairPO.First().LineItems[1].Amount);
        Assert.AreEqual("1 hour repair", claim.RepairPO.First().LineItems[1].Description);

    }
}