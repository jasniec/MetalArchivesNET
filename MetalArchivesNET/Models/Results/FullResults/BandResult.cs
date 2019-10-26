using MetalArchivesNET.CustomWebsiteConverters;
using MetalArchivesNET.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using WebsiteParser.Attributes;
using WebsiteParser.Converters;
using WebsiteParser.Converters.Abstract;

namespace MetalArchivesNET.Models.Results.FullResults
{
    /// <summary>
    /// Representation of band's page
    /// </summary>
    public class BandResult
    {
        /// <summary>
        /// Band's name
        /// </summary>
        [Selector(@".band_name")]
        public string Name { get; set; }

        /// <summary>
        /// Country of origin
        /// </summary>
        [Selector(@"#band_stats dl:first-child dd:nth-child(2)")]
        [Converter(typeof(EnumDescriptionConverter<Country>))]
        public Country CountryOfOrigin { get; set; }

        /// <summary>
        /// Bands location. Usually city and country
        /// </summary>
        [Selector(@"#band_stats dl:first-child dd:nth-child(4)")]
        public string Location { get; set; }

        /// <summary>
        /// Band's status
        /// </summary>
        [Selector(@"#band_stats dl:first-child dd:nth-child(6)")]
        [Converter(typeof(EnumDescriptionConverter<BandStatus>))]
        public BandStatus Status { get; set; }

        /// <summary>
        /// Yer when the band was formed
        /// </summary>
        [Selector(@"#band_stats dl:first-child dd:nth-child(8)")]
        [Converter(typeof(UShortConverter))]
        public ushort? FormedInYear { get; set; }

        /// <summary>
        /// Genres
        /// </summary>
        [Selector("#band_stats dl:nth-child(2) dd:nth-child(2)")]
        public string GenresString { get; set; }

        /// <summary>
        /// Genres splited from <see cref="GenresString"/>. May not be correctly parsed.
        /// </summary>
        [Selector("#band_stats dl:nth-child(2) dd:nth-child(2)")]
        [Converter(typeof(SplitConverter))]
        public IEnumerable<string> Genres { get; set; }

        /// <summary>
        /// Lyrical themes
        /// </summary>
        [Selector("#band_stats dl:nth-child(2) dd:nth-child(4)")]
        public string LyricalThemesString { get; set; }

        /// <summary>
        /// Lyrical themes splited from <see cref="GenresString"/>. May not be correctly parsed.
        /// </summary>
        [Selector("#band_stats dl:nth-child(2) dd:nth-child(4)")]
        [Converter(typeof(SplitConverter))]
        public IEnumerable<string> LyricalThemes { get; set; }

        /// <summary>
        /// Last label
        /// </summary>
        [Selector("#band_stats dl:nth-child(2) dd:nth-child(6)")]
        public string LastLabel { get; set; }

        #region Metadata
        [Selector(@"#auditTrail table tr:first-child td:first-child a")]
        public string AddedBy { get; set; }

        [Selector(@"#auditTrail table tr:nth-child(2) td:first-child")]
        [Regex(@"(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2})")]
        [Converter(typeof(DateTimeConverter))]
        public DateTime AddDate { get; set; }

        [Selector(@"#auditTrail table tr:first-child td:last-child a")]
        public string LastModifiedBy { get; set; }

        [Selector(@"#auditTrail table tr:nth-child(2) td:nth-child(2)")]
        [Regex(@"(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2})")]
        [Converter(typeof(DateTimeConverter))]
        public DateTime LastModifiedDate { get; set; }
        #endregion

    }
}
