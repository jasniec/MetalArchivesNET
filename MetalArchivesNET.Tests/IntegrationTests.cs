using MetalArchivesNET.Models.Results.SearchResults;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MetalArchivesNET.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void RunQuickBandSearch()
        {
            IEnumerable<SimpleBandSearchResult> results = MetalArchives.Band.ByName("black sabbath");

            Assert.AreNotEqual(null, results);
        }

        [TestMethod]
        public void RunQuickAlbumSearch()
        {
            IEnumerable<SimpleAlbumSearchResult> results = MetalArchives.Album.ByName("13");

            Assert.AreNotEqual(null, results);
        }

        [TestMethod]
        public void RunQuickSongSearch()
        {
            IEnumerable<SimpleSongSearchResult> results = MetalArchives.Song.ByName("beneath the trees");

            Assert.AreNotEqual(null, results);
        }

        [TestMethod]
        public void GetBand()
        {
            IEnumerable<SimpleSongSearchResult> results = MetalArchives.Song.ByName("beneath the trees");

            var band = results.First(b => b.BandName == "Skogen").GetBand();

            Assert.AreNotEqual(null, band);
        }

    }
}
