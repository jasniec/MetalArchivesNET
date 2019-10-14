using System.Collections.Generic;

namespace MetalArchivesNET.Searchers.Configurators.Abstract
{
    interface IConfigurator
    {
        string Url { get; }
        Dictionary<string, string> Parameters { get; }
    }
}
