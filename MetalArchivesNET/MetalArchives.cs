using MetalArchivesNET.Models.SearchResults;
using MetalArchivesNET.Searchers;
using MetalArchivesNET.Searchers.Configurators;

namespace MetalArchivesNET
{
    public static class MetalArchives
    {
        /// <summary>
        /// Search band
        /// </summary>
        public static SimpleSearcher<SimpleBandSearchResult> Band => new SimpleSearcher<SimpleBandSearchResult>(new SimpleBandConfigurators());
    }
}
