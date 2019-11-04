using MetalArchivesNET.Models.Enums;
using MetalArchivesNET.Models.Results.FullResults;
using MetalArchivesNET.Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebsiteParser;
using System.Linq;

namespace MetalArchivesNET.Tests.FullResults
{
    [TestClass]
    public class AlbumTests
    {
        [TestMethod]
        public void Id()
        {
            AlbumResult album = GetAlbum(Resources.Album_Belzebubs);

            Assert.AreEqual((ulong)763303, album.Id);
        }

        [TestMethod]
        public void Name()
        {
            AlbumResult album = GetAlbum(Resources.Album_Belzebubs);

            Assert.AreEqual("Pantheon of the Nightside Gods", album.AlbumName);
        }

        [TestMethod]
        public void BandName()
        {
            AlbumResult album = GetAlbum(Resources.Album_Belzebubs);

            Assert.AreEqual("Belzebubs", album.BandName);
        }

        [TestMethod]
        public void BandUrl()
        {
            AlbumResult album = GetAlbum(Resources.Album_Belzebubs);

            Assert.AreEqual(@"https://www.metal-archives.com/bands/Belzebubs/3540442691", album.BandUrl);
        }

        [TestMethod]
        public void AlbumTypeTest()
        {
            AlbumResult album = GetAlbum(Resources.Album_Belzebubs);

            Assert.AreEqual(AlbumType.FullLength, album.AlbumType);
        }

        [TestMethod]
        public void ReleaseDate()
        {
            AlbumResult album = GetAlbum(Resources.Album_Belzebubs);

            Assert.AreEqual(new DateTime(2019, 4, 26), album.ReleaseDate);
        }

        [TestMethod]
        public void CatalogId()
        {
            AlbumResult album = GetAlbum(Resources.Album_Belzebubs);

            Assert.AreEqual("19075933222", album.CatalogId);
        }

        [TestMethod]
        public void VersionDescription()
        {
            AlbumResult album = GetAlbum(Resources.Album_Belzebubs);

            Assert.AreEqual("Limited edition, Mediabook", album.VersionDescription);
        }

        [TestMethod]
        public void Label()
        {
            AlbumResult album = GetAlbum(Resources.Album_Belzebubs);

            Assert.AreEqual("Century Media Records", album.Label);
        }

        [TestMethod]
        public void Format()
        {
            AlbumResult album = GetAlbum(Resources.Album_Belzebubs);

            Assert.AreEqual(AlbumFormat.Cd, album.Format);
        }

        [TestMethod]
        public void Songs()
        {
            AlbumResult album = GetAlbum(Resources.Album_Belzebubs);

            Assert.AreEqual(album.Songs.Count(), 11);
        }

        private AlbumResult GetAlbum(string resource)
        {
            return WebContentParser.Parse<AlbumResult>(resource);
        }
    }
}
