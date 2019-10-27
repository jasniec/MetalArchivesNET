using MetalArchivesNET.Attributes;
using MetalArchivesNET.Models.Enums;
using MetalArchivesNET.Models.Results.Abstract;
using System;

namespace MetalArchivesNET.Models.Results.SearchResults
{
    /// <summary>
    /// Representation of album result
    /// </summary>
    public class SimpleAlbumSearchResult : BandAlbumResultBase
    {
        [Column(0)]
        [RegexConverter(@"<a.*?>(.+?)</a>")]
        public string Band { get; set; }

        [Column(0)]
        [RegexConverter("<a href=\"(.*?)\".*>")]
        public override string BandUrl { get; set; }

        [Column(1)]
        [RegexConverter(@"<a.*?>(.+?)</a>")]
        public string Name { get; set; }

        [Column(1)]
        [RegexConverter("<a href=\"(.*?)\".*>")]
        public override string AlbumUrl { get; set; }

        [Column(2)]
        [EnumConverter(typeof(AlbumType))]
        public AlbumType AlbumType { get; set; }

        [Column(3)]
        [RegexConverter(@"<!-- (\d{4}-\d{2}-\d{2}) -->")]
        [RegexReplace(@"-00", "-01")]
        [DateTimeConverter("yyyy-MM-dd")]
        public DateTime? AlbumReleaseDate { get; set; }

    }
}
