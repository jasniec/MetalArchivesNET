using MetalArchivesNET.CustomWebsiteConverters;
using MetalArchivesNET.Models.Enums;
using MetalArchivesNET.Models.Results.Abstract;
using MetalArchivesNET.Models.Results.PartResults;
using System;
using System.Collections.Generic;
using System.Linq;
using WebsiteParser.Attributes;
using WebsiteParser.Attributes.StartAttributes;
using WebsiteParser.Converters;

namespace MetalArchivesNET.Models.Results.FullResults
{
    /// <summary>
    /// Representation of album's page
    /// </summary>
    public class AlbumResult : BandResultBase
    {
        /// <summary>
        /// Metal archives album's identification number
        /// </summary>
        [Selector(".album_name a", Attribute = "href")]
        [Regex(@"/(\d+)$")]
        [Converter(typeof(ULongConverter))]
        public ulong Id { get; set; }

        /// <summary>
        /// Band's name
        /// </summary>
        [Selector(".band_name")]
        public string BandName { get; set; }

        /// <summary>
        /// Band's url address
        /// </summary>
        [Selector(".band_name a", Attribute = "href")]
        public override string BandUrl { get; set; }

        /// <summary>
        /// Album's name
        /// </summary>
        [Selector(".album_name")]
        public string AlbumName { get; set; }

        /// <summary>
        /// Album type
        /// </summary>
        [Selector("#album_info dl.float_left dd:nth-child(2)")]
        [Converter(typeof(EnumDescriptionConverter<AlbumType>))]
        public AlbumType AlbumType { get; set; }

        /// <summary>
        /// Album's release date
        /// </summary>
        [Selector("#album_info dl.float_left dd:nth-child(4)")]
        [Converter(typeof(AlbumDateTimeConverter))]
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Album's catalog id (numbers or string)
        /// </summary>
        [Selector("#album_info dl.float_left dd:nth-child(6)", EmptyValues = new string[] { "N/A" })]
        public string CatalogId { get; set; }

        /// <summary>
        /// Is limited edition, additional info about version
        /// </summary>
        [Selector("#album_info dl.float_left dd:nth-child(8)", EmptyValues = new string[] { "N/A" }, SkipIfNotFound = true)]
        public string VersionDescription { get; set; }

        /// <summary>
        /// Label
        /// </summary>
        [Selector("#album_info dl.float_right dd:nth-child(2)", EmptyValues = new string[] { "N/A" })]
        public string Label { get; set; }

        /// <summary>
        /// Album's format (CD, Vinyl, etc.)
        /// </summary>
        [Selector("#album_info dl.float_right dd:nth-child(4)")]
        [Converter(typeof(EnumDescriptionConverter<AlbumFormat>))]
        public AlbumFormat Format { get; set; }

        /// <summary>
        /// IEnumerable of songs in actual album with lyrics (if exists)
        /// </summary>
        [WebsiteParserList(Selector = ".table_lyrics")]
        public IEnumerable<SongResult> Songs { get => _songs.OrderBy(s => s.Index); set => _songs = value; }

        /// <summary>
        /// Informations about page's add and update
        /// </summary>
        [WebsiteParserModel(Selector = "#auditTrail")]
        public Metadata Metadata { get; set; }

        //TODO: reviews
        //TODO: Is limited edition bool

        private IEnumerable<SongResult> _songs;
    }
}
