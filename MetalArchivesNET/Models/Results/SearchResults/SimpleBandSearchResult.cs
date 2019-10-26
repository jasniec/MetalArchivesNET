using MetalArchivesNET.Attributes;
using MetalArchivesNET.Models.Results.Abstract;
using MetalArchivesNET.Models.Results.FullResults;
using System.Threading.Tasks;
using WebsiteParser;

namespace MetalArchivesNET.Models.Results.SearchResults
{
    /// <summary>
    /// Representation of band result
    /// </summary>
    public class SimpleBandSearchResult : BandResultBase
    {
        [Column(0)]
        [RegexConverter(@"<a.*?>(.+?)</a>")]
        public string BandName { get; set; }
        [Column(0)]
        [RegexConverter("<a href=\"(.*?)\".*>")]
        public override string BandUrl { get; set; }
        [Column(1)]
        public string BandGenre { get; set; }
        [Column(2)]
        [EnumConverter(typeof(Country))]
        public Country BandCountry { get; set; }

    }
}
