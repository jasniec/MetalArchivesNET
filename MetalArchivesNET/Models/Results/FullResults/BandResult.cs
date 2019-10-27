using HtmlAgilityPack;
using MetalArchivesNET.CustomWebsiteConverters;
using MetalArchivesNET.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebsiteParser.Attributes;
using WebsiteParser.Attributes.Enums;
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
        [Selector(@"#band_stats dl:first-child dd:nth-child(4)", EmptyValues = new string[] { "N/A" })]
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
        [Selector(@"#band_stats dl:first-child dd:nth-child(8)", EmptyValues = new string[] { "N/A" })]
        [Converter(typeof(UShortConverter))]
        public ushort? FormedInYear { get; set; }

        /// <summary>
        /// Genres
        /// </summary>
        [Selector("#band_stats dl:nth-child(2) dd:nth-child(2)", EmptyValues = new string[] { "N/A" })]
        public string GenresString { get; set; }

        /// <summary>
        /// Genres splited from <see cref="GenresString"/>. May not be correctly parsed.
        /// </summary>
        [Selector("#band_stats dl:nth-child(2) dd:nth-child(2)", EmptyValues = new string[] { "N/A" })]
        [Converter(typeof(SplitConverter))]
        public IEnumerable<string> Genres { get; set; }

        /// <summary>
        /// Lyrical themes
        /// </summary>
        [Selector("#band_stats dl:nth-child(2) dd:nth-child(4)", EmptyValues = new string[] { "N/A" })]
        public string LyricalThemesString { get; set; }

        /// <summary>
        /// Lyrical themes splited from <see cref="GenresString"/>. May not be correctly parsed.
        /// </summary>
        [Selector("#band_stats dl:nth-child(2) dd:nth-child(4)", EmptyValues = new string[] { "N/A" })]
        [Converter(typeof(SplitConverter))]
        public IEnumerable<string> LyricalThemes { get; set; }

        /// <summary>
        /// Last label
        /// </summary>
        [Selector("#band_stats dl:nth-child(2) dd:nth-child(6)", EmptyValues = new string[] { "N/A" })]
        public string LastLabel { get; set; }

        /// <summary>
        /// Notes of band
        /// </summary>
        [Selector(".band_comment", NotParseWhenNotFound = true)]
        [Remove("Read more", RemoverValueType.Text)]
        public string NotesShort { get; set; }

        /// <summary>
        /// Url of full notes if exists otherwise null
        /// </summary>
        [Selector(".btn_read_more", Attribute = "onclick", NotParseWhenNotFound = true)]
        [Regex(@"readMore\('(.*?)'\);")]
        [Format(@"https://metal-archives.com/{0}")]
        public string NotesFullUrl { get; set; }

        #region Metadata
        /// <summary>
        /// Name of user who added band
        /// </summary>
        [Selector(@"#auditTrail table tr:first-child td:first-child a")]
        public string AddedBy { get; set; }

        /// <summary>
        /// Band's page add date
        /// </summary>
        [Selector(@"#auditTrail table tr:nth-child(2) td:first-child")]
        [Regex(@"(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2})")]
        [Converter(typeof(DateTimeConverter))]
        public DateTime AddDate { get; set; }

        /// <summary>
        /// Last modification user's name
        /// </summary>
        [Selector(@"#auditTrail table tr:first-child td:last-child a")]
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// Last modification date
        /// </summary>
        [Selector(@"#auditTrail table tr:nth-child(2) td:nth-child(2)")]
        [Regex(@"(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2})")]
        [Converter(typeof(DateTimeConverter))]
        public DateTime LastModifiedDate { get; set; }
        #endregion

        #region Additional notes
        /// <summary>
        /// If <see cref="NotesFullUrl"/> is not null, it returns full band's notes
        /// </summary>
        /// <returns>Band's notes</returns>
        public string GetFullNotes()
        {
            if (string.IsNullOrEmpty(NotesFullUrl))
                return string.Empty;

            WebDownloader downloader = new WebDownloader(NotesFullUrl);
            string content = downloader.DownloadData();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(content);

            return doc.DocumentNode.InnerText;
        }

        /// <summary>
        /// If <see cref="NotesFullUrl"/> is not null, it returns full band's notes async
        /// </summary>
        /// <returns>Band's notes</returns>
        public async Task<string> GetFullNotesAsync()
        {
            if (string.IsNullOrEmpty(NotesFullUrl))
                return string.Empty;

            WebDownloader downloader = new WebDownloader(NotesFullUrl);
            string content = await downloader.DownloadDataAsync();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(content);

            return doc.DocumentNode.InnerText;
        }
        #endregion

    }
}
