using MetalArchivesNET.Attributes;
using MetalArchivesNET.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetalArchivesNET.Models.SearchResults
{
    /// <summary>
    /// Representation of song result
    /// </summary>
    public class SimpleSongSearchResult
    {
        [Column(3)]
        public string Title { get; set; }
        [Column(1)]
        [RegexConverter(@"<a.*?>(.+?)</a>")]
        public string AlbumName { get; set; }
        [Column(1)]
        [RegexConverter("<a href=\"(.*?)\".*>")]
        public string AlbumUrl { get; set; }
        [Column(2)]
        [EnumConverter(typeof(AlbumType))]
        public AlbumType AlbumType { get; set; }
        [Column(0)]
        [RegexConverter(@"<a.*?>(.+?)</a>")]
        public string BandName { get; set; }
        [Column(0)]
        [RegexConverter("<a href=\"(.*?)\".*>")]
        public string BandUrl { get; set; }
    }
}
