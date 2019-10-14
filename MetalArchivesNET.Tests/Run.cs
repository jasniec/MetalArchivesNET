using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MetalArchivesNET.Tests
{
    [TestClass]
    public class Run
    {
        [TestMethod]
        public void RunQuickBandSearch()
        {
            var results = MetalArchives.Band.ByName("black");

            Assert.AreNotEqual(null, results);
        }

    }
}
