using HtmlAgilityPack;
using MetalArchivesNET.CustomWebsiteConverters;
using System;
using System.Threading.Tasks;
using WebsiteParser.Attributes;
using WebsiteParser.Attributes.Enums;
using WebsiteParser.Attributes.StartAttributes;

namespace MetalArchivesNET.Models.Results.PartResults
{
    /// <summary>
    /// Metal archives' song model
    /// </summary>
    [ListSelector("", ChildSelector = ".even, .odd")]
    public class SongResult
    {
        /// <summary>
        /// Id of lyrics in metal archives databse
        /// </summary>
        [Selector("td:nth-child(4) a", Attribute = "onclick", SkipIfNotFound = true)]
        [Regex(@"toggleLyrics\(\'(\d+)\'\)")]
        [Converter(typeof(ULongConverter))]
        public ulong Id { get; set; }

        /// <summary>
        /// Song's index on album
        /// </summary>
        [Selector("td:first-child")]
        [Regex(@"(\d+).")]
        [Converter(typeof(ByteConverter))]
        public byte Index { get; set; }

        /// <summary>
        /// Song's title
        /// </summary>
        [Selector(".wrapWords")]
        public string Title { get; set; }

        /// <summary>
        /// Duration of the song
        /// </summary>
        [Selector("td:nth-child(3)")]
        [Converter(typeof(TimeSpanConverter))]
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// If song is instrumental
        /// </summary>
        [Selector("td:nth-child(4)")]
        [Remove("&nbsp;\r\n", RemoverValueType.Text)]
        [CompareValue("instrumental", true)]
        public bool IsInstrumental { get; set; }

        /// <summary>
        /// If song has added lyrics
        /// </summary>
        [Selector("td:nth-child(4)")]
        [Remove("&nbsp;\r\n", RemoverValueType.Text)]
        [CompareValue("Show lyrics", true)]
        public bool HasLyrics { get; set; }

        /// <summary>
        /// Gets actual song's lyrics
        /// </summary>
        /// <returns>Lyrics or string.Empty if not exists</returns>
        public string GetLyrics()
        {
            string lyrics = string.Empty;

            if (HasLyrics)
            {
                WebDownloader wd = new WebDownloader($@"https://www.metal-archives.com/release/ajax-view-lyrics/id/{Id}");

                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(wd.DownloadData());

                lyrics = document.DocumentNode.InnerText.Trim();
            }

            return lyrics;
        }

        /// <summary>
        /// Gets actual song's lyrics async
        /// </summary>
        /// <returns>Lyrics or string.Empty if not exists</returns>
        public async Task<string> GetLyricsAsync()
        {
            string lyrics = string.Empty;

            if (HasLyrics)
            {
                WebDownloader wd = new WebDownloader($@"https://www.metal-archives.com/release/ajax-view-lyrics/id/{Id}");

                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(await wd.DownloadDataAsync());

                lyrics = document.DocumentNode.InnerText.Trim();
            }

            return lyrics;
        }

    }
}
