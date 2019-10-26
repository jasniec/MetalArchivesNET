using MetalArchivesNET.Attributes;
using MetalArchivesNET.Models.Enums;
using MetalArchivesNET.Models.Results.Abstract;
using MetalArchivesNET.Models.Results.FullResults;
using MetalArchivesNET.Parsers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebsiteParser;

namespace MetalArchivesNET.Models.Results.SearchResults
{
    /// <summary>
    /// Representation of song result
    /// </summary>
    public class SimpleSongSearchResult : BandResultBase
    {
        [Column(3)]
        public string SongTitle { get; set; }
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
        public override string BandUrl { get; set; }

    }
}
