using MetalArchivesNET.Models.Enums;
using MetalArchivesNET.Models.Results.BandResults;
using MetalArchivesNET.Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteParser;

namespace MetalArchivesNET.Tests.BandsResults
{
    [TestClass]
    public class AlbumBandResultTests
    {
        [TestMethod]
        public void AlbumName()
        {
            var rows = GetThreeRows(Resources.AlbumList_Skogen).Select(r => r.AlbumName).ToList();

            List<string> expected = new List<string>
            {
                "Vittra",
                "Svitjod",
                "Eld"
            };

            CollectionAssert.AreEqual(expected, rows);
        }

        [TestMethod]
        public void AlbumUrl()
        {
            var rows = GetThreeRows(Resources.AlbumList_Skogen).Select(r => r.AlbumUrl).ToList();

            List<string> expected = new List<string>
            {
                @"https://www.metal-archives.com/albums/Skogen/Vittra/256524",
                @"https://www.metal-archives.com/albums/Skogen/Svitjod/305602",
                @"https://www.metal-archives.com/albums/Skogen/Eld/353382"
            };

            CollectionAssert.AreEqual(expected, rows);
        }

        [TestMethod]
        public void AlbumTypeTest()
        {
            var rows = GetThreeRows(Resources.AlbumList_Skogen).Select(r => r.AlbumType).ToList();

            List<AlbumType> expected = new List<AlbumType>
            {
                AlbumType.FullLength,
                AlbumType.FullLength,
                AlbumType.FullLength
            };

            CollectionAssert.AreEqual(expected, rows);
        }

        [TestMethod]
        public void AlbumReleaseYear()
        {
            var rows = GetThreeRows(Resources.AlbumList_Skogen).Select(r => r.AlbumReleaseYear).ToList();

            List<ushort> expected = new List<ushort>
            {
                2009, 
                2011, 
                2012
            };

            CollectionAssert.AreEqual(expected, rows);
        }

        private IEnumerable<AlbumBandResult> GetThreeRows(string resource)
        {
            return WebContentParser.ParseList<AlbumBandResult>(resource).Take(3);
        }

    }
}
