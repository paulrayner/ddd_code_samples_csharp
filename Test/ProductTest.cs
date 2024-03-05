using System.Diagnostics.Contracts;
using System.Net.Http.Headers;
using Warranty;

namespace Test;

[TestClass]
public class ProductTest
{
    [TestMethod]
    public void TestProductEquality()
    {
        // A value object must be created whole
        var product  = new Warranty.Product("dishwasher", "OEUOEU23", "Whirlpool", "7DP840CWDB0");

        Assert.AreEqual(new Warranty.Product("dishwasher", "OEUOEU23", "Whirlpool", "7DP840CWDB0"), product);
    }

    [TestMethod]
    public void TestProductInequality()
    {
        // A value object must be created whole
        var product  = new Warranty.Product("dishwasher", "OEUOEU23", "Whirlpool", "7DP840CWDB0");

        Assert.AreNotEqual(new Warranty.Product("stove", "OEUOEU23", "Whirlpool", "7DP840CWDB0"), product);
        Assert.AreNotEqual(new Warranty.Product("dishwasher", "blah", "Whirlpool", "7DP840CWDB0"), product);
        Assert.AreNotEqual(new Warranty.Product("dishwasher", "OEUOEU23", "blah", "7DP840CWDB0"), product);
        Assert.AreNotEqual(new Warranty.Product("dishwasher", "OEUOEU23", "Whirlpool", "blah"), product);
    }
}