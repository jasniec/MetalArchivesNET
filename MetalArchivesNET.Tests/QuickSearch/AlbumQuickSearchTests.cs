using MetalArchivesNET.Models.Results.SearchResults;
using MetalArchivesNET.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MetalArchivesNET.Tests.QuickSearch
{
    [TestClass]
    public class AlbumQuickSearchTests
    {
        [TestMethod]
        public void CountCheck()
        {
            List<SimpleAlbumSearchResult> results = GetResults();

            Assert.AreEqual(7, results.Count);
        }

        [TestMethod]
        public void DateCheck()
        {
            List<SimpleAlbumSearchResult> results = GetResults();
            ICollection dates = results.Select(r => r.AlbumReleaseDate).ToList();
            ICollection expectedDates = new List<DateTime>
            {
                new DateTime(2002, 08, 13),
                new DateTime(2017, 01, 17),
                new DateTime(2007, 10, 31),
                new DateTime(2014, 08, 23),
                new DateTime(2018, 09, 21),
                new DateTime(2004, 01, 01),
                new DateTime(2006, 01, 01),
            };

            CollectionAssert.AreEqual(expectedDates, dates);
        }

        [TestMethod]
        public void NamesCheck()
        {
            List<SimpleAlbumSearchResult> results = GetResults();
            ICollection names = results.Select(r => r.Name).ToList();
            ICollection expectedNames = new List<string>
            {
                "The Mantle",
                "The Mantle",
                "Into the Black Mantle",
                "Reinheriting the Mantle",
                "The Mantle of Spiders",
                "The Cold Mantle of Loneliness",
                "Obscure Symphonies into the Black Mantle",
            };

            CollectionAssert.AreEqual(expectedNames, names);
        }

        [TestMethod]
        public void UrlCheck()
        {
            List<SimpleAlbumSearchResult> results = GetResults();
            ICollection urls = results.Select(r => r.AlbumUrl).ToList();
            ICollection expectedUrls = new List<string>
            {
                @"https://www.metal-archives.com/albums/Agalloch/The_Mantle/3526",
                @"https://www.metal-archives.com/albums/The_Mantle/The_Mantle/628894",
                @"https://www.metal-archives.com/albums/Actum_Est/Into_the_Black_Mantle/153080",
                @"https://www.metal-archives.com/albums/Emortuus/Reinheriting_the_Mantle/448256",
                @"https://www.metal-archives.com/albums/Last_Pharaoh/The_Mantle_of_Spiders/736202",
                @"https://www.metal-archives.com/albums/Clair_de_Lune_Morte/The_Cold_Mantle_of_Loneliness/43454",
                @"https://www.metal-archives.com/albums/Actum_Est/Obscure_Symphonies_into_the_Black_Mantle/145877",
            };

            CollectionAssert.AreEqual(expectedUrls, urls);
        }

        #region Band
        [TestMethod]
        public void BandNamesCheck()
        {
            List<SimpleAlbumSearchResult> results = GetResults();
            ICollection names = results.Select(r => r.Band).ToList();
            ICollection expectedNames = new List<string>
            {
                "Agalloch",
                "The Mantle",
                "Actum Est",
                "Emortuus",
                "Last Pharaoh",
                "Clair de Lune Morte",
                "Actum Est",
            };

            CollectionAssert.AreEqual(expectedNames, names);
        }

        [TestMethod]
        public void BandUrlCheck()
        {
            List<SimpleAlbumSearchResult> results = GetResults();
            ICollection urls = results.Select(r => r.BandUrl).ToList();
            ICollection expectedUrls = new List<string>
            {
                @"https://www.metal-archives.com/bands/Agalloch/305",
                @"https://www.metal-archives.com/bands/The_Mantle/3540422253",
                @"https://www.metal-archives.com/bands/Actum_Est/87392",
                @"https://www.metal-archives.com/bands/Emortuus/3540368108",
                @"https://www.metal-archives.com/bands/Last_Pharaoh/3540445389",
                @"https://www.metal-archives.com/bands/Clair_de_Lune_Morte/15496",
                @"https://www.metal-archives.com/bands/Actum_Est/87392",
            };

            CollectionAssert.AreEqual(expectedUrls, urls);
        }
        #endregion

        private List<SimpleAlbumSearchResult> GetResults()
        {
            ResponseParser<SimpleAlbumSearchResult> parser = new ResponseParser<SimpleAlbumSearchResult>();

            return parser.Parse(CONTENT);
        }

        #region Input data

        private const string CONTENT = "{ 	\"error\": \"\",	\"iTotalRecords\": 7,	\"iTotalDisplayRecords\": 7,	\"sEcho\": 1,	\"aaData\": [					[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Agalloch/305\\\" title=\\\"Agalloch (US)\\\">Agalloch</a>\",			\"<a href=\\\"https://www.metal-archives.com/albums/Agalloch/The_Mantle/3526\\\">The Mantle</a> <!-- 1.8727995 -->\" ,			\"Full-length\"      ,				\"August 13th, 2002 <!-- 2002-08-13 -->\"     		]				,							[ 			\"<a href=\\\"https://www.metal-archives.com/bands/The_Mantle/3540422253\\\" title=\\\"The Mantle (US)\\\">The Mantle</a>\",			\"<a href=\\\"https://www.metal-archives.com/albums/The_Mantle/The_Mantle/628894\\\">The Mantle</a> <!-- 1.8727995 -->\" ,			\"Full-length\"      ,				\"January 17th, 2017 <!-- 2017-01-17 -->\"     		]				,							[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Actum_Est/87392\\\" title=\\\"Actum Est (BR)\\\">Actum Est</a>\",			\"<a href=\\\"https://www.metal-archives.com/albums/Actum_Est/Into_the_Black_Mantle/153080\\\">Into the Black Mantle</a> <!-- 1.4982395 -->\" ,			\"EP\"      ,				\"October 31st, 2007 <!-- 2007-10-31 -->\"     		]				,							[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Emortuus/3540368108\\\" title=\\\"Emortuus (AU)\\\">Emortuus</a>\",			\"<a href=\\\"https://www.metal-archives.com/albums/Emortuus/Reinheriting_the_Mantle/448256\\\">Reinheriting the Mantle</a> <!-- 1.4982395 -->\" ,			\"EP\"      ,				\"August 23rd, 2014 <!-- 2014-08-23 -->\"     		]				,							[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Last_Pharaoh/3540445389\\\" title=\\\"Last Pharaoh (US)\\\">Last Pharaoh</a>\",			\"<a href=\\\"https://www.metal-archives.com/albums/Last_Pharaoh/The_Mantle_of_Spiders/736202\\\">The Mantle of Spiders</a> <!-- 1.4982395 -->\" ,			\"Full-length\"      ,				\"September 21st, 2018 <!-- 2018-09-21 -->\"     		]				,							[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Clair_de_Lune_Morte/15496\\\" title=\\\"Clair de Lune Morte (CL)\\\">Clair de Lune Morte</a>\",			\"<a href=\\\"https://www.metal-archives.com/albums/Clair_de_Lune_Morte/The_Cold_Mantle_of_Loneliness/43454\\\">The Cold Mantle of Loneliness</a> <!-- 1.3109596 -->\" ,			\"Demo\"      ,				\"2004 <!-- 2004-00-00 -->\"     		]				,							[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Actum_Est/87392\\\" title=\\\"Actum Est (BR)\\\">Actum Est</a>\",			\"<a href=\\\"https://www.metal-archives.com/albums/Actum_Est/Obscure_Symphonies_into_the_Black_Mantle/145877\\\">Obscure Symphonies into the Black Mantle</a> <!-- 1.1236796 -->\" ,			\"Demo\"      ,				\"2006 <!-- 2006-00-00 -->\"     		]				]}";

        #endregion Input data
    }
}