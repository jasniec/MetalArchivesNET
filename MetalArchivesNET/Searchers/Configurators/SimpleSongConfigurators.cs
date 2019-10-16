using MetalArchivesNET.Searchers.Configurators.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetalArchivesNET.Searchers.Configurators
{
    class SimpleSongConfigurators : IConfigurator
    {
        public string Url => @"https://www.metal-archives.com/search/ajax-song-search/";
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
