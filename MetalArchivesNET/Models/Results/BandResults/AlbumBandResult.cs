using MetalArchivesNET.CustomWebsiteConverters;
using MetalArchivesNET.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using WebsiteParser.Attributes;

namespace MetalArchivesNET.Models.Results.BandResults
{
    /// <summary>
    /// One item from band's album list
    /// </summary>
    [ListSelector("table tbody", ChildSelector = "tr")]
    public class AlbumBandResult
    {
        /// <summary>
        /// Name of band's album
        /// </summary>
        [Selector("td:nth-child(1)")]
        public string AlbumName { get; set; }

        /// <summary>
        /// Url of band's album
        /// </summary>
        [Selector("td:nth-child(1) a", Attribute = "href")]
        public string AlbumUrl { get; set; }

        /// <summary>
        /// Band's album type
        /// </summary>
        [Selector("td:nth-child(2)")]
        [Converter(typeof(EnumDescriptionConverter<AlbumType>))]
        public AlbumType AlbumType { get; set; }

        /// <summary>
        /// Band's album release year
        /// </summary>
        [Selector("td:nth-child(3)")]
        [Converter(typeof(UShortConverter))]
        public ushort AlbumReleaseYear { get; set; }

        //TODO: Reviews
    }
}
