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
        public void Id()
        {
            BandResult band = GetBand(Resources.Band_Black_Sabbath);

            Assert.AreEqual((ulong)99, band.Id);
        }

        [TestMethod]
        public void Name()
        {
            BandResult band = GetBand(Resources.Band_Black_Sabbath);

            Assert.AreEqual("Black Sabbath", band.Name);
        }

        [TestMethod]
        public void Country()
        {
            BandResult band = GetBand(Resources.Band_Black_Sabbath);

            Assert.AreEqual(MetalArchivesNET.Country.UnitedKingdom, band.CountryOfOrigin);
        }

        [TestMethod]
        public void Status()
        {
            BandResult band = GetBand(Resources.Band_Black_Sabbath);

            Assert.AreEqual(BandStatus.SplitUp, band.Status);
        }

        [TestMethod]
        public void FormedIn()
        {
            BandResult band = GetBand(Resources.Band_Black_Sabbath);

            Assert.AreEqual((ushort)1969, band.FormedInYear);
        }

        [TestMethod]
        public void LyricalThemesString()
        {
            BandResult band = GetBand(Resources.Band_Black_Sabbath);

            Assert.AreEqual("Doom, Drugs, Life, Death, Religion", band.LyricalThemesString);
        }

        [TestMethod]
        public void LyricalThemes()
        {
            BandResult band = GetBand(Resources.Band_Black_Sabbath);

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
            BandResult band = GetBand(Resources.Band_Black_Sabbath);

            Assert.AreEqual("Heavy/Doom Metal", band.GenresString);
        }

        [TestMethod]
        public void Genres()
        {
            BandResult band = GetBand(Resources.Band_Black_Sabbath);

            List<string> expected = new List<string>
            {
                "Heavy/Doom Metal"
            };

            CollectionAssert.AreEqual(expected, band.Genres.ToList());
        }

        [TestMethod]
        public void NotesShort()
        {
            BandResult band = GetBand(Resources.Band_Black_Sabbath);

            string expected = "Played their final show of their very last tour entitled \"The End\" in Birmingham, England on February 4th, 2017. The band initially retired from large scale touring after the show, but later announced that they broke up.  Black Sabbath are generally considered both the first heavy metal and doom metal band. Originally they were called Polka Tulk (featuring a saxophonist and slide guitarist in ...";

            Assert.AreEqual(expected, band.NotesShort);
        }

        [TestMethod]
        public void NotesUrlNotEmpty()
        {
            BandResult band = GetBand(Resources.Band_Black_Sabbath);

            Assert.AreEqual("https://metal-archives.com/band/read-more/id/99", band.NotesFullUrl);
        }

        [TestMethod]
        public void NotesUrlEmpty()
        {
            BandResult band = GetBand(Resources.Band_Wormwitch);

            Assert.AreEqual(null, band.NotesFullUrl);
        }

        [TestMethod]
        public void NotesFullNotEmpty_NeedInternet()
        {
            BandResult band = GetBand(Resources.Band_Black_Sabbath);

            Assert.AreNotEqual("", band.GetFullNotes());
        }

        private BandResult GetBand(string resource)
        {
            return WebContentParser.Parse<BandResult>(resource);
        }
    }
}
