using Warranty;

namespace Test;

[TestClass]
public class TermsAndConditionsTest
{
    [TestMethod]
    public void TestTermsAndConditionsStatus()
    {
        var termsAndConditions = new TermsAndConditions(new DateTime(2010, 5, 7), new DateTime(2010, 5, 8), new DateTime(2013, 5, 8));

        // Should be pending prior to effective date
        Assert.AreEqual(Contract.Lifecycle.Pending, termsAndConditions.Status(new DateTime(2010, 5, 7)));
        // Should be active if between effective and expiration dates (inclusively)
        Assert.AreEqual(Contract.Lifecycle.Active, termsAndConditions.Status(new DateTime(2010, 5, 8)));
        Assert.AreEqual(Contract.Lifecycle.Active, termsAndConditions.Status(new DateTime(2013, 5, 8)));
        // Should be expired after to expiration date
        Assert.AreEqual(Contract.Lifecycle.Expired, termsAndConditions.Status(new DateTime(2013, 5, 9)));
    }

    [TestMethod]
    public void TestTermsAndConditionsLimitOfLiability()
    {
        var termsAndConditions = new TermsAndConditions(new DateTime(2010, 5, 7), new DateTime(2010, 5, 8), new DateTime(2013, 5, 8));

        Assert.AreEqual(80.0, termsAndConditions.LimitOfLiability(100));
    }


    [TestMethod]
    public void TestTermsAndConditionsExtendAnnually()
    {
        var termsAndConditions = new TermsAndConditions(new DateTime(2010, 5, 7), new DateTime(2010, 5, 8), new DateTime(2013, 5, 8));

        var extendedTermsAndConditions = new TermsAndConditions(new DateTime(2010, 5, 7), new DateTime(2010, 5, 8), new DateTime(2014, 5, 8));

        Assert.AreEqual(extendedTermsAndConditions, termsAndConditions.AnnuallyExtended());
    }
}