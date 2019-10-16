using MetalArchivesNET.Models.Enums;
using MetalArchivesNET.Models.SearchResults;
using MetalArchivesNET.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalArchivesNET.Tests.QuickSearch
{
    [TestClass]
    public class SongQuickSearchTests
    {
        [TestMethod]
        public void CountCheck()
        {
            List<SimpleSongSearchResult> results = GetResults();

            Assert.AreEqual(6, results.Count);
        }

        [TestMethod]
        public void NamesCheck()
        {
            List<SimpleSongSearchResult> results = GetResults();
            ICollection names = results.Select(r => r.Title).ToList();
            ICollection expectedNames = new List<string>
            {
                "A Desolation Song",
                "A Desolation Song",
                "A Song of Desolation",
                "A Desolation Song (Agalloch cover)",
                "A Desolation Song (Agalloch Cover)",
                "A Desolation Song (TWC Aleutian Mix)",
            };

            CollectionAssert.AreEqual(expectedNames, names);
        }

        #region Album
        [TestMethod]
        public void AlbumNamesCheck()
        {
            List<SimpleSongSearchResult> results = GetResults();
            ICollection names = results.Select(r => r.AlbumName).ToList();
            ICollection expectedNames = new List<string>
            {
                "The Mantle",
                "Spirit of the Mountain",
                "A Tale of Naardakh",
                "Gazing Light Eternity",
                "Silent Emotion",
                "Whitedivisiongrey",
            };

            CollectionAssert.AreEqual(expectedNames, names);
        }

        [TestMethod]
        public void AlbumTypeCheck()
        {
            List<SimpleSongSearchResult> results = GetResults();
            ICollection types = results.Select(r => r.AlbumType).ToList();
            ICollection expectedTypes = new List<AlbumType>
            {
                AlbumType.FullLength,
                AlbumType.Demo,
                AlbumType.FullLength,
                AlbumType.FullLength,
                AlbumType.FullLength,
                AlbumType.Compilation,
            };

            CollectionAssert.AreEqual(expectedTypes, types);
        }

        [TestMethod]
        public void AlbumUrlsCheck()
        {
            List<SimpleSongSearchResult> results = GetResults();
            ICollection urls = results.Select(r => r.AlbumUrl).ToList();
            ICollection expectedUrls = new List<string>
            {
                @"https://www.metal-archives.com/albums/Agalloch/The_Mantle/3526",
                @"https://www.metal-archives.com/albums/Spectral_Procession/Spirit_of_the_Mountain/480981",
                @"https://www.metal-archives.com/albums/Tyrakk/A_Tale_of_Naardakh/499217",
                @"https://www.metal-archives.com/albums/Chiral/Gazing_Light_Eternity/620730",
                @"https://www.metal-archives.com/albums/Symptoms_of_Insanity/Silent_Emotion/369174",
                @"https://www.metal-archives.com/albums/Agalloch/Whitedivisiongrey/301685"
            };

            CollectionAssert.AreEqual(expectedUrls, urls);
        }
        #endregion

        #region Band
        [TestMethod]
        public void BandNamesCheck()
        {
            List<SimpleSongSearchResult> results = GetResults();
            ICollection names = results.Select(r => r.BandName).ToList();
            ICollection expectedNames = new List<string>
            {
                "Agalloch",
                "Spectral Procession",
                "Tyrakk",
                "Chiral",
                "Symptoms of Insanity",
                "Agalloch",
            };

            CollectionAssert.AreEqual(expectedNames, names);
        }

        [TestMethod]
        public void BandUrlsCheck()
        {
            List<SimpleSongSearchResult> results = GetResults();
            ICollection urls = results.Select(r => r.BandUrl).ToList();
            ICollection expectedUrls = new List<string>
            {
                @"https://www.metal-archives.com/bands/Agalloch/305",
                @"https://www.metal-archives.com/bands/Spectral_Procession/3540390552",
                @"https://www.metal-archives.com/bands/Tyrakk/3540394054",
                @"https://www.metal-archives.com/bands/Chiral/3540381065",
                @"https://www.metal-archives.com/bands/Symptoms_of_Insanity/3540360829",
                @"https://www.metal-archives.com/bands/Agalloch/305"
            };

            CollectionAssert.AreEqual(expectedUrls, urls);
        }
        #endregion

        private List<SimpleSongSearchResult> GetResults()
        {
            ResponseParser<SimpleSongSearchResult> parser = new ResponseParser<SimpleSongSearchResult>();

            return parser.Parse(CONTENT);
        }

        #region Input data
        const string CONTENT = "{ 	\"error\": \"\",	\"iTotalRecords\": 6,	\"iTotalDisplayRecords\": 6,	\"sEcho\": 1,	\"aaData\": [					[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Agalloch/305\\\" title=\\\"Agalloch (US)\\\">Agalloch</a>\",			\"<a href=\\\"https://www.metal-archives.com/albums/Agalloch/The_Mantle/3526\\\">The Mantle</a>\", 			\"Full-length\", 			\"A Desolation Song\"   		]				,							[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Spectral_Procession/3540390552\\\" title=\\\"Spectral Procession (CA)\\\">Spectral Procession</a>\",			\"<a href=\\\"https://www.metal-archives.com/albums/Spectral_Procession/Spirit_of_the_Mountain/480981\\\">Spirit of the Mountain</a>\", 			\"Demo\", 			\"A Desolation Song\"   		]				,							[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Tyrakk/3540394054\\\" title=\\\"Tyrakk (FR)\\\">Tyrakk</a>\",			\"<a href=\\\"https://www.metal-archives.com/albums/Tyrakk/A_Tale_of_Naardakh/499217\\\">A Tale of Naardakh</a>\", 			\"Full-length\", 			\"A Song of Desolation\"   		]				,							[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Chiral/3540381065\\\" title=\\\"Chiral (IT)\\\">Chiral</a>\",			\"<a href=\\\"https://www.metal-archives.com/albums/Chiral/Gazing_Light_Eternity/620730\\\">Gazing Light Eternity</a>\", 			\"Full-length\", 			\"A Desolation Song (Agalloch cover)\"   		]				,							[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Symptoms_of_Insanity/3540360829\\\" title=\\\"Symptoms of Insanity (US)\\\">Symptoms of Insanity</a>\",			\"<a href=\\\"https://www.metal-archives.com/albums/Symptoms_of_Insanity/Silent_Emotion/369174\\\">Silent Emotion</a>\", 			\"Full-length\", 			\"A Desolation Song (Agalloch Cover)\"   		]				,							[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Agalloch/305\\\" title=\\\"Agalloch (US)\\\">Agalloch</a>\",			\"<a href=\\\"https://www.metal-archives.com/albums/Agalloch/Whitedivisiongrey/301685\\\">Whitedivisiongrey</a>\", 			\"Compilation\", 			\"A Desolation Song (TWC Aleutian Mix)\"   		]				]}";
        #endregion

    }
}
