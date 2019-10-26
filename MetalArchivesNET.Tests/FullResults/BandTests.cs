using MetalArchivesNET.Models.Enums;
using MetalArchivesNET.Models.Results.FullResults;
using MetalArchivesNET.Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteParser;

namespace MetalArchivesNET.Tests.FullResults
{
    [TestClass]
    public class BandTests
    {
        [TestMethod]
        public void Name()
        {
            BandResult band = GetBand();

            Assert.AreEqual("Black Sabbath", band.Name);
        }

        [TestMethod]
        public void Country()
        {
            BandResult band = GetBand();

            Assert.AreEqual(MetalArchivesNET.Country.UnitedKingdom, band.CountryOfOrigin);
        }

        [TestMethod]
        public void Status()
        {
            BandResult band = GetBand();

            Assert.AreEqual(BandStatus.SplitUp, band.Status);
        }

        [TestMethod]
        public void FormedIn()
        {
            BandResult band = GetBand();

            Assert.AreEqual((ushort)1969, band.FormedInYear);
        }

        [TestMethod]
        public void LyricalThemesString()
        {
            BandResult band = GetBand();

            Assert.AreEqual("Doom, Drugs, Life, Death, Religion", band.LyricalThemesString);
        }

        [TestMethod]
        public void LyricalThemes()
        {
            BandResult band = GetBand();

            List<string> expected = new List<string>
            {
                "Doom",
                "Drugs",
                "Life",
                "Death",
                "Religion"
            };

            CollectionAssert.AreEqual(expected, band.LyricalThemes.ToList());
        }

        [TestMethod]
        public void GenresString()
        {
            BandResult band = GetBand();

            Assert.AreEqual("Heavy/Doom Metal", band.GenresString);
        }

        [TestMethod]
        public void Genres()
        {
            BandResult band = GetBand();

            List<string> expected = new List<string>
            {
                "Heavy/Doom Metal"
            };

            CollectionAssert.AreEqual(expected, band.Genres.ToList());
        }

        private BandResult GetBand()
        {
            return WebContentParser.Parse<BandResult>(Resources.Band_Black_Sabbath);
        }
    }
}
