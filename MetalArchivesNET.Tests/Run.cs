using MetalArchivesNET.Models.SearchResults;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MetalArchivesNET.Tests
{
    [TestClass]
    public class Run
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

    }
}
