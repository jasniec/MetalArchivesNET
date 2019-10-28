using MetalArchivesNET.Models.Enums;
using MetalArchivesNET.Models.Results.BandResults;
using MetalArchivesNET.Models.Results.FullResults;
using MetalArchivesNET.Models.Results.SearchResults;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalArchivesNET.Tests.Integration
{
    [TestClass]
    public class BandIntegration
    {
        [TestMethod]
        public void GetBand()
        {
            IEnumerable<SimpleSongSearchResult> results = MetalArchives.Song.ByName("beneath the trees");
            BandResult band = results.First().GetFullBand();

            Assert.AreNotEqual(null, band);
        }

        #region AlbumList
        [TestMethod]
        public void GetBandAlbumListAll()
        {
            IEnumerable<SimpleBandSearchResult> results = MetalArchives.Band.ByName("Black Sabbath");
            BandResult band = results.First().GetFullBand();
            IEnumerable<AlbumBandResult> albums = band.GetAlbums(AlbumListType.All);

            Assert.AreNotEqual(null, albums);
        }

        [TestMethod]
        public void GetBandAlbumListDemos()
        {
            IEnumerable<SimpleBandSearchResult> results = MetalArchives.Band.ByName("Black Sabbath");
            BandResult band = results.First().GetFullBand();
            IEnumerable<AlbumBandResult> albums = band.GetAlbums(AlbumListType.Demos);

            Assert.AreNotEqual(null, albums);
        }

        [TestMethod]
        public void GetBandAlbumListLives()
        {
            IEnumerable<SimpleBandSearchResult> results = MetalArchives.Band.ByName("Black Sabbath");
            BandResult band = results.First().GetFullBand();
            IEnumerable<AlbumBandResult> albums = band.GetAlbums(AlbumListType.Lives);

            Assert.AreNotEqual(null, albums);
        }

        [TestMethod]
        public void GetBandAlbumListMain()
        {
            IEnumerable<SimpleBandSearchResult> results = MetalArchives.Band.ByName("Black Sabbath");
            BandResult band = results.First().GetFullBand();
            IEnumerable<AlbumBandResult> albums = band.GetAlbums(AlbumListType.Main);

            Assert.AreNotEqual(null, albums);
        }

        [TestMethod]
        public void GetBandAlbumListMisc()
        {
            IEnumerable<SimpleBandSearchResult> results = MetalArchives.Band.ByName("Black Sabbath");
            BandResult band = results.First().GetFullBand();
            IEnumerable<AlbumBandResult> albums = band.GetAlbums(AlbumListType.Misc);

            Assert.AreNotEqual(null, albums);
        }
        #endregion
    }
}
