using MetalArchivesNET.Models.Results.SearchResults;
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

        /// <summary>
        /// Search album
        /// </summary>
        public static SimpleSearcher<SimpleAlbumSearchResult> Album => new SimpleSearcher<SimpleAlbumSearchResult>(new SimpleAlbumConfigurators());

        /// <summary>
        /// Search song
        /// </summary>
        public static SimpleSearcher<SimpleSongSearchResult> Song => new SimpleSearcher<SimpleSongSearchResult>(new SimpleSongConfigurators());
    }
}
