using MetalArchivesNET.Attributes;

namespace MetalArchivesNET.Models.SearchResults
{
    /// <summary>
    /// Representation of band result
    /// </summary>
    public class SimpleBandSearchResult
    {
        [Column(0)]
        [RegexConverter(@"<a.*?>(.+?)</a>")]
        public string Name { get; set; }
        [Column(0)]
        [RegexConverter("<a href=\"(.*?)\">")]
        public string Url { get; set; }
        [Column(1)]
        public string Genre { get; set; }
        [Column(2)]
        [EnumConverter(typeof(Country))]
        public Country Country { get; set; }
    }
}
