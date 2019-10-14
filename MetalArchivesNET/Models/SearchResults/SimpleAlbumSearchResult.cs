using MetalArchivesNET.Attributes;
using MetalArchivesNET.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetalArchivesNET.Models.SearchResults
{
    /// <summary>
    /// Representation of album result
    /// </summary>
    public class SimpleAlbumSearchResult
    {
        [Column(0)]
        [RegexConverter(@"<a.*?>(.+?)</a>")]
        public string Band { get; set; }
        [Column(0)]
        [RegexConverter("<a href=\"(.*?)\".*>")]
        public string BandUrl { get; set; }
        [Column(1)]
        [RegexConverter(@"<a.*?>(.+?)</a>")]
        public string Name { get; set; }
        [Column(1)]
        [RegexConverter("<a href=\"(.*?)\".*>")]
        public string Url { get; set; }
        [Column(2)]
        [EnumConverter(typeof(AlbumType))]
        public AlbumType Type { get; set; }
        [Column(3)]
        [RegexConverter(@"<!-- (\d{4}-\d{2}-\d{2}) -->")]
        [RegexReplace(@"-00", "-01")]
        [DateTimeConverter("yyyy-MM-dd")]
        public DateTime? Date { get; set; }
    }
}
