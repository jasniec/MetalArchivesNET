using MetalArchivesNET.Searchers.Configurators.Abstract;
using System.Collections.Generic;

namespace MetalArchivesNET.Searchers.Configurators
{
    /// <summary>
    /// Configuration for simple album search
    /// </summary>
    class SimpleAlbumConfigurators : IConfigurator
    {
        public string Url => @"https://www.metal-archives.com/search/ajax-album-search/";
        public Dictionary<string, string> Parameters { get; } = new Dictionary<string, string>
            {
                { "field", "title"},
                { "sEcho", "1" },
                { "iColumns", "3" },
                { "iDisplayStart", "0" },
                { "iDisplayLength", "200" }
            };
    }
}
