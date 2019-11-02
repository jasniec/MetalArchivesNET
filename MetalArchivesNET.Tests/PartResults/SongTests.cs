using HtmlAgilityPack;
using MetalArchivesNET.Models.Results.PartResults;
using MetalArchivesNET.Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebsiteParser;

namespace MetalArchivesNET.Tests.PartResults
{
    [TestClass]
    public class SongTests
    {
        [TestMethod]
        public void Index()
        {
            var actua = GetSongs(Resources.Album_Belzebubs).Select(s => s.Index).OrderBy(i => i).ToList();

            var expected = Enumerable.Range(1, 11).Select(v => (byte)v).ToList();

            CollectionAssert.AreEqual(expected, actua);
        }

        [TestMethod]
        public void Id()
        {
            var actual = GetSongs(Resources.Album_Belzebubs).OrderBy(s => s.Index).Select(s => s.Id).ToList();

            var expected = new List<ulong>
            {
                4859619,
                4859620,
                4859621,
                4859622,
                4859623,
                4859624,
                4859625,
                4859626,
                4859627,
                0,
                0
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Title()
        {
            var actual = GetSongs(Resources.Album_Belzebubs).OrderBy(s => s.Index).Select(s => s.Title).ToList();

            var expected = new List<string>
            {
                "Cathedrals of Mourning",
                "The Faustian Alchemist",
                "Blackened Call",
                "Acheron",
                "Nam Gloria Lucifer",
                "The Crowned Daughters",
                "Dark Mother",
                "The Werewolf Bride",
                "Pantheon of the Nightside Gods",
                "Nuns in the Purgatory",
                "Maleficarum"
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Duration()
        {
            var actual = GetSongs(Resources.Album_Belzebubs).OrderBy(s => s.Index).Select(s => s.Duration).ToList();

            var expected = new List<TimeSpan>
            {
                new TimeSpan(0, 6, 18),
                new TimeSpan(0, 4, 14),
                new TimeSpan(0, 3, 45),
                new TimeSpan(0, 7, 32),
                new TimeSpan(0, 4, 29),
                new TimeSpan(0, 5, 11),
                new TimeSpan(0, 9, 15),
                new TimeSpan(0, 4, 8),
                new TimeSpan(0, 8, 54),
                new TimeSpan(0, 3, 14),
                new TimeSpan(0, 4, 39)
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HasLyrics()
        {
            var actual = GetSongs(Resources.Album_Belzebubs).OrderBy(s => s.Index).Select(s => s.HasLyrics).ToList();

            var expected = new List<bool>
            {
                true,
                true,
                true,
                true,
                true,
                true,
                true,
                true,
                true,
                false,
                false
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsInstrumental()
        {
            var actual = GetSongs(Resources.Album_Belzebubs).OrderBy(s => s.Index).Select(s => s.IsInstrumental).ToList();

            var expected = new List<bool>
            {
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                true,
                true
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Lyrics()
        {
            var songs = GetSongs(Resources.Album_Belzebubs);

            var actual = songs.First(s => s.Index == 3).GetLyrics();

            Assert.AreEqual(Resources.Song_BlackenedCall, actual);
        }

        [TestMethod]
        public void LyricsEmpty()
        {
            var songs = GetSongs(Resources.Album_Belzebubs);

            var actual = songs.First(s => s.Index == 11).GetLyrics();

            Assert.AreEqual(string.Empty, actual);
        }

        private IEnumerable<SongResult> GetSongs(string resource)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(resource);

            string songsHolder = document.QuerySelector(".table_lyrics").InnerHtml;

            return WebContentParser.ParseList<SongResult>(songsHolder);
        }
    }
}
