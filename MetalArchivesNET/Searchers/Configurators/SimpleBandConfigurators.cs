using MetalArchivesNET.Searchers.Configurators.Abstract;
using System.Collections.Generic;

namespace MetalArchivesNET.Searchers.Configurators
{
    /// <summary>
    /// Configuration for simple band search
    /// </summary>
    class SimpleBandConfigurators : IConfigurator
    {
        public string Url => @"https://www.metal-archives.com/search/ajax-band-search/";
        public Dictionary<string, string> Parameters { get; } = new Dictionary<string, string>
            {
                { "field", "name"},
                { "sEcho", "1" },
                { "iColumns", "3" },
                { "iDisplayStart", "0" },
                { "iDisplayLength", "200" }
            };
    }
}
