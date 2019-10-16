using MetalArchivesNET;
using MetalArchivesNET.Models.SearchResults;
using MetalArchivesNET.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MetalArchivesNET.Tests.QuickSearch
{
    [TestClass]
    public class BandQuickSearchTests
    {
        [TestMethod]
        public void CountCheck()
        {
            List<SimpleBandSearchResult> results = GetResults();

            Assert.AreEqual(14, results.Count);
        }

        [TestMethod]
        public void GenresCheck()
        {
            List<SimpleBandSearchResult> results = GetResults();
            ICollection names = results.Select(r => r.Genre).ToList();
            ICollection expectedGenres = new List<string>
            {
                "Heavy/Doom Metal",
                "Black/Death Metal/Ambient",
                "Death Metal/Crust Punk",
                "Psychedelic Rock, Doom Metal",
                "Heavy Metal",
                "Death/Groove Metal",
                "Doom/Heavy Metal",
                "Heavy/Speed Metal",
                "Black/Thrash Metal",
                "Black Metal",
                "Symphonic Gothic/Power Metal",
                "Black/Heavy Metal",
                "Black/Death Metal",
                "Raw Black Metal"
            };

            CollectionAssert.AreEqual(expectedGenres, names);
        }

        [TestMethod]
        public void CountryCheck()
        {
            List<SimpleBandSearchResult> results = GetResults();
            ICollection names = results.Select(r => r.Country).ToList();
            ICollection expectedCountries = new List<Country>
            {
                Country.UnitedKingdom,
                Country.UnitedStates,
                Country.Greece,
                Country.UnitedStates,
                Country.UnitedStates,
                Country.Chile,
                Country.UnitedStates,
                Country.Chile,
                Country.Germany,
                Country.UnitedStates,
                Country.Japan,
                Country.Germany,
                Country.Spain,
                Country.France
            };

            CollectionAssert.AreEqual(expectedCountries, names);
        }

        [TestMethod]
        public void NamesCheck()
        {
            List<SimpleBandSearchResult> results = GetResults();
            ICollection names = results.Select(r => r.Name).ToList();
            ICollection expectedNames = new List<string>
            {
                "Black Sabbath",
                "Frostbitten Sabbath",
                "Miasmal Sabbath",
                "Sabbath Assembly",
                "Sabbath Knights",
                "Smoking Sabbath",
                "White Sabbath",
                "Witches Sabbath",
                "Witches Sabbath",
                "Witches Sabbath",
                "Sabbath Black Heretic",
                "The Witches Sabbath",
                "Witches' Sabbath",
                "Blvck Svbbvth"
            };

            CollectionAssert.AreEqual(expectedNames, names);
        }

        [TestMethod]
        public void UrlCheck()
        {
            List<SimpleBandSearchResult> results = GetResults();
            ICollection names = results.Select(r => r.Url).ToList();
            ICollection expectedUrls = new List<string>
            {
                @"https://www.metal-archives.com/bands/Black_Sabbath/99",
                @"https://www.metal-archives.com/bands/Frostbitten_Sabbath/3540349683",
                @"https://www.metal-archives.com/bands/Miasmal_Sabbath/3540425705",
                @"https://www.metal-archives.com/bands/Sabbath_Assembly/3540400007",
                @"https://www.metal-archives.com/bands/Sabbath_Knights/44843",
                @"https://www.metal-archives.com/bands/Smoking_Sabbath/3540435846",
                @"https://www.metal-archives.com/bands/White_Sabbath/101263",
                @"https://www.metal-archives.com/bands/Witches_Sabbath/3540412697",
                @"https://www.metal-archives.com/bands/Witches_Sabbath/3540403757",
                @"https://www.metal-archives.com/bands/Witches_Sabbath/97927",
                @"https://www.metal-archives.com/bands/Sabbath_Black_Heretic/3540442557",
                @"https://www.metal-archives.com/bands/The_Witches_Sabbath/48387",
                @"https://www.metal-archives.com/bands/Witches%27_Sabbath/13601",
                @"https://www.metal-archives.com/bands/Blvck_Svbbvth/3540458070"
            };

            CollectionAssert.AreEqual(expectedUrls, names);
        }

        private List<SimpleBandSearchResult> GetResults()
        {
            ResponseParser<SimpleBandSearchResult> parser = new ResponseParser<SimpleBandSearchResult>();

            return parser.Parse(CONTENT);
        }

        #region Input data
        const string CONTENT = "{ 	\"error\": \"\",	\"iTotalRecords\": 14,	\"iTotalDisplayRecords\": 14,	\"sEcho\": 1,	\"aaData\": [				[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Black_Sabbath/99\\\">Black Sabbath</a>  <!-- 6.3302236 -->\" ,				\"Heavy/Doom Metal\" ,			\"United Kingdom\"     		]				,						[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Frostbitten_Sabbath/3540349683\\\">Frostbitten Sabbath</a>  <!-- 6.3302236 -->\" ,				\"Black/Death Metal/Ambient\" ,			\"United States\"     		]				,						[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Miasmal_Sabbath/3540425705\\\">Miasmal Sabbath</a>  <!-- 6.3302236 -->\" ,				\"Death Metal/Crust Punk\" ,			\"Greece\"     		]				,						[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Sabbath_Assembly/3540400007\\\">Sabbath Assembly</a>  <!-- 6.3302236 -->\" ,				\"Psychedelic Rock, Doom Metal\" ,			\"United States\"     		]				,						[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Sabbath_Knights/44843\\\">Sabbath Knights</a>  <!-- 6.3302236 -->\" ,				\"Heavy Metal\" ,			\"United States\"     		]				,						[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Smoking_Sabbath/3540435846\\\">Smoking Sabbath</a>  <!-- 6.3302236 -->\" ,				\"Death/Groove Metal\" ,			\"Chile\"     		]				,						[ 			\"<a href=\\\"https://www.metal-archives.com/bands/White_Sabbath/101263\\\">White Sabbath</a>  <!-- 6.3302236 -->\" ,				\"Doom/Heavy Metal\" ,			\"United States\"     		]				,						[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Witches_Sabbath/3540412697\\\">Witches Sabbath</a>  <!-- 6.3302236 -->\" ,				\"Heavy/Speed Metal\" ,			\"Chile\"     		]				,						[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Witches_Sabbath/3540403757\\\">Witches Sabbath</a>  <!-- 6.3302236 -->\" ,				\"Black/Thrash Metal\" ,			\"Germany\"     		]				,						[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Witches_Sabbath/97927\\\">Witches Sabbath</a>  <!-- 6.3302236 -->\" ,				\"Black Metal\" ,			\"United States\"     		]				,						[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Sabbath_Black_Heretic/3540442557\\\">Sabbath Black Heretic</a>  <!-- 5.064179 -->\" ,				\"Symphonic Gothic/Power Metal\" ,			\"Japan\"     		]				,						[ 			\"<a href=\\\"https://www.metal-archives.com/bands/The_Witches_Sabbath/48387\\\">The Witches Sabbath</a>  <!-- 5.064179 -->\" ,				\"Black/Heavy Metal\" ,			\"Germany\"     		]				,						[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Witches%27_Sabbath/13601\\\">Witches' Sabbath</a>  <!-- 5.064179 -->\" ,				\"Black/Death Metal\" ,			\"Spain\"     		]				,						[ 			\"<a href=\\\"https://www.metal-archives.com/bands/Blvck_Svbbvth/3540458070\\\">Blvck Svbbvth</a> (<strong>a.k.a.</strong> Bluck Subbuth, Black Sabbath) <!-- 1.6253864 -->\" ,				\"Raw Black Metal\" ,			\"France\"     		]				]}";
        #endregion
    }
}
